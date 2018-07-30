namespace NoamIsTheBest.Commands
{
    public interface ICommand
    {
        bool IsRelevant(string userInput);
        string Execute();
    }
}