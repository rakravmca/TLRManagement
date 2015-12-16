using SampleWebsite.Data;
using SampleWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebsite.Business
{
    public class StitchingOrderComponent
    {

        /// <summary>
        /// Gets the stitching orders.
        /// </summary>
        /// <returns></returns>
        public List<StitchingOrderModel> GetStitchingOrders()
        {
            using (var db = new SampleEntities())
            {
                return db.StitchingOrders.Select(s => new StitchingOrderModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName ?? string.Empty,
                    LastName = s.LastName ?? string.Empty,
                    Email = s.Email ?? string.Empty,
                    Phone = s.Phone ?? string.Empty,
                    DateOfOrder = s.DateOfOrder,
                    DateOfDelivery = s.DateOfDelivery,
                    Quantity = s.Quantity,
                    IsActive = s.IsActive,
                    StitchingTypeId = s.StitchingTypeId,
                    CreatedBy = s.CreatedBy,
                    AssignedTo = s.AssignedTo,
                    StitchingType = new StitchingTypeModel
                    {
                        Id = s.StitchingType.Id,
                        Code = s.StitchingType.Code,
                        Name = s.StitchingType.Name
                    },
                    CreatedByUser = new UserModel
                    {
                        Id = s.CreatedByUser.Id,
                        FirstName = s.CreatedByUser.FirstName,
                        MiddleName = s.CreatedByUser.MiddleName,
                        LastName = s.CreatedByUser.LastName
                    },
                    AssignedToUser = s.AssignedToUser != null ? new UserModel
                    {
                        Id = s.AssignedToUser.Id,
                        FirstName = s.AssignedToUser.FirstName,
                        MiddleName = s.AssignedToUser.MiddleName,
                        LastName = s.AssignedToUser.LastName
                    } : null,
                    PaidAmount = s.PaidAmount ?? 0,
                    TotalAmount = s.Quantity * s.StitchingType.Cost
                }).ToList();
            }
        }

        /// <summary>
        /// Gets the stitching order information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public StitchingOrderModel GetStitchingOrderInfoById(long id)
        {
            using (var db = new SampleEntities())
            {
                return db.StitchingOrders.Where(w => w.Id == id).Select(s => new StitchingOrderModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName ?? string.Empty,
                    LastName = s.LastName ?? string.Empty,
                    Email = s.Email ?? string.Empty,
                    Phone = s.Phone ?? string.Empty,
                    DateOfOrder = s.DateOfOrder,
                    DateOfDelivery = s.DateOfDelivery,
                    Quantity = s.Quantity,
                    IsActive = s.IsActive,
                    StitchingTypeId = s.StitchingTypeId,
                    CreatedBy = s.CreatedBy,
                    AssignedTo = s.AssignedTo,
                    PaidAmount = s.PaidAmount ?? 0,
                    StitchingType = new StitchingTypeModel
                    {
                        Id = s.StitchingType.Id,
                        Code = s.StitchingType.Code,
                        Name = s.StitchingType.Name
                    },
                    CreatedByUser = new UserModel
                    {
                        Id = s.CreatedByUser.Id,
                        FirstName = s.CreatedByUser.FirstName,
                        MiddleName = s.CreatedByUser.MiddleName,
                        LastName = s.CreatedByUser.LastName
                    },
                    AssignedToUser = s.AssignedToUser != null ? new UserModel
                    {
                        Id = s.AssignedToUser.Id,
                        FirstName = s.AssignedToUser.FirstName,
                        MiddleName = s.AssignedToUser.MiddleName,
                        LastName = s.AssignedToUser.LastName
                    } : null
                }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Saves the stitching order.
        /// </summary>
        /// <param name="stitchingOrderInfo">The stitching order information.</param>
        /// <returns></returns>
        public bool SaveStitchingOrder(StitchingOrderModel stitchingOrderInfo)
        {
            using (var db = new SampleEntities())
            {
                StitchingOrder stitchingOrderData;

                if (stitchingOrderInfo.Id == 0)
                {
                    stitchingOrderData = new StitchingOrder
                    {
                        FirstName = stitchingOrderInfo.FirstName,
                        MiddleName = stitchingOrderInfo.MiddleName,
                        LastName = stitchingOrderInfo.LastName,
                        Email = stitchingOrderInfo.Email,
                        Phone = stitchingOrderInfo.Phone,
                        DateOfOrder = DateTime.Now,
                        DateOfDelivery = DateTime.Now.AddDays(7),
                        CreatedBy = stitchingOrderInfo.CreatedBy,
                        StitchingTypeId = stitchingOrderInfo.StitchingType.Id,
                        Quantity = stitchingOrderInfo.Quantity
                    };

                    db.StitchingOrders.Add(stitchingOrderData);

                    if (db.SaveChanges() > 0)
                    {
                        stitchingOrderData.Code = DateTime.Now.Year.ToString() + "-" + stitchingOrderInfo.StitchingType.Code + "-" + stitchingOrderData.Id.ToString();
                    }
                }
                else
                {
                    stitchingOrderData = db.StitchingOrders.Where(w => w.Id == stitchingOrderInfo.Id).SingleOrDefault();

                    if (stitchingOrderData != null)
                    {
                        stitchingOrderData.FirstName = stitchingOrderInfo.FirstName;
                        stitchingOrderData.MiddleName = stitchingOrderInfo.MiddleName;
                        stitchingOrderData.LastName = stitchingOrderInfo.LastName;
                        stitchingOrderData.Email = stitchingOrderInfo.Email;
                        stitchingOrderData.Phone = stitchingOrderInfo.Phone;
                        stitchingOrderData.Quantity = stitchingOrderInfo.Quantity;
                        stitchingOrderData.StitchingTypeId = stitchingOrderInfo.StitchingType.Id;

                        if (db.SaveChanges() > 0)
                        {
                            stitchingOrderData.Code = DateTime.Now.Year.ToString() + "-" + stitchingOrderInfo.StitchingType.Code + "-" + stitchingOrderData.Id.ToString();
                        }
                    }
                }

                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="stitchingOrderId">The stitching order identifier.</param>
        /// <returns></returns>
        public bool RemoveUser(long stitchingOrderId)
        {
            using (var db = new SampleEntities())
            {
                StitchingOrder stitchingOrderData = db.StitchingOrders.Where(w => w.Id == stitchingOrderId).SingleOrDefault();

                if (stitchingOrderData != null)
                {
                    stitchingOrderData.IsActive = false;
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="stitchingOrderId">The stitching order identifier.</param>
        /// <param name="paidAmount">The paid amount.</param>
        /// <returns></returns>
        public bool MakePayment(long stitchingOrderId, decimal paidAmount)
        {
            using (var db = new SampleEntities())
            {
                var stitchingOrderData = db.StitchingOrders.Where(w => w.Id == stitchingOrderId).SingleOrDefault();

                if (stitchingOrderData != null)
                {
                    stitchingOrderData.PaidAmount += paidAmount;
                }

                db.SaveChanges();
                return true;
            }
        }
    }
}
