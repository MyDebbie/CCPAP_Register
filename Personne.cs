using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterForCcpap
{
    public class Personne
    {
        private string _nom, _prenom, _adresse, _datedenaissance, _telephone, _datecree;
        private DateTime dateTime = DateTime.Now;

        public Personne(string nom, string prenom, string adresse, string datedenaissance, string telephone, string datecree)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Adresse = adresse;
            this.Datedenaissance = datedenaissance;
            this.Telephone = telephone;
            this.Datecree = datecree;

        }

        public string Nom
        {
            get => _nom;
            set { _nom = Title(value.Trim()); }
        }

        public string Prenom
        {
            get => _prenom;
            set { _prenom = Title(value.Trim()); }
        }

        public string Adresse
        {
            get => _adresse;
            set { _adresse = value.Trim(); }
        }

        public string Datedenaissance
        {
            get => _datedenaissance;
            set { _datedenaissance = value.Trim(); }
        }

        public string Telephone
        {
            get => _telephone;
            set { _telephone = value.Trim(); }
        }

        public string Datecree
        {
            get => _datecree;
            set { _datecree = (dateTime.ToString("d")); }
        }

        public string Title(string t)
        {
            string b = "";
            b = char.ToUpper(t[0]) + t.Substring(1);
            return b;
        }
    }
}