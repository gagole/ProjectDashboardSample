using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDashboardSample.Controllers
{
    public class DashboardServiceController : Controller
    {
        [Route("dashboard")]
        //dashboardId: Name of dashboard file (not including filename extension)
        //controlName: random name for dashboardControl
        public ActionResult Index(string controlName, string dashboardId)
        {
            var model = new DashboardModel();
            if (controlName == null && dashboardId == null)
            {
                model.dashboardControlName = "dashboardEditorControl";
                model.DashboardId = "edit";
                model.WorkingMode = WorkingMode.Designer;
            }
            else
            {
                model.dashboardControlName = controlName;
                model.DashboardId = dashboardId;
                model.WorkingMode = WorkingMode.ViewerOnly;
            }
            return View(model);
        }

    }

    public class DashboardModel
    {
        public string dashboardControlName { get; set; }
        public string DashboardId { get; set; }

        public DevExpress.DashboardWeb.WorkingMode WorkingMode { get; set; }
    }

}
