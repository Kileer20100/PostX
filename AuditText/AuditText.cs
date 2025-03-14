using System;
using System.Linq;
using System.Text.RegularExpressions;
using PostMashine;

namespace AuditText
{
    class Audit
    {
        public string AuditTextCeker(string? text)
        {
            MashinePostStart post = new MashinePostStart();

            // Перевірка, чи є букви
            // Checking if there are letters
            bool containsLetter = (text ?? " ").Any(char.IsLetter);

            // Перевірка, чи є пробіли
            // Checking if there are spaces
            bool containsSpace = (text ?? " ").Contains(" ");

            // Перевірка, чи є нулі
            // Checking if there are zeros
            bool containsZero = (text ?? " ").Contains("0");

            // Перевірка, чи є одиниці
            // Checking if there are ones
            bool containsOne = (text ?? " ").Contains("1");

            // Перевіряє на наявність буквених символів
            // Checks if there are any letter characters
            if (containsLetter)
            {
                return "PostX: is not able to work with letters";
            }
            // Перевіряє на наявність пробілів
            // Checks if there are spaces
            else if (containsSpace)
            {
                return "PostX: does not allow spaces in input values";
            }
            // Перевіряє, чи є символи, які не є 0, 1, <, -, >, ?
            // Checks if there are characters that are not 0, 1, <, -, >, ?
            else if ((text ?? " ").Any(c => c != '0' && c != '1' && c != '<' && c != '-' && c != '>' && c != '?'))
            {
                return "PostX: does not allow numbers greater than 1 or less than 0";
            }
            // Перевіряє, чи є нулі або одиниці
            // Checks if there are zeros or ones
            else if (containsZero || containsOne)
            {
                return post.Post(text);
            }
            else
            {
                return "PostX: Unknown error while validating data";
            }
        }
    }
}
