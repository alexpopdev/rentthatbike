using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace RentThatBike.WebServices
{
    [Route("/news", "GET")]
    public class GetNews : IReturn<List<NewsItem>>
    {
    }
}