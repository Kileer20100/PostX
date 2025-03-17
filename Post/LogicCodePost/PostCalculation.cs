
namespace PostCalculation;

class PostResult{
    private int search;
    List<int> numberConver = new List<int>();
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

    for (int i = 0; i < result.Count; i++)
    {
        if (this.search == 0)
        {
            return "PostX: no start [1] [0]";
        }
        //Береобразования стрига в инт и запись єто в лист с кждім новім елементом
        else if (indexElement[i] == 0)
        {
            
            foreach (char c in result[i])
            {
                if (Char.IsDigit(c))  // Проверяем, является ли символ цифрой
                {
                    int number = (int)Char.GetNumericValue(c);  // Преобразуем символ в число
                    numberConver.Add(number);  // Добавляем число в список
                }
            }
                    for (int j = 0; j < numberConver.Count; j++)
        {
            Console.WriteLine(numberConver[j]);
        }
        }
        else if (indexElement[i] == -1)
        {
            break;
        }
        else if (indexElement[i] == -1)
        {
            break;
        }
    }
    


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

    res.PostCalcularionResult(result,positions,indexElement);
    
    return "52";


    }
}