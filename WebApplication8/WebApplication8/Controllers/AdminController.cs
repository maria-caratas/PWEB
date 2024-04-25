using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    // Actions for admin only
}