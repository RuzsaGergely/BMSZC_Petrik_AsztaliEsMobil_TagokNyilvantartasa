using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagokDesktop
{
    public class Tag
    {
        public int Azon {  get; set; }
        public string Nev { get; set; }
        // Születési év 1000 - 9999 között!
        public int Szulev {  get; set; }
        // Minimum 4 karakter de bármennyi
        public int Irszam { get; set; }
        public string Orsz {  get; set; }

        public bool IsEqual(Tag ObjectToCompare)
        {
            if(ObjectToCompare.Azon == this.Azon 
                && ObjectToCompare.Nev == this.Nev
                && ObjectToCompare.Szulev == this.Szulev
                && ObjectToCompare.Irszam == this.Irszam
                && ObjectToCompare.Orsz == this.Orsz)
            { return true; }

            return false;
        }
    }
}
