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
    
    public partial class Equipment
    {
        public Nullable<long> CharacterId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public long UserId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public long ExperienceId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Character Character { get; set; }
        public virtual Item Item { get; set; }
        public virtual Experience Experience { get; set; }
    }
}