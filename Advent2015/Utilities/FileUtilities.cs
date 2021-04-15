using System.IO;
using System.Text;

namespace MyConsoleApp.Utilities
{
    public class FileUtilities
    {
        public static string ReadTxtToString(string path)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
