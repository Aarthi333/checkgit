using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("29d9ff4a-619b-4e81-b0b1-28de8e8b2499")]

namespace day24activityClient1.Models
{
    public class SBAccount
    {
        
        public int AccountID { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float CustomerBalance { get; set; }

    }
}
