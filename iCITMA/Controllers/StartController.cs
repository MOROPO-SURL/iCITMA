namespace MOROPO.CITMA.CMG.iCITMA.Controllers
{
    public class StartController : Microsoft.AspNetCore.Mvc.Controller
    {
        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            return Redirect("management/dashboard");
        }
    }
}
