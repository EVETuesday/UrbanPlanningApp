using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial class FlatRelation
    {
        public int IDFlatRelation { get; set; }
        public int IDBuildEstate { get; set; }
        public int IDFlatEstate { get; set; }

        public virtual EstateObject EstateObject { get; set; }
        public virtual EstateObject EstateObject1 { get; set; }
    }
}
