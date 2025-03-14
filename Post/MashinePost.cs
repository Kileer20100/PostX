namespace PostMashine;

class MashinePostStart
{
    public string Post(string? text)
    {
        return "Processed: " + (text ?? "empty");
    }
}
