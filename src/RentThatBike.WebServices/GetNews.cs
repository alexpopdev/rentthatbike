using System.Collections.Generic;
using ServiceStack;

namespace RentThatBike.WebServices
{
    [Route("/news", "GET")]
    public class GetNews : IReturn<List<NewsItem>>
    {
    }
}