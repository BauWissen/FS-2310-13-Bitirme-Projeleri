using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamTask.API.AuthorHelper
{
    [Authorize(Roles = "Admin")]
    public class AuthorAdmin:ControllerBase
    {
    }
    [Authorize(Roles = "User,Admin")]
    public class AuthorUser:ControllerBase
    {

    }
}
