using System.Collections.Generic;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack;

namespace RentThatBike.Web.ServiceModel
{
    [Route("/bicycles", "GET")]
    public class GetBicycles : IReturn<List<Bicycle>>
    {
    }
}