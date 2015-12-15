using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SampleWebsite.Utility
{
    public class UserSession
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public static long UserId
        {
            get
            {
                long sessionUserId;
                long.TryParse(HttpContext.Current.User.Identity.Name, out sessionUserId);
                return sessionUserId;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is auntheticated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is auntheticated; otherwise, <c>false</c>.
        /// </value>
        public static bool IsAuntheticated
        {
            get
            {
                return (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
            }
            set
            {
            }
        }
    }
}
