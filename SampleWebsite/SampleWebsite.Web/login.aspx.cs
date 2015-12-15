using SampleWebsite.Business;
using SampleWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebsite.Web
{
    public partial class login : System.Web.UI.Page
    {
        #region Global Variables

        UserComponent userComponent = new UserComponent();

        #endregion

        #region Page Events

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Handles the Click event of the Login control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Login_Click(object sender, System.EventArgs e)
        {
            try
            {
                UserModel userInfo = userComponent.GetUserInfoByUsernameAndPassword(txtUsername.Value.Trim(), txtPassword.Value.Trim());

                if (userInfo != null && userInfo.Id > 0)
                {
                    // 4. Do the redirect.
                    FormsAuthentication.RedirectFromLoginPage(userInfo.Id.ToString(), false);
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ErrorLog.LogErrorsToFile(ex.Message);
            }
        }

        #endregion
    }
}