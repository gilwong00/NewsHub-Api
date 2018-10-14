using System.Threading.Tasks;
using NewsHubApi.Models.DataModels.User;

namespace NewsHubApi.Providers.User
{
    public interface IUserProvider
    {
        Task<UserModel> GetUser(UserModel model);
    }
}