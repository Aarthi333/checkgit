using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("edfcaa10-f9cc-4d6d-a0af-a9ba9fe30b60")]

namespace day24activity.Models
{
    public class SBAccount
    {       
        [Key]
        public int AccountID { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float CustomerBalance { get; set; }
      
    }
}
