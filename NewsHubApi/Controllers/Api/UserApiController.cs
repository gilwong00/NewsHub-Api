using NewsHubApi.Managers;
using NewsHubApi.Managers.User;
using NewsHubApi.Mappers.User;
using NewsHubApi.Models.DataModels.User;
using NewsHubApi.Providers.User;
using NewsHubApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NewsHubApi.Controllers.Api
{
    [RoutePrefix("api/user")]
    public class UserApiController : ApiController
    {
        //Services
        private readonly IPasswordService _passwordService;

        //Managers
        private readonly IUserManager _userManager;

        //Providers
        private readonly IUserProvider _userProvider;

        //Mappers
        private readonly IUserMapper _userMapper;

        public UserApiController(
                IPasswordService passwordService,
                IUserManager userManager,
                IUserProvider userProvider,
                IUserMapper userMapper
            )
        {
            _passwordService = passwordService;
            _userManager = userManager;
            _userProvider = userProvider;
            _userMapper = userMapper;
        }

        [AllowAnonymous]
        [Route("create"), HttpPost]
        public async Task<HttpResponseMessage> CreateNewUser(NewUserDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Passwords do not match");
            }

            try
            {
                model.Password = _passwordService.HashUserPassword(model.Password);
                await _userManager.AddNewUser(model);
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error creating new user");
            }
        }

        [AllowAnonymous]
        [Route("signIn"), HttpPost]
        public async Task<HttpResponseMessage> Login(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
                }


                var user = await _userProvider.GetUser(model);
                var response = new HttpResponseMessage();

                if (user != null)
                {
                    var isPasswordValid = _passwordService.ValidatePassword(model.Password, user.Password);

                    if (isPasswordValid)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, _userMapper.MapUser(model));
                    }
                    else
                    {
                        throw new UnauthorizedAccessException();
                    }
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.BadGateway, "User does not exist");
                }

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, err.Message);
            }
        }
    }
}
