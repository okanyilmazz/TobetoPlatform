using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.Dtos.Requests.AuthRequests
{
    public class LoginAuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
