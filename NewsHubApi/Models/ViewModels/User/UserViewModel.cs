using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsHubApi.Models.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string token { get; set; }

        public string HandleName { get; set; }
    }
}