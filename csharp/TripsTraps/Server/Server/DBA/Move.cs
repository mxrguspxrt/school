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
    
    public partial class Move
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int PlayId { get; set; }
        public int UserId { get; set; }
    
        public virtual Play Play { get; set; }
        public virtual User User { get; set; }
    }
}