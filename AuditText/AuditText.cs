using System;
using System.Linq;
using System.Text.RegularExpressions;
using PostMashine;

namespace AuditText
{
    class Audit
    {
        // Метод AuditTextCeker перевіряє введений текст
        // The method AuditTextCeker checks the input text
        public string AuditTextCeker(string? text)
        {
            // Створюємо екземпляр для запуску машини
            // Create an instance for running the machine
            MashinePostStart post = new MashinePostStart();

            // Перевірка, чи є букви в тексті, та чи це не 'X' або 'V'
            // Checking if there are letters in the text, and making sure they are not 'X' or 'V'
            bool containsLetter = (text ?? "").Any(c => char.IsLetter(c) && c != 'X' && c != 'V');

            // Перевірка, чи є пробіли в тексті
            // Checking if there are spaces in the text
            bool containsSpace = (text ?? " ").Contains(" ");

            // Перевірка, чи є нулі в тексті
            // Checking if there are zeros in the text
            bool containsZero = (text ?? " ").Contains("0");

            // Перевірка, чи є одиниці в тексті
            // Checking if there are ones in the text
            bool containsOne = (text ?? " ").Contains("1");

            // Перевірка на наявність букв
            // Checks for the presence of letters
            if (containsLetter)
            {
                return "PostX: is not able to work with letters"; // Повертаємо повідомлення про помилку
                // Return an error message
            }
            // Перевірка на наявність пробілів
            // Checks for the presence of spaces
            else if (containsSpace)
            {
                return "PostX: does not allow spaces in input values"; // Повертаємо повідомлення про помилку
                // Return an error message
            }
            // Перевірка на наявність символів, які не є 0, 1, <, -, >, ?
            // Checks for characters that are not 0, 1, <, -, >, ?
            else if ((text ?? " ").Any(c => c != '0' && c != '1' && c != '<' && c != '-' && c != '>' && c != '!' && c != '?' && c != 'V' && c != 'X'))
            {
                return "PostX: does not allow numbers greater than 1 or less than 0"; // Повертаємо повідомлення про помилку
                // Return an error message
            }
            // Перевірка на наявність нулів або одиниць
            // Checks for the presence of zeros or ones
            else if (containsZero || containsOne)
            {
                return post.Post(text); // Повертає результат обробки на основі введеного тексту
                // Return the result of processing based on the input text
            }
            else
            {
                return "PostX: Unknown error while validating data"; // Невідома помилка валідації
                // Unknown validation error
            }
        }
    }
}
