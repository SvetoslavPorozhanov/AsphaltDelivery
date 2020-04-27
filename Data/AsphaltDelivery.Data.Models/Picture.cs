using AsphaltDelivery.Data.Common.Models;

namespace AsphaltDelivery.Data.Models
{
    public class Picture : BaseDeletableModel<int>
    {
        public string Uri { get; set; }
    }
}
