using NewsHubApi.Managers;
using NewsHubApi.Models.DataModels.User;
using NewsHubApi.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsHubApi.Mappers.User
{
    public class UserMapper : IUserMapper
    {
        public UserViewModel MapUser(UserModel model)
        {
            return new UserViewModel
            {
                Id = model.Id,
                Email = model.Email,
                HandleName = (model.HandleName.Length > 0) ? model.HandleName : model.Email,
                token = JwtManager.GenerateToken(model.Email)
            };
        }
    }
}