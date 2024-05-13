using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial class EstateObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstateObject()
        {
            this.Check = new HashSet<Check>();
            this.EstatePhoto = new HashSet<EstatePhoto>();
            this.EstateRelation = new HashSet<EstateRelation>();
            this.EstateRelation1 = new HashSet<EstateRelation>();
            this.FlatRelation = new HashSet<FlatRelation>();
            this.FlatRelation1 = new HashSet<FlatRelation>();
        }

        public int IDEstateObject { get; set; }
        public decimal Square { get; set; }
        public decimal Price { get; set; }
        public System.DateTime DateOfDefinition {  get; set; }
        public System.DateTime DateOfApplication { get; set; }
        public string DateOfDefinitionSTR { get { return DateOfDefinition.ToShortDateString(); } }
        public string DateOfApplicationSTR { get {return DateOfApplication.ToShortDateString(); } }
        public int Number { get; set; }
        public string Adress { get; set; }
        public int IDPostIndex { get; set; }
        public int IDTypeOfActivity { get; set; }
        public int IDFormat { get; set; }
        public string MainPhoto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check> Check { get; set; }
        public virtual Format Format { get; set; }
        public virtual Postindex Postindex { get; set; }
        public virtual Client OwnerClient { get; set; }
        public virtual TypeOfActivity TypeOfActivity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstatePhoto> EstatePhoto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstateRelation> EstateRelation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstateRelation> EstateRelation1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlatRelation> FlatRelation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlatRelation> FlatRelation1 { get; set; }
    }
}
