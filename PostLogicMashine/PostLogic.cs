using System;
using System.Collections.Generic;

namespace PostLogicMashine
{
    class PostMachine
    {
        private char[] ribbon; // Лента / Tape
        private int head; // Вказівник на осередок стрічки / Head pointer for the tape cell
        private Dictionary<string, (char symbol, int move, string nextState)> transitions; // Перехід (символ, рух, наступний стан) / Transitions (symbol, movement, next state)
        private string currentState; // Поточний стан машини / Current state of the machine
        public List<string> answerPost = new List<string>(); // Список для зберігання станів стрічки / List to store the tape states

        // Конструктор машини Поста / PostMachine constructor
        public PostMachine(int ribbonLength)
        {
            ribbon = new char[ribbonLength];
            head = ribbonLength / 2; // Починаємо з середини стрічки / Start from the middle of the tape
            Array.Fill(ribbon, '0'); // Ініціалізуємо стрічку нулями / Initialize the tape with zeros
            currentState = "q0"; // Початковий стан машини / Initial state of the machine

            // Перехід: {Поточний стан + Символ, (Новий символ, Рух, Наступний стан)} / Transitions: {Current state + Symbol, (New symbol, Movement, Next state)}
            transitions = new Dictionary<string, (char, int, string)>
            {
                { "q0,0", ('1', 1, "q1") }, // У стані q0, якщо 0, записуємо 1, рухаємо вправо і переходимо до q1 / In state q0, if 0, write 1, move right, and transition to q1
                { "q0,1", ('0', -1, "q2") }, // У стані q0, якщо 1, записуємо 0, рухаємо вліво і переходимо до q2 / In state q0, if 1, write 0, move left, and transition to q2
                { "q1,0", ('1', 1, "q1") }, // У стані q1, якщо 0, записуємо 1, рухаємо вправо і залишаємося в q1 / In state q1, if 0, write 1, move right, and stay in q1
                { "q1,1", ('0', 1, "q0") }, // У стані q1, якщо 1, записуємо 0, рухаємо вправо і переходимо до q0 / In state q1, if 1, write 0, move right, and transition to q0
                { "q2,0", ('0', -1, "q3") }, // У стані q2, якщо 0, записуємо 0, рухаємо вліво і переходимо до q3 / In state q2, if 0, write 0, move left, and transition to q3
                { "q2,1", ('1', -1, "q1") }, // У стані q2, якщо 1, записуємо 1, рухаємо вліво і переходимо до q1 / In state q2, if 1, write 1, move left, and transition to q1
                { "q3,0", ('1', 1, "q1") }, // У стані q3, якщо 0, записуємо 1, рухаємо вправо і переходимо до q1 / In state q3, if 0, write 1, move right, and transition to q1
                { "q3,1", ('0', 1, "q0") }  // У стані q3, якщо 1, записуємо 0, рухаємо вправо і переходимо до q0 / In state q3, if 1, write 0, move right, and transition to q0
            };
        }

        // Записуємо символ в поточну клітинку і рухаємо головку / Write symbol to the current cell and move the head
        private void Write(char symbol)
        {
            ribbon[head] = symbol; // Записуємо символ в поточну клітинку / Write the symbol to the current cell
        }

        // Рухаємо головку вправо / Move the head to the right
        private void MoveRight()
        {
            head++;
            if (head >= ribbon.Length)
            {
                Array.Resize(ref ribbon, ribbon.Length * 2); // Збільшуємо довжину стрічки / Resize the tape
            }
        }

        // Рухаємо головку вліво / Move the head to the left
        private void MoveLeft()
        {
            head--;
            if (head < 0)
            {
                Array.Resize(ref ribbon, ribbon.Length * 2); // Збільшуємо довжину стрічки / Resize the tape
                Array.Copy(ribbon, 0, ribbon, ribbon.Length / 2, ribbon.Length / 2); // Переміщаємо стрічку / Shift the tape
                head = ribbon.Length / 2;
            }
        }

        // Виконання одного кроку машини Поста / Perform one step of the Post machine
        public bool Step()
        {
            string currentSymbol = ribbon[head].ToString();
            string transitionKey = $"{currentState},{currentSymbol}";

            if (transitions.ContainsKey(transitionKey))
            {
                var transition = transitions[transitionKey];
                Write(transition.symbol);

                // Рухаємо головку / Move the head
                if (transition.move == 1) MoveRight();
                else if (transition.move == -1) MoveLeft();

                currentState = transition.nextState; // Переходимо до наступного стану / Transition to the next state
                return true;
            }
            else
            {
                return false; // Немає можливого переходу, машина зупинена / No possible transition, the machine halts
            }
        }

        // Запуск машини Поста / Run the Post machine
        public void Run()
        {
            Console.WriteLine("Машина Поста працює... / The Post machine is running...");
            while (Step()) // Поки є переходи / While there are transitions
            {
                answerPost.Add(PrintTape());
            }

            Console.WriteLine("Машина Поста завершила виконання. / The Post machine has finished execution. " + PrintTape());
            answerPost.Add(PrintTape());
        }

        // Виведення стану стрічки / Output the current state of the tape
        public string PrintTape()
        {
            return new string(ribbon);
        }

        // Встановлення стану машини / Set the machine's state
        public void SetState(string state)
        {
            currentState = state;
        }

        // Встановлення значення на стрічці / Set value on the tape
        public void SetCell(int position, char value)
        {
            if (position >= 0 && position < ribbon.Length)
            {
                ribbon[position] = value;
            }
        }
    }

    class PostMachineMain
    {
        public List<string> StartMainPostLogicMashine(string number)
        {
            Console.WriteLine(number);

            // Перетворюємо число на рядок / Convert the number to a string
            string numberStr = number.ToString();

            // Створюємо список для зберігання символів / Create a list to store the characters
            List<char> digits = new List<char>();

            // Проходимо по кожній цифрі в рядку і додаємо в список як символ / Loop through each digit in the string and add it to the list as a character
            foreach (char c in numberStr)
            {
                digits.Add(c); // додаємо символ / Add the character
            }

            var machine = new PostMachine(digits.Count + 1); // Створюємо машину Поста / Create the Post machine
            for (int i = 0; i < digits.Count; i++)
            {
                machine.SetCell(i, digits[i]);
            }

            // Запуск машини / Run the machine
            machine.Run();
            return machine.answerPost;
        }
    }
}
