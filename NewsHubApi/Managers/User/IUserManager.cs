using System.Threading.Tasks;
using NewsHubApi.Models.DataModels.User;

namespace NewsHubApi.Managers.User
{
    public interface IUserManager
    {
        Task<bool> AddNewUser(NewUserDataModel model);
    }
}