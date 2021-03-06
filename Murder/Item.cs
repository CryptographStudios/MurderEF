//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Murder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Equipments = new HashSet<Equipment>();
        }
    
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> SellValue { get; set; }
        public Nullable<int> BuyValue { get; set; }
        public Nullable<int> BuyCurrencyId { get; set; }
        public int ItemTypeId { get; set; }
        public bool Active { get; set; }
        public Nullable<long> StatsId { get; set; }
    
        public virtual CurrencyType CurrencyType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual Stat Stat { get; set; }
    }
}
