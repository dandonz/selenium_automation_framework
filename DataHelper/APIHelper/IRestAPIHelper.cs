using System.Collections.Generic;
namespace DataHelper
{
    public interface IRestAPIHelper
    {
        string GetData(Dictionary<string, string> pairparams);
    }
}
