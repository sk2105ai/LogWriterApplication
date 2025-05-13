namespace LogWriterApp
{
    internal static class ClsWriteLogsHelpers
    {

        public static string ChangeLogFilePath(string currentPath)
        {
            try
            {
                Console.WriteLine("\n=== Change Log File Path ===");
                Console.WriteLine($"Current path: {currentPath}");
                Console.Write("Enter new log file path: ");

                string newPath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newPath))
                {
                    Console.WriteLine("Path cannot be empty. Using the current path.");
                    return currentPath;
                }

                try
                {
                    // Test if the path is valid
                    string directory = Path.GetDirectoryName(newPath);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        Console.WriteLine($"Directory doesn't exist. It will be created when you write the first log.");
                    }

                    Console.WriteLine($"Log file path changed to: {newPath}");
                    return newPath;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid path: {ex.Message}");
                    Console.WriteLine("Using the previous path.");
                    return currentPath;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error in changing log path: {ex.Message}");
                return currentPath;
            }
        }
        public static void WriteLogMessage(string logFilePath)
        {
            try
            {
                // Get log message from user
                Console.WriteLine("\n=== Write Log Message ===");
                Console.Write("Enter your log message: ");
                string message = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine("Log message cannot be empty.");
                    return;
                }

                // Get log level
                Console.WriteLine("\nSelect log level:");
                Console.WriteLine("1. INFO");
                Console.WriteLine("2. WARNING");
                Console.WriteLine("3. ERROR");
                Console.WriteLine("4. DEBUG");
                Console.Write("\nChoice (default is INFO): ");

                string levelChoice = Console.ReadLine();
                string logLevel;

                switch (levelChoice)
                {
                    case "2":
                        logLevel = "WARNING";
                        break;
                    case "3":
                        logLevel = "ERROR";
                        break;
                    case "4":
                        logLevel = "DEBUG";
                        break;
                    default:
                        logLevel = "INFO";
                        break;
                }

                // Format the log entry
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string logEntry = $"[{timestamp}] [{logLevel}] {message}";

                // Create directory if it doesn't exist
                string directory = Path.GetDirectoryName(logFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write to log file
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }

                Console.WriteLine($"Log message successfully written to {logFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing log: {ex.Message}");
            }
        }
    }
}