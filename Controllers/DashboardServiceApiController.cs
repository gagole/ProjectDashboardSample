using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using DevExpress.DashboardCommon;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using DevExpress.Pdf;
using AppDashboard;

namespace ProjectDashboardSample.Controllers
{
    public class DashboardServiceApiController : DashboardController
    {
        DefaultDashboardConfigurator _conf;
        public DashboardServiceApiController(DefaultDashboardConfigurator conf, IDataProtectionProvider dataProtectionProvider = null) : base(conf, dataProtectionProvider)
        {
            _conf = conf;
        }
    }

}
