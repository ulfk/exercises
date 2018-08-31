using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bruchrechnen
{
    public class Bruch
    {
        private int ZaehlerAbs { get; set; }

        private int NennerAbs { get; set; }

        private int ZaehlerInt { get; set; }

        private int NennerInt { get; set; }

        public int Zaehler
        {
            get => ZaehlerInt;
            private set
            {
                ZaehlerInt = value;
                ZaehlerAbs = Math.Abs(value);
            }
        }

        public int Nenner
        {
            get => NennerInt;
            private set
            {
                NennerInt = value;
                NennerAbs = Math.Abs(value);
            }
        }

        public Bruch(int zaehler, int nenner)
        {
            if (nenner == 0)
            {
                throw new ArgumentException("Null als Nenner nicht zulaessig!", nameof(nenner));
            }

            Zaehler = zaehler;
            ZaehlerAbs = Math.Abs(zaehler);
            Nenner = nenner;
            NennerAbs = Math.Abs(nenner);
        }

        public static Bruch operator+ (Bruch bruchLinks, Bruch bruchRechts)
        {
            return new Bruch(bruchLinks.Zaehler * bruchRechts.Nenner + bruchRechts.Zaehler * bruchLinks.Nenner, 
                             bruchLinks.Nenner * bruchRechts.Nenner).Kuerzen();
        }

        public static Bruch operator- (Bruch bruchLinks, Bruch bruchRechts)
        {
            return new Bruch(bruchLinks.Zaehler * bruchRechts.Nenner - bruchRechts.Zaehler * bruchLinks.Nenner,
                bruchLinks.Nenner * bruchRechts.Nenner).Kuerzen();
        }

        public static Bruch operator* (Bruch bruchLinks, Bruch bruchRechts)
        {
            return new Bruch(bruchLinks.Zaehler * bruchRechts.Zaehler,
                             bruchLinks.Nenner * bruchRechts.Nenner).Kuerzen();
        }

        public static Bruch operator/ (Bruch bruchLinks, Bruch bruchRechts)
        {
            return new Bruch(bruchLinks.Zaehler * bruchRechts.Nenner,
                bruchLinks.Nenner * bruchRechts.Zaehler).Kuerzen();
        }

        /// <summary>
        /// Kürzt den Bruch und korrigiert ggf. die Vorzeichen
        /// </summary>
        /// <returns></returns>
        public Bruch Kuerzen()
        {
            // Kuerzen mit dem groessten gemeinsamen Teiler
            var teiler = GroessterGemeinsamerTeiler();
            if (teiler > 1)
            {
                Zaehler /= teiler;
                Nenner /= teiler;
            }

            // Um -1 kuerzen...
            if (Zaehler < 0 && Nenner < 0)
            {
                Zaehler = ZaehlerAbs;
                Nenner = NennerAbs;
            }
            // ...oder Vorzeichen in den Zaehler ziehen
            else if (Zaehler > 0 && Nenner < 0)
            {
                Zaehler = Zaehler * -1;
                Nenner = NennerAbs;
            }

            return this;
        }

        /// <summary>
        /// Ermittelt den groessten gemeinsamen Teiler von Zaehler und Nenner
        /// </summary>
        /// <returns></returns>
        private int GroessterGemeinsamerTeiler()
        {
            var wert = ZaehlerAbs;
            var divisor = NennerAbs;
            if (wert == 0)
            {
                return divisor;
            }

            do
            {
                var rest = wert % divisor;
                wert = divisor;
                divisor = rest;
            }
            while (divisor != 0);

            return wert;
        }
    }
}
