using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Check = new HashSet<Check>();
        }

        public int IDClient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public string BirthdaySTR { get { return Birthday.ToShortDateString(); }}
        public string Phone { get; set; }
        public bool IsLegalEntity { get; set; }
        public string PasportSeries { get; set; }
        public string PasportNumber { get; set; }
        public string CompanyTitle { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public string PaymentAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public string BIK { get; set; }
        public int IDGender { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName {
            get {
                if (IsLegalEntity)
                {
                    return $"{CompanyTitle}";
                }
                else if(string.IsNullOrEmpty(FirstName))
                {
                    return $"UrbanPlanningCompany";
                }
                else
                {
                    return $"{LastName} {FirstName} {Patronymic}";
                }
            }
            
        }
                
                

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check> Check { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
