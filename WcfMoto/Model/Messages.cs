//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfMoto.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public int IdMessage { get; set; }
        public int IdAnnouncement { get; set; }
        public int IdUser { get; set; }
        public string Message { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Announcements Announcements { get; set; }
        public virtual Users Users { get; set; }
    }
}
