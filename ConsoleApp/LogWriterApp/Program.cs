using System.Configuration;
using LogWriterApp;
public class ClsProgram
{
    /// <summary>
    /// This is main entry method for application
    /// </summary>
    /// <param name="args">string[]</param>
    /// <CreatedBy>Shahir Khan</CreatedBy>
    /// <CreatedDate>May 02, 2025</CreatedDate>
    static void Main(string[] args)
    {
        try
        {            
            // Display welcome message
            Console.WriteLine("=== Log Writer Application ===");

            // Get the configured log file path from App.config (with fallback)
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"] ?? "log.txt";
            Console.WriteLine($"Current log file path: {logFilePath}");

            // Menu loop
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nPlease select an option: for example for writing log messsages enter 1");
                Console.WriteLine("1. Write a log message");
                Console.WriteLine("2. Change log file path");
                Console.WriteLine("3. Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":                        
                        ClsWriteLogsHelpers.WriteLogMessage(logFilePath);
                        break;
                    case "2":
                        logFilePath = ClsWriteLogsHelpers.ChangeLogFilePath(logFilePath);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the Log Writer Application!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}