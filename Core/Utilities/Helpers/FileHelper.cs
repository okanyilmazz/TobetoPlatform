using Core.Business.Rules;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers;

public class FileHelper : IFileHelper
{
    //Path.GetExtension --Dosya uzantısını alır

    FileBusinessRules _fileBusinessRules;

    public FileHelper(FileBusinessRules fileBusinessRules)
    {
        _fileBusinessRules = fileBusinessRules;
    }

    public async Task<string> Add(IFormFile file, string destinationFolderPath)
    {
        await _fileBusinessRules.IsExistDestinationFolder(destinationFolderPath);
        string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        return CreateFile(file, destinationFolderPath + newFileName);
    }

    public async Task Delete(string deletedFilePath)
    {
        await _fileBusinessRules.CheckFileExist(deletedFilePath);
        File.Delete(deletedFilePath);
    }

    public async Task Update(IFormFile file, string oldFilePath)
    {
        await _fileBusinessRules.CheckFileExist(oldFilePath);
        Delete(oldFilePath);
        CreateFile(file, oldFilePath);

        // File.Delete(oldFilePath);
    }

    public string CreateFile(IFormFile file, string destinationFolderPath)
    {
        using (FileStream fileStream = File.Create(destinationFolderPath))
        {
            file.CopyTo(fileStream);
            fileStream.Flush();
            return destinationFolderPath;
        }
    }
}
