using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SampleWebsite.Utility
{
    public class AdminBasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!UserSession.IsAuntheticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            // Be sure to call the base class's OnLoad method!
            base.OnLoad(e);
        }
    }
}
