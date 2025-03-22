using System;
using System.Collections.Generic;

namespace PostLogicMashine;
class PostMachine
{
    private char[] ribbon; // Лента
    private int head; // Указатель на ячейку ленты
    private Dictionary<string, (char symbol, int move, string nextState)> transitions; // Переходы (символ, движение, следующее состояние)
    private string currentState; // Текущее состояние машины

    public PostMachine(int ribbonLength)
    {
        ribbon = new char[ribbonLength];
        head = ribbonLength / 2; // Начинаем с середины ленты
        Array.Fill(ribbon, '0'); // Инициализируем ленту нулями
        currentState = "q0"; // Начальное состояние машины
        

        transitions = new Dictionary<string, (char, int, string)>
        {
            // Пример переходов: {Текущее состояние + Символ, (Новый символ, Движение, Следующее состояние)}
            { "q0,0", ('1', 1, "q1") }, // В состоянии q0, если 0, записываем 1, двигаем вправо и переходим в q1
            { "q0,1", ('0', -1, "q2") }, // В состоянии q0, если 1, записываем 0, двигаем влево и переходим в q2
            { "q1,0", ('1', 1, "q1") }, // В состоянии q1, если 0, записываем 1, двигаем вправо и остаемся в q1
            { "q1,1", ('0', 1, "q0") }, // В состоянии q1, если 1, записываем 0, двигаем вправо и переходим в q0
            { "q2,0", ('0', -1, "q3") }, // В состоянии q2, если 0, записываем 0, двигаем влево и переходим в q3
            { "q2,1", ('1', -1, "q1") }, // В состоянии q2, если 1, записываем 1, двигаем влево и переходим в q1
            { "q3,0", ('1', 1, "q1") }, // В состоянии q3, если 0, записываем 1, двигаем вправо и переходим в q1
            { "q3,1", ('0', 1, "q0") }  // В состоянии q3, если 1, записываем 0, двигаем вправо и переходим в q0
        };
    }

    // Записываем символ в текущую ячейку и двигаем указатель
    private void Write(char symbol)
    {
        ribbon[head] = symbol; // Записываем символ в текущую ячейку
    }

    // Перемещаем головку вправо
    private void MoveRight()
    {
        head++;
        if (head >= ribbon.Length)
        {
            Array.Resize(ref ribbon, ribbon.Length * 2); // Увеличиваем ленту
        }
    }

    // Перемещаем головку влево
    private void MoveLeft()
    {
        head--;
        if (head < 0)
        {
            Array.Resize(ref ribbon, ribbon.Length * 2); // Увеличиваем ленту
            Array.Copy(ribbon, 0, ribbon, ribbon.Length / 2, ribbon.Length / 2);
            head = ribbon.Length / 2;
        }
    }

    // Выполнение шага машины Поста
    public bool Step()
    {
        string currentSymbol = ribbon[head].ToString();
        string transitionKey = $"{currentState},{currentSymbol}";

        if (transitions.ContainsKey(transitionKey))
        {
            var transition = transitions[transitionKey];
            Write(transition.symbol);

            // Двигаем головку
            if (transition.move == 1) MoveRight();
            else if (transition.move == -1) MoveLeft();

            currentState = transition.nextState; // Переходим в следующее состояние
            return true;
        }
        else
        {
            return false; // Нет возможного перехода, машина остановлена
        }
    }

    // Запуск машины Поста
    public string Run()
    {
        Console.WriteLine("Машина Поста работает...");
        while (Step()) // Пока есть переходы
        {
            Console.WriteLine(PrintTape());
            System.Threading.Thread.Sleep(100); // Задержка между шагами для удобства просмотра
        }

        Console.WriteLine("Машина Поста завершила выполнение.");
        return PrintTape();
    }

    // Вывод состояния ленты
    public string PrintTape()
    {
        return new string(ribbon);
    }

    // Установка состояния машины
    public void SetState(string state)
    {
        currentState = state;
    }

    // Установка значений на ленте
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
    public string StartMainPostLogicMashine(string number)
    {
        
        Console.WriteLine(number);
        // Преобразуем число в строку
        string numberStr = number.ToString();

        // Создаем список для хранения символов
        List<char> digits = new List<char>();

        // Проходим по каждой цифре в строке и добавляем в список как символ
        foreach (char c in numberStr)
        {
            digits.Add(c); // добавляем символ
        }


        var machine = new PostMachine(digits.Count + 1); // Создаем машину поста
        for (int i = 0; i < digits.Count; i++)
        {
            machine.SetCell(i, digits[i]);
        }



        // Запуск машины
        return machine.Run();;
    }
}
