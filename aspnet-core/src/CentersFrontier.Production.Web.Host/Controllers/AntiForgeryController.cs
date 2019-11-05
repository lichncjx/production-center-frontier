using Microsoft.AspNetCore.Antiforgery;
using CentersFrontier.Production.Controllers;

namespace CentersFrontier.Production.Web.Host.Controllers
{
    public class AntiForgeryController : ProductionControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
