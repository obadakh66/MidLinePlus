//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace midLine
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppointmentRequest
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public string Time { get; set; }
        public Nullable<bool> isAccepted { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}