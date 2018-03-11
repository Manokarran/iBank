using Microsoft.AspNetCore.Mvc;

namespace IBankApp.API.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            //Set as default api to make sure communication works
            return Ok();

        }
    }
}