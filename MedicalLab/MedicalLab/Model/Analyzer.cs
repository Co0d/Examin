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
    
    public partial class Analyzer
    {
        public int id { get; set; }
        public int blood { get; set; }
        public int patient { get; set; }
        public string barcode { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual patients patients { get; set; }
    }
}
