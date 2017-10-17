using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentThatBike.Web.ServiceModel.Types
{
    [Flags]
    public enum BicycleTypes
    {
         RoadBike = 1,
         MountainBike = 2,
         UrbanBike = 4,
         ChildrenBike = 8
    }
}