namespace IndexSystem
{
    // Utility class for common functions
    internal class Utils
    {
        // Truncate the hash value to 6 digits using modulo arithmetic
        public static string GetShortHash(int hashCode)
        {
            int truncatedHash = Math.Abs(hashCode) % 1000000;
            return truncatedHash.ToString("D6");
        }

        // Check if a file exists at the specified path and create it if it doesn't exist
        public static bool CheckIfExists(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
                Console.WriteLine($"File {path} did not exist, so new one was created");
                return true;
            }
            else
            {
                Console.WriteLine($"File {path} already exists. Rewriting");
                return false;
            }


        }
    }
}
