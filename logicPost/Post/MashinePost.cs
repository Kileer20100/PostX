using PostIndexElementCharPosition;
using PostCalculation;
namespace PostMashine;

// Клас, що відповідає за запуск обробки поштових індексів
// Class responsible for initiating the processing of postal indices
class MashinePostStart
{
    // Метод, що приймає текст і передає його на обробку
    // Method that accepts text and sends it for processing
    public string Post(string? textAudit)
    {
        // Створюємо екземпляр класу PostIdexGive для обробки індексів
        // Create an instance of PostIdexGive class to process the indices
        PostIdexGive post = new PostIdexGive();
        
        // Повертаємо результат обробки індексів
        // Return the result of index processing
        (List<string> result,List<int> positions,List<int>indexElement) = post.PostGetIndex(textAudit);

        RunPostCulculation postCulculation = new RunPostCulculation();
        return  postCulculation.Start(result,positions,indexElement);

        
    }
}