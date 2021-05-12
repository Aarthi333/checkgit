using System.Runtime.InteropServices;
using System;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("31a2fd90-e4ee-4f30-8494-2115f857f759")]

namespace DAY_20.Models
{
    public class Comment
    {
        //public string RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public int PostId { get; set; }
        public int Id { get; set; }
        public string CommenText { get; set; }
    }
}
