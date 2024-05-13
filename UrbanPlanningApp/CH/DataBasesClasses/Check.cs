using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial class Check
    {
        public int IDCheck { get; set; }
        public System.DateTime DateOfTheSale { get; set; }
        public decimal FullCost { get; set; }
        public int IDEmployee { get; set; }
        public int IDClient { get; set; }
        public int IDEstateObject { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual EstateObject EstateObject { get; set; }
    }
}
