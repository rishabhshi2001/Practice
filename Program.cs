using System;

namespace MyCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\91858\Dropbox\PC\Desktop\License.txt";
            string content = "Active Directory<B>5000\nFile server<B>4000\nEMC<B>3000\nSQL Server<B>5000";
            File.WriteAllText(filePath, content);
            long User = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    User += GetData(line);
                }
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            Console.Write(User);
        }

        static int GetData(string content)
        {
            int start = content.IndexOf("<B>") + 3;
            string numberString = content.Substring(start);
            int value = int.Parse(numberString);
            return value;
        }
    }
}