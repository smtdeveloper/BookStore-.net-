namespace WebApi.Services 
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine(" [DB Log : ] " + message);
        }
    }
}