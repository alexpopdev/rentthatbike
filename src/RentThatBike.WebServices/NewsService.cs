using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace RentThatBike.WebServices
{
    public class NewsService : IService
    {
        public List<NewsItem> Get(GetNews request)
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Created = DateTime.UtcNow.AddDays(-1),
                    Title = "Our sales are up",
                    Content = "Due to unprecedented good weather our sales are up 10% compared to the same period last year."
                },
                new NewsItem
                {
                    Created = DateTime.UtcNow.AddDays(-3),
                    Title = "The green challenge winner",
                    Content = "Out green challenge contest has a winner: Dave Stewart from Accounting!"
                },
                new NewsItem
                {
                    Created = DateTime.UtcNow.AddDays(-4),
                    Title = "New bike version available",
                    Content = "The best selling bike of last year has a new version."
                }
            };
        }
    }
}