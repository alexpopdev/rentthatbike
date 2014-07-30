using RentThatBike.Web.ServiceModel.Types;
using ServiceStack;

namespace RentThatBike.Web.ServiceModel
{
    [Route("/bicycles/{Id}", "GET")]
    public class GetBicycle : IReturn<Bicycle>
    {
        public int Id { get; set; }
    }
}