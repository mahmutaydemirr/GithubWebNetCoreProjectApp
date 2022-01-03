using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCoreProjectApp.Models
{
    public class GeneratePasswordViewModel
    {
        public int PasswordLength { get; set; }
        public int NumericCharLength { get; set; }
        public int LowerCaseCharLength { get; set; }
        public int UpperCaseCharLength { get; set; }
        public int SpecialCharLength { get; set; }
    }
}
