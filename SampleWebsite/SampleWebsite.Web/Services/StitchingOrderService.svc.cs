using SampleWebsite.Business;
using SampleWebsite.Model;
using SampleWebsite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SampleWebsite.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StitchingOrderService
    {
        #region Global Variables

        StitchingOrderComponent stitchingOrderComponent = new StitchingOrderComponent();
        StitchingTypeComponent stitchingTypeComponent = new StitchingTypeComponent();
        //StitchingOrderStatusComponent stitchingOrderStatusComponent = new StitchingOrderStatusComponent();
        StitchingStatusComponent stitchingStatusComponent = new StitchingStatusComponent();

        #endregion

        /// <summary>
        /// Gets the stitching orders.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetStitchingOrders")]
        public List<StitchingOrderModel> GetStitchingOrders()
        {
            try
            {
                if (UserSession.IsAuntheticated)
                {
                    return stitchingOrderComponent.GetStitchingOrders();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the stitching order information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetStitchingOrderInfoById?id={id}")]
        public StitchingOrderModel GetStitchingOrderInfoById(long id)
        {
            try
            {
                if (UserSession.IsAuntheticated)
                {
                    StitchingOrderModel stitchingOrderInfo = new StitchingOrderModel();

                    if (id > 0)
                    {
                        stitchingOrderInfo = stitchingOrderComponent.GetStitchingOrderInfoById(id);
                    }

                    stitchingOrderInfo.StitchingTypes = stitchingTypeComponent.GetStitchingTypes().ToArray();
                    return stitchingOrderInfo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Saves the stitching order.
        /// </summary>
        /// <param name="stitchingOrderInfo">The stitching order information.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SaveStitchingOrder")]
        public bool SaveStitchingOrder(StitchingOrderModel stitchingOrderInfo)
        {
            try
            {
                if (UserSession.IsAuntheticated && UserSession.UserId > 0)
                {
                    if (stitchingOrderInfo.Id == 0)
                    {
                        stitchingOrderInfo.CreatedBy = UserSession.UserId;
                    }

                    return stitchingOrderComponent.SaveStitchingOrder(stitchingOrderInfo);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="stitchingOrderId">The stitching order identifier.</param>
        /// <param name="paidAmount">The paid amount.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "MakePayment")]
        public bool MakePayment(long stitchingOrderId, decimal paidAmount)
        {
            try
            {
                if (UserSession.IsAuntheticated)
                {
                    return stitchingOrderComponent.MakePayment(stitchingOrderId, paidAmount);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
