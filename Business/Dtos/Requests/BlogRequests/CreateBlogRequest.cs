using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.BlogRequests;
public class CreateBlogRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ReleaseDate { get; set; }
    public string ThumbnailPath { get; set; }
}

