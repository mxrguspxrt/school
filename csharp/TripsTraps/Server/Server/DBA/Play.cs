//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.DBA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Play
    {
        public Play()
        {
            this.Move = new HashSet<Move>();
        }
    
        public int Id { get; set; }
        public string State { get; set; }
        public int MoverUserId { get; set; }
    
        public virtual ICollection<Move> Move { get; set; }
    }
}