using System.Collections.Generic; 
namespace DataHelper
{
    public interface ITextFileHelper
    {
        public List<string> ReadData(string file);
        public void WriteData(List<string> data, string file);
    }
}
