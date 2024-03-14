using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagler
{
    internal class Program
    {
        static void Main(string[] args)
        {

public class Buchungsverwaltung
        {
            private List<Gast> gastliste = new List<Gast>();
            private List<Buchung> buchungsliste = new List<Buchung>();
            

            public Buchungsverwaltung() { }

            public Gast erstelleGast(string vorname, string nachname, string email)
            {
                var gast = new Gast(vorname, nachname, email);
                gastliste.Add(gast);
                return gast;
            }

            public void loescheDuplikate()
            {
                var distinctGuests = gastliste.GroupBy(g => g.GetEmail()).Select(g => g.First()).ToList();
                gastliste = distinctGuests;
            }

            public void addGast(Gast gast)
            {
                this.gastliste.Add(gast);
            }

            public int getAnzahlBuchungen()
            {
                return buchungsliste.Count;
            }

            public List<Gast> getGaesteOhneBuchung()
            {
                return gastliste.Where(g => g.GetBuchungsliste().Count == 0).ToList();
                Console.WriteLine('Malte du hs')
            }

            public long berechneDauerAllerBuchungen()
            {
                return buchungsliste.Sum(b => b.GetBis() - b.GetVon()) / 1000 / 60; // Convert milliseconds to minutes
            }

            public void generiereBeispieldaten()
            {
                erstelleGast("Merve", "Mueller", "mm@hessen.de");
                erstelleGast("Anna", "Schmidt", "schmidt@hessen.de");
            }
        }

        public class Gast
        {
            private string vorname;
            private string nachname;
            private string email;
            private List<Buchung> buchungsListe = new List<Buchung>();

            public Gast(string vorname, string nachname, string email)
            {
                this.vorname = vorname;
                this.nachname = nachname;
                this.email = email;
            }

            public string GetVorname()
            {
                return vorname;
            }

            public void SetVorname(string value)
            {
                vorname = value;
            }

            public string GetNachname()
            {
                return nachname;
            }

            public void SetNachname(string value)
            {
                nachname = value;
            }

            public string GetEmail()
            {
                return email;
            }

            public void SetEmail(string value)
            {
                email = value;
            }

            public List<Buchung> GetBuchungsliste()
            {
                return buchungsListe;
            }
        }

        public class Buchung
        {
            private long von; // Start time in milliseconds since 1970
            private long bis; // End time in milliseconds since 1970

            public Buchung(long von, long bis)
            {
                this.von = von;
                this.bis = bis;
            }

            public long GetVon()
            {
                return von;
            }

            public long GetBis()
            {
                return bis;
            }
        }

    }
}
}
