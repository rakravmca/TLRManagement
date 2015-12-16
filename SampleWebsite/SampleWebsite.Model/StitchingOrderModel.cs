using System;
using System.Runtime.Serialization;

namespace SampleWebsite.Model
{
    [DataContract]
    public class StitchingOrderModel
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public short StitchingTypeId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        public DateTime DateOfOrder { get; set; }

        [DataMember]
        public string DateOfOrderString
        {
            get
            {
                return string.Format("{0:MM/dd/yyyy}", DateOfOrder);
            }
            set
            {
                DateOfOrder = !string.IsNullOrWhiteSpace(value) ? DateTime.Parse(value) : DateTime.Now;
            }
        }

        public DateTime? DateOfDelivery { get; set; }

        [DataMember]
        public string DateOfDeliveryString
        {
            get
            {
                return DateOfDelivery.HasValue ? string.Format("{0:MM/dd/yyyy}", DateOfDelivery) : string.Empty;
            }
            set
            {
                DateOfDelivery = !string.IsNullOrWhiteSpace(value) ? DateTime.Parse(value) : (DateTime?)null;
            }
        }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public long CreatedBy { get; set; }

        [DataMember]
        public Nullable<long> AssignedTo { get; set; }

        [DataMember]
        public Nullable<decimal> PaidAmount { get; set; }

        [DataMember]
        public Nullable<short> StitchingStatusId { get; set; }

        [DataMember]
        public StitchingTypeModel StitchingType { get; set; }

        [DataMember]
        public UserModel CreatedByUser { get; set; }

        [DataMember]
        public UserModel AssignedToUser { get; set; }

        //[DataMember]
        //public StitchingOrderStatusModel[] StitchingOrderStatuses { get; set; }

        [DataMember]
        public StitchingTypeModel[] StitchingTypes { get; set; }

        [DataMember]
        public decimal TotalAmount { get; set; }
    }
}
