using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApi.Classes
{
    public partial class EstatePhoto
    {
        public int IDEstatePhoto { get; set; }
        public string PhotoPath { get; set; }
        public int IDEstateObject { get; set; }
        public int IDEmployee { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EstateObject EstateObject { get; set; }
    }
}
