using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientRecordsAssignment.Startup))]
namespace PatientRecordsAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
