using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class CasCovid
    {
        public int Id { get; set; }
        public DateTime DateDeContamination { get; set; }

        private int _personneId;
        public int PersonneId
        {
            get
            {
                return _personneId;
            }
            set
            {
                _personneId = value;
                _personne = null;
            }
        }

        private Personne _personne;
        public Personne Personne
        {
            get
            {
                if (_personne == null && PersonneId != 0)
                    _personne = Personne.Load(PersonneId);
                return _personne;
            }
            set
            {
                _personne = value;
                _personneId = value?.Id ?? 0;
            }
        }
        public static Task<string> SendAlert(CasCovid cas)
        {
            return CasCovidManager.SendAlert(cas);
        }
        public Task<string> SendAlert()
        {
            return CasCovidManager.SendAlert(this);
        }
    }
}
