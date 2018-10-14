using NewsHubApi.Models.DataModels.User;
using NewsHubApi.Models.ViewModels.User;

namespace NewsHubApi.Mappers.User
{
    public interface IUserMapper
    {
        UserViewModel MapUser(UserModel model);
    }
}