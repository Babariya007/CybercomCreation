//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int ContactID { get; set; }
        public int ContactCategoryID { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string FaceBookID { get; set; }
        public string LinkedInID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ProfileImagePath { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual City City { get; set; }
        public virtual ContactCategory ContactCategory { get; set; }
        public virtual Country Country { get; set; }
        public virtual MasterUser MasterUser { get; set; }
        public virtual State State { get; set; }
    }
}
