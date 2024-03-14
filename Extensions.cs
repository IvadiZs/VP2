using Ivadi_Zs_Beckend_ES.Models;

namespace Ivadi_Zs_Beckend_ES {
    public static class Extensions {

        public static DTOs.OrszagDTO AsOrszag(this Orszag orszag) {
            return new (orszag.Id, orszag.OrszagNev);
        }

        public static DTOs.SzakmaDTO AsSzakma(this Szakma szakma) {
            return new (szakma.Id, szakma.SzakmaNev);
        }

        public static DTOs.VersenyzoDTO AsVersenyzo(this Versenyzo versenyzo) {
            return new (versenyzo.Id, versenyzo.Nev, versenyzo.SzakmaId, versenyzo.OrszagId, versenyzo.Pont);
        }

    }
}
