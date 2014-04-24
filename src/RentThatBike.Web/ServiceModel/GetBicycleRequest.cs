using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.ServiceHost;

namespace RentThatBike.Web.ServiceModel
{
    [Route("/bicycles/{Id}", "GET")]
    public class GetBicycleRequest : IReturn<Bicycle>
    {
        public int Id { get; set; }
    }
}