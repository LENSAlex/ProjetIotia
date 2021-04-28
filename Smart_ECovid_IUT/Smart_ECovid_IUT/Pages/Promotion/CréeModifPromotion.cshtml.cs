using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid.Utilisateur;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Promotion;

namespace Smart_ECovid_IUT.Pages.Promotion
{
    public class CréeModifPromotionModel : PageModel
    {
        // private readonly IHttpClientFactory _clientFactory;
        Prof prof;
        public IEnumerable<Prof> DDProf { get; set; }

        public void OnGet()
        {


            Prof.GetProf();
            DDProf = Prof._DDProf;


        }

        public void OnPostEnvoieDonne()
        {
            Formation formation = new Formation();

            formation.IdDepartement = Convert.ToInt32(Request.Form["departement"]);
            formation.AnneePromotion = Convert.ToInt32(Request.Form["annee"]);
            formation.DureeFormation = Convert.ToInt32(Request.Form["duree"]);
            formation.NomFormation = Request.Form["nom"];
            formation.IdProfesseurPromotion = Convert.ToInt32(Request.Form["prof"]);


            Formation.PostFormation(formation);
        }
    }
}

