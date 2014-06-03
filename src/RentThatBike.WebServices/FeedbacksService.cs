using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace RentThatBike.WebServices
{
    public class FeedbacksService : IService
    {
        public Feedback Post(Feedback request)
        {
            request.Id = new Random().Next();
            return request;
        }
    }
}