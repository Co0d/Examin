//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalLab.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class patients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public patients()
        {
            this.Analyzer = new HashSet<Analyzer>();
        }
    
        public int id { get; set; }
        public string login { get; set; }
        public string pwd { get; set; }
        public string full_name { get; set; }
        public int passport_s { get; set; }
        public int passport_n { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int id_Company { get; set; }
        public string social_type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Analyzer> Analyzer { get; set; }
        public virtual Company Company { get; set; }
    }
}