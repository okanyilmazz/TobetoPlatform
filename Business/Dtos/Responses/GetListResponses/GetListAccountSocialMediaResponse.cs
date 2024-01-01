using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountSocialMediaResponse
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string SocialMediaName { get; set; }
        public string Url { get; set; }
    }
}
