//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string Username { get; set; }
        public string Lab_Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    
        public virtual Lab_Info Lab_Info { get; set; }
    }
}
