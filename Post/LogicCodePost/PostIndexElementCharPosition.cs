namespace PostIndexElementCharPosition
{
    class PostIdexGive
    {
        // Метод для отримання індексів і обробки тексту
        // Method for obtaining indices and processing the text
        public (List<string>,List<int>,List<int>) PostGetIndex(string? textAudit)
        {
            string? text = textAudit; 
            List<string> result = new List<string>();  // Список для зберігання результатів //List to store results
            List<int> positions = new List<int>();    // Список для зберігання позицій символів //List for storing character positions
            List<int> indexElement = new List<int>(); // Список для зберігання індексів елементів //List for storing element indices

            // 1 = Знак '->'  // 1 = sign '->' 
            // 2 = Знак '<-'  // 2 = sign '<-'
            // 3 = Знак '-1>' // 3 = sign '-1>'
            // 4 = Знак '<1-' // 4 = sign '<1-'
            // 5 = Знак '-0>' // 5 = sign '-0>'
            // 6 = Знак '<0-' // 6 = sign '<0-'
            // -1 = Знак '?' // -1 = sign '?'
            // 10 = Знак '[1], [0]' // 10 = sign '[1], [0]'
            int currentPos = 0;  // Поточна позиція у тексті
            // Current position in the text

            while (currentPos < (text ?? "").Length)
            {
                // Якщо поточний символ є цифрою
                // If the current symbol is a digit
                if (char.IsDigit((text ?? "")[currentPos]))
                {
                    string number = "";
                    while (currentPos < (text ?? "").Length && char.IsDigit((text ?? "")[currentPos]))
                    {
                        number += (text ?? "")[currentPos];
                        currentPos++;
                    }
                    result.Add(number);      // Додаємо до результату
                    positions.Add(currentPos); // Додаємо позицію
                    indexElement.Add(0);      // Індекс елемента 0
                    // Add to result, add position and index element 0
                }

                // Обробка кожного конкретного знака
                // Handling each specific sign
                else if ((text ?? "").Substring(currentPos).StartsWith("->"))
                {
                    string sign = (text ?? "").Substring(currentPos, 2);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 2;
                    indexElement.Add(1);  // Індекс для знаку '->'
                    // Index for the sign '->'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("<-"))
                {
                    string sign = (text ?? "").Substring(currentPos, 2);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 2;
                    indexElement.Add(2);  // Індекс для знаку '<-'
                    // Index for the sign '<-'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("-1>"))
                {
                    string sign = (text ?? "").Substring(currentPos, 3);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 3;
                    indexElement.Add(3);  // Індекс для знаку '-1>'
                    // Index for the sign '-1>'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("<1-"))
                {
                    string sign = (text ?? "").Substring(currentPos, 3);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 3;
                    indexElement.Add(4);  // Індекс для знаку '<1-'
                    // Index for the sign '<1-'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("-0>"))
                {
                    string sign = (text ?? "").Substring(currentPos, 3);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 3;
                    indexElement.Add(5);  // Індекс для знаку '-0>'
                    // Index for the sign '-0>'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("<0-"))
                {
                    string sign = (text ?? "").Substring(currentPos, 3);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 3;
                    indexElement.Add(6);  // Індекс для знаку '<0-'
                    // Index for the sign '<0-'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("[1]"))
                {
                    string sign = (text ?? "").Substring(currentPos, 3);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 3;
                    indexElement.Add(10);  // Індекс для знаку '[1]'
                    // Index for the sign '[1]'
                }
                else if ((text ?? "").Substring(currentPos).StartsWith("[0]"))
                {
                    string sign = (text ?? "").Substring(currentPos, 3);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 3;
                    indexElement.Add(-10);  // Індекс для знаку '[0]'
                    // Index for the sign '[0]'
                }
                
                else if ((text ?? "").Substring(currentPos).StartsWith("!"))
                {
                    string sign = (text ?? "").Substring(currentPos, 1);
                    result.Add(sign);
                    positions.Add(currentPos);
                    currentPos += 1;
                    indexElement.Add(-1);  // Індекс для знаку '!'
                    // Index for the sign '!'
                }
                else
                {
                    currentPos++;  // Пропускаємо символ
                    // Skip the character
                }
            }


            return (result, positions, indexElement) ; // Повертає повідомлення про обробку
            // Return a processing message
        }
    }
}
