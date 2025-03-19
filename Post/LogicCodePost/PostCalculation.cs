
namespace PostCalculation;

class PostResult{
    private int search;
    List<int> numberConver = new List<int>();
    private const int START_INDEX = 10;
    public string PostCalcularionResult(List<string>? result,List<int>? positions,List<int>? indexElement){

    if (result == null || positions == null || indexElement == null || result.Count != positions.Count || result.Count != indexElement.Count)
    {
        
        return "PostX: Lists have different lengths!";
    }



    for (int i = 0; i < result.Count; i++)
    {
        if(indexElement[i] == 10){
            
            this.search = positions[i];
        }
    }
    Console.WriteLine(this.search);
    int sumator = 0;
    for (int i = 0; i < result.Count; i++)
    {
        if (this.search < 0 )
        {
            return "PostX: no start [1] [0]";
        }


        //Береобразования стрига в инт и запись єто в лист с кждим новим елементом
        if (indexElement[i] == 0)
        {
            
            foreach (char c in result[i])
            {
                if (Char.IsDigit(c))  // Проверяем, является ли символ цифрой
                {
                    int number = (int)Char.GetNumericValue(c);  // Преобразуем символ в число
                    numberConver.Add(number);  // Добавляем число в список
                }
                
            }
            if (i + 1 < result.Count)
            {
                // Проверяем, если следующий элемент равен "[0]" или "[1]"
                if (result[i + 1] == "[0]")
                {
                    numberConver.Add(0);  // Добавляем 0
                    sumator+=2;
                }
                else if (result[i + 1] == "[1]")
                {
                    numberConver.Add(1);  // Добавляем 1
                    sumator+=2;
                }
            }
            
        }
        if (indexElement[i] == -1)
        {
            break;
        }

        if (indexElement[i] == 1 || indexElement[i] == 2)
        {
            sumator += 2;
        }
        else if (indexElement[i] == 3 || indexElement[i] == 4 || indexElement[i] == 5 || indexElement[i] == 6)
        {
            sumator += 3;
        }



    }
    int a = 0;

    for (int i = 0; i < positions.Count; i++)
    {
        if (indexElement[i] == 10 || indexElement[i] == -10)
        {
            a = positions[i];
        }
    }
    
    Console.WriteLine("ответ = "+numberConver[a]);
    
    Console.WriteLine(String.Join("", numberConver) + "\nSumator:" + sumator + "\n" + -sumator);
 

    return "PostCalculation Result";
    }

}

class RunPostCulculation{

    public string Start(List<string>? result,List<int>? positions,List<int>? indexElement){

    
    if (result == null || positions == null || indexElement == null || result.Count != positions.Count || result.Count != indexElement.Count)
    {
        
        return "PostX: Lists have different lengths!";
    }
    // Виводимо результат для кожного символу
    // Output result for each symbol
    for (int i = 0; i < result.Count; i++)
    {
        Console.WriteLine($"Символ: {result[i]}, Позиція: {positions[i]}, Індекс елемента: {indexElement[i]}");
        // Output symbol, position, and index element
    }
    PostResult res = new PostResult();

    
    return res.PostCalcularionResult(result,positions,indexElement);


    }
}