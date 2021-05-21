using System.Runtime.InteropServices;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("fb33e1bd-7878-4077-9a4b-e4f0f2eb6a91")]

namespace day25activityClient.Models
{
    public class SBTransaction
    {
        public int TransactionID { get; set; }
        public string TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public float Amount { get; set; }
        public string TransactionType { get; set; }

    }
}

