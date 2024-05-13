using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial class Format
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Format()
        {
            this.EstateObject = new HashSet<EstateObject>();
        }

        public int IDFormat { get; set; }
        public string FormatTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstateObject> EstateObject { get; set; }
    }
}
