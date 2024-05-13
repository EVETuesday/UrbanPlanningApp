using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Check = new HashSet<Check>();
            this.EstatePhoto = new HashSet<EstatePhoto>();
        }

        public int IDEmployee { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string PasportSeries { get; set; }
        public string PasportNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IDPost { get; set; }
        public int IDGender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check> Check { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Post Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstatePhoto> EstatePhoto { get; set; }
    }
}
