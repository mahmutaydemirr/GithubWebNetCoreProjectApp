using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCoreProjectApp.Services
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int passwordLength, int upperCaseLength, int lowerCaseLength, int specialCharLength, int numericCharLength);
    }
}
