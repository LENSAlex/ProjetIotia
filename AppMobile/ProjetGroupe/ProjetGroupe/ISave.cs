using System.IO;
using System.Threading.Tasks;

namespace ProjetGroupe
{
    /// <summary>
    /// Interface pour Save un document PDF sur le smartphone
    /// </summary>
    public interface ISave
    {
        /// <summary>
        /// Méthode de save et d'ouverture PDF
        /// </summary>
        /// <param name="filename">nom du fichier</param>
        /// <param name="contentType">content-type (application/pdf)</param>
        /// <param name="stream">le fichier sous stream</param>
        /// <returns></returns>
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
        /// <summary>
        /// Méthode pour ouvrir la galerie du smartphone
        /// </summary>
        /// <returns>task</returns>
        Task OpenGallery();
    }
}

