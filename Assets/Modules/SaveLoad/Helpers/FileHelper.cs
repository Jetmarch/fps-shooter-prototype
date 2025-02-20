using System.IO;
using System.Text;

namespace Helpers
{
    public static class FileHelper
    {
        public static void WriteToFile(string filePath, string content)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            
            using (var stream = File.Open(filePath, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(content);
                }
            }
        }

        public static string ReadAllFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return string.Empty;
            
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = reader.ReadToEnd();
                    return content;
                }
            }
        }
    }
}