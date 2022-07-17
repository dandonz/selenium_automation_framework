using DataHelper; 
using System.IO;
using System.Collections.Generic; 

namespace DataHelper
{
    /// <summary>
    /// This class is used to read and write data from/to txt file. 
    /// </summary>
    public class TextFileHelper : ITextFileHelper
    {
        public List<string> ReadData(string file)
        {
            List<string> lines = new();
            using (StreamReader sr = new(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
        public void WriteData(List<string> data, string file)
        {
            using StreamWriter sw = new(file);
            foreach (string line in data)
            {
                sw.WriteLine(line);
            }
        }
    }

}
