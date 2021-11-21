namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if(args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Path required, please use it like this: concatpath {your_path_here}");
            }

            var pathToAdd = args[0];

            var currentPathValue = GetEnvironmentVariable("Path");
            
            var newPath = currentPathValue != null 
                ? $"{currentPathValue};{pathToAdd}"
                : pathToAdd;

            Environment.SetEnvironmentVariable("Path", newPath, EnvironmentVariableTarget.User);
        }

        public static string? GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
            return value;
        }
    }
}