using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft;

public class CacheMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;

    public CacheMiddleware(RequestDelegate next)
    {
        _next = next;
        _cache = new MemoryCache(new MemoryCacheOptions());
    }

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var cacheAttribute = endpoint?.Metadata.GetMetadata<CacheAttribute>();
        var cacheRemoveAttribute = endpoint?.Metadata.GetMetadata<CacheRemoveAttribute>();

        if (cacheAttribute != null)
        {
            int duration = cacheAttribute.Duration > 0 ? cacheAttribute.Duration : 60;

            await AddCache(context, duration);
        }
        else if (cacheRemoveAttribute != null)
        {
            await RemoveCache(context, cacheRemoveAttribute);
        }
        else
        {
            await _next(context);
        }
    }

    private async Task AddCache(HttpContext context, int duration)
    {
        if (context.Request.Method == HttpMethod.Get.ToString())
        {
            var cacheKey = GenerateCacheKey(context);
            if (_cache.TryGetValue(cacheKey, out var cachedResponse))
            {
                var responseBody = JsonConvert.SerializeObject(cachedResponse);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(responseBody);
                return;
            }

            var originalResponseBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                memoryStream.Position = 0;
                var responseBody = new StreamReader(memoryStream).ReadToEnd();
                var jsonResponse = JsonConvert.DeserializeObject(responseBody);
                _cache.Set(cacheKey, jsonResponse, TimeSpan.FromSeconds(duration));

                memoryStream.Position = 0;
                await memoryStream.CopyToAsync(originalResponseBody);
            }
        }
        else
        {
            await _next(context);
        }
    }

    private async Task RemoveCache(HttpContext context, CacheRemoveAttribute cacheRemoveAttribute)
    {
        var pattern = GenerateRemoveCacheKey(cacheRemoveAttribute);
        var fieldInfo = typeof(MemoryCache).GetField("_coherentState", BindingFlags.Instance | BindingFlags.NonPublic);
        var propertyInfo = fieldInfo.FieldType.GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.NonPublic);
        var value = fieldInfo.GetValue(_cache);
        var dict = propertyInfo.GetValue(value) as dynamic;

        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
        foreach (var cacheItem in dict)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue);
        }

        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

        foreach (var key in keysToRemove)
        {
            _cache.Remove(key);
        }

        await _next(context);
    }

    private string GenerateCacheKey(HttpContext context)
    {
        return $"{context.Request.Path}";
    }

    private string GenerateRemoveCacheKey(CacheRemoveAttribute cacheRemoveAttribute)
    {

        var strArray = cacheRemoveAttribute.CacheType.Split(new[] { "." }, StringSplitOptions.None);
        var pattern = string.Join("/", strArray);

        return pattern;
    }
}