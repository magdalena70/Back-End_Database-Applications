//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameTypes
    {
        public GameTypes()
        {
            this.Games = new HashSet<Games>();
            this.Items = new HashSet<Items>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> BonusStatsId { get; set; }
    
        public virtual ICollection<Games> Games { get; set; }
        public virtual Statistics Statistics { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
