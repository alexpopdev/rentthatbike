using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace RentThatBike.WebServices
{
    [Route("/feedbacks", "POST, OPTIONS")]
    public class Feedback: IReturn<Feedback>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}