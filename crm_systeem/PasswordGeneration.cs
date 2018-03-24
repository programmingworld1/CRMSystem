using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm_systeem.Models
{
    class PasswordGeneration
    {
        // Arrays waar een groot aantal letters, nummers en symbolen in worden opgeslagen voor gebruik bij het maken van het wachtwoord.
        char[] Alphabet = new char[26];
        int[] Numbers = new int[10];
        char[] Symbols = new char[10];

        /// <summary>
        /// Genereer een passwoord van 6 karakters lang met tenminste 2 letters, 2 nummers en 2 symbolen. Letters hebben een 50% kans om hoofdletter te zijn. Ook wordt ervoor gezorgd dat er maximaal 2 letters, 2 nummers en 2 symbolen in mogen voorkomen om zo voor een gevarieerd en sterk wachtwoord te zorgen. Return het voltooid wachtwoord.
        /// </summary>
        public string GeneratePassword()
        {
            int alphabetCount = 0;
            int numberCount = 0;
            int symbolCount = 0;

            //Random rngOne = new Random();
            //Random rngTwo = new Random();
            Random rngFour = new Random();
            Random rngFive = new Random();

            string password = "";

            Random rngOne = new Random();
            Random rngTwo = new Random();
            Random rngThree = new Random();

            char temp = ' ';
            for (int i = 0; i < 6; i++)
            {
                int rngInt = rngOne.Next(0, 3);
                int rngIntTwo = rngTwo.Next(0, 2);
                int rngIntThree = rngThree.Next(0, 2);
                if (rngInt == 0 && alphabetCount < 2)
                {
                    if (rngIntTwo == 0)
                    {
                        temp = Alphabet[rngOne.Next(0, 26)];
                        temp = char.ToUpper(temp);
                    }
                    else
                    {
                        temp = Alphabet[rngOne.Next(0, 3)];
                    }

                    password += temp;
                    alphabetCount++;
                }

                else if (rngInt == 1 && numberCount < 2)
                {
                    password += Numbers[rngOne.Next(0, 10)];
                    numberCount++;
                }

                else if (rngInt == 2 && symbolCount < 2)
                {
                    password += Symbols[rngOne.Next(0, 10)];
                    symbolCount++;
                }
                else
                {
                    i--;
                }
            }
            return password;
        }

        /// <summary>
        /// Vul de Arrays die nodig zijn bij het maken van het wachtwoord.

        /// </summary>
        private void PopulatePasswordArrays()
        {
            #region Fill the Alphabet array
            Alphabet[0] = 'a';
            Alphabet[1] = 'b';
            Alphabet[2] = 'c';
            Alphabet[3] = 'd';
            Alphabet[4] = 'e';
            Alphabet[5] = 'f';
            Alphabet[6] = 'g';
            Alphabet[7] = 'h';
            Alphabet[8] = 'i';
            Alphabet[9] = 'j';
            Alphabet[10] = 'k';
            Alphabet[11] = 'l';
            Alphabet[12] = 'm';
            Alphabet[13] = 'n';
            Alphabet[14] = 'o';
            Alphabet[15] = 'p';
            Alphabet[16] = 'q';
            Alphabet[17] = 'r';
            Alphabet[18] = 's';
            Alphabet[19] = 't';
            Alphabet[20] = 'u';
            Alphabet[21] = 'v';
            Alphabet[22] = 'w';
            Alphabet[23] = 'x';
            Alphabet[24] = 'y';
            Alphabet[25] = 'z';
            #endregion

            #region Fill the Numbers array
            for (int i = 0; i < 10; i++)
            {
                Numbers[i] = i;
            }
            #endregion

            #region Fill the Symbols array
            Symbols[0] = '!';
            Symbols[1] = '@';
            Symbols[2] = '#';
            Symbols[3] = '$';
            Symbols[4] = '%';
            Symbols[5] = '^';
            Symbols[6] = '&';
            Symbols[7] = '*';
            Symbols[8] = '-';
            Symbols[9] = '+';
            #endregion
        }

        public PasswordGeneration()
        {
            PopulatePasswordArrays();
        }
    }
}
