using System.IO;
using System.Threading.Tasks;

namespace ProjetGroupe
{
    public interface ISave
    {
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
    }
}

