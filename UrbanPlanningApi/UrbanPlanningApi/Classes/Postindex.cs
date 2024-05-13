using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApi.Classes
{
    public partial class Postindex
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postindex()
        {
            this.EstateObject = new HashSet<EstateObject>();
        }

        public int IDPostindex { get; set; }
        public string Postindex1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstateObject> EstateObject { get; set; }
    }
}
