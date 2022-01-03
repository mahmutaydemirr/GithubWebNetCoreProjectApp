using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCoreProjectApp.Services
{
    public class PasswordGeneratorService : IPasswordGenerator
    {
        string[] normalChars = { "A", "a", "B", "b", "C", "c", "D", "d", "e", "E", "f", "F", "g", "G", "h", "H", "k", "K", "l", "L", "m", "M", "n", "N", "o", "O", "p", "P", "r", "R", "s", "S", "i", "I", "t", "T", "u", "U", "v", "V", "y", "Y", "z", "Z", "w", "W", "x", "X", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "?", "_", "!", "-", "." };

        string[] specialChars = { "?", "_", "-", ".","!" };

        char[] passwordCharArray = new char[0];
        Random random = new Random();

        public string GeneratePassword(int passwordLength, int upperCaseLength, int lowerCaseLength, int specialCharLength, int numericCharLength)
        {
            passwordCharArray = new char[0];


            if (lowerCaseLength + upperCaseLength + specialCharLength + numericCharLength != passwordLength)
            {
                return "";
            }
            else
            {


                for (int i = 0; i < passwordLength; i++)
                {

                    bool isUpperCase = false;
                    bool isLowerCase = false;
                    bool isNumeric = false;
                    bool isSpecialChar = false;

                    int randomNumber = random.Next(0, normalChars.Length);
                    char selectedChar = char.Parse(normalChars[randomNumber]);

                    if (char.IsNumber(selectedChar))
                    {
                        isNumeric = true;
                    }
                    else if (char.IsUpper(selectedChar))
                    {
                        isUpperCase = true;
                    }
                    else if (char.IsLower(selectedChar))
                    {
                        isLowerCase = true;
                    }
                    else if (specialChars.Contains(selectedChar.ToString()))
                    {
                        isSpecialChar = true;
                    }

                    int lowerCaseCharTotal = 0;
                    int upperCaseCharTotal = 0;
                    int specialCharTotal = 0;
                    int numericTotal = 0;

                    for (int j = 0; j < passwordCharArray.Length; j++)
                    {

                        if (char.IsNumber(passwordCharArray[j]))
                        {
                            numericTotal++;
                        }
                        else if (char.IsUpper(passwordCharArray[j]))
                        {
                            upperCaseCharTotal++;
                        }
                        else if (char.IsLower(passwordCharArray[j]))
                        {
                            lowerCaseCharTotal++;
                        }
                        else if (specialChars.Contains(passwordCharArray[j].ToString()))
                        {
                            specialCharTotal++;

                        }

                    }

                    if (lowerCaseCharTotal < lowerCaseLength && isLowerCase)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }
                    else if (upperCaseCharTotal < upperCaseLength && isUpperCase)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);

                    }
                    else if (specialCharTotal < specialCharLength && isSpecialChar)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }
                    else if (numericTotal < numericCharLength && isNumeric)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }

                return new string(passwordCharArray);
            }


            
        }

    }
}        