using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApi.Classes
{
    public partial class TypeOfActivity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeOfActivity()
        {
            this.EstateObject = new HashSet<EstateObject>();
        }

        public int IDTypeOfActivity { get; set; }
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstateObject> EstateObject { get; set; }
    }
}
