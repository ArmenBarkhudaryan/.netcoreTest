using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsStore.Controllers;

namespace ASP.NET_Core_SPAs.Controllers
{

    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        // POST: /Account/Login
        //[ValidateAntiForgeryToken]
        [HttpPost]
        [Route("[action]")]
        public async Task Login()
        {
            if (ModelState.IsValid)
            {
                await TokenProvider.TokenProvider(HttpContext);
                return;
            }
            HttpContext.Response.StatusCode = 401; 
        }






        //    //
        //    // POST: /Account/LogOff
        //    //[HttpPost]
        //    //[ValidateAntiForgeryToken]
        //    //public async Task<IActionResult> LogOff()
        //    //{
        //    //    await _signInManager.SignOutAsync();
        //    //    _logger.LogInformation(4, "User logged out.");
        //    //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //    //}
        //}
    }
}