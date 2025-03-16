
namespace PostCalculation;

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
    return (result ?? new List<string>()).Count.ToString();


    }
}