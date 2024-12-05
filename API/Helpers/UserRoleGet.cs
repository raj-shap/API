using API.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Helpers
{
    public class UserRoleGet
    {
        private readonly AdminRoleController _controller;

        public UserRoleGet(AdminRoleController adminRoleController)
        {
            _controller = adminRoleController;
        }
        public static AdminRoleController adminRoleController()
        {
            return new AdminRoleController();
        }
    }
}
