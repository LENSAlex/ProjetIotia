using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClasseE_Covid.Promotion.Manager;

namespace ClasseE_Covid.Promotion
{
    public class Formation
    {
        ManagerFormation managerFormation;
        public int IdDepartement { get; set; }

        public string NomFormation { get; set; }

        public int DureeFormation { get; set; }

        public int AnneePromotion { get; set; }

        public int IdProfesseurPromotion { get; set; }

        public static async Task PostFormation(Formation formation)
        {
            await ManagerFormation.Save(formation);
        }

    }
}
