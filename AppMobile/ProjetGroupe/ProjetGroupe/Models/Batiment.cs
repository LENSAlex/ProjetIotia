using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Batiment
    {
        public int Id { get; set; }

        private int _SiteId;
        public int SiteId
        {
            get
            {
                return _SiteId;
            }
            set
            {
                _SiteId = value;
                _site = null;
            }
        }

        private Site _site;
        public Site Site
        {
            get
            {
                if (_site == null && _SiteId != 0)
                    _site = Site.Load(_SiteId);
                return _site;
            }
            set
            {
                _site = value;
                _SiteId = value?.Id ?? 0;
            }
        }
        public string Nom { get; set; }
        public int Surface { get; set; }
        public static Batiment Load(int Id)
        {
            return new Batiment();
        }
    }
}
