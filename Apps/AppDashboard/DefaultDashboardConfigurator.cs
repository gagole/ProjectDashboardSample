using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Native;
using DevExpress.DataAccess.Web;
using ProjectDashboardSample;
using System.Collections.Generic;

namespace AppDashboard
{
    public class DefaultDashboardConfigurator : DashboardConfigurator
    {
        public DefaultDashboardConfigurator()
        {
            SetConnectionStringsProvider(new CustomDataSourceWizardConnectionStringsProvider());
            SetDashboardStorage(new DashboardFileStorage(Startup.FileProvider.GetFileInfo("Apps/AppDashboard/Data/Dashboards").PhysicalPath));
        }
    }

    public class CustomDataSourceWizardConnectionStringsProvider : IDataSourceWizardConnectionStringsProvider
    {
        public CustomDataSourceWizardConnectionStringsProvider()
        {
        }
        public Dictionary<string, string> GetConnectionDescriptions()
        {
            Dictionary<string, string> connections = new Dictionary<string, string>();

            // Customize the loaded connections list.  
            connections.Remove("LocalSqlServer");
            //connections.Add("nwindConnection", "MS Access Connection");
            connections.Add(Startup.Configuration.GetSection("DashboardConnection:Key").Value, 
                Startup.Configuration.GetSection("DashboardConnection:Name").Value);
            return connections;
        }

        public DataConnectionParametersBase GetDataConnectionParameters(string name)
        {
            if (name == Startup.Configuration.GetSection("DashboardConnection:Name").Value)
            {
                return new MsSqlConnectionParameters(Startup.Configuration.GetSection("DashboardConnection:Server").Value,
                    Startup.Configuration.GetSection("DashboardConnection:DBName").Value,
                    Startup.Configuration.GetSection("DashboardConnection:UserName").Value,
                    Startup.Configuration.GetSection("DashboardConnection:Password").Value,
                    MsSqlAuthorizationType.SqlServer);
            }
            return AppConfigHelper.LoadConnectionParameters(name);
        }
    }
}
