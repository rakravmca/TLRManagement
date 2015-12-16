
namespace SampleWebsite.Model
{
    public class StitchingTypeModel
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public StitchingOrderModel[] StitchingOrders { get; set; }
    }
}
