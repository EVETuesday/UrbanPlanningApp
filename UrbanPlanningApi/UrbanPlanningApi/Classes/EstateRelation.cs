using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApi.Classes
{
    public partial class EstateRelation
    {
        public int IDEstateRelation { get; set; }
        public int IDPlaceEstate { get; set; }
        public int IDBuildingEstate { get; set; }

        public virtual EstateObject EstateObject { get; set; }
        public virtual EstateObject EstateObject1 { get; set; }
    }
}
