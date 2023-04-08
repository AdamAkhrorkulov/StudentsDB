namespace Backend.App.Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new Client();
            c.GetStudentsData();
        }
    }
}
