namespace Ivadi_Zs_Beckend_ES.Models {
    public class DTOs {

        // Orszag

        public record OrszagDTO(string Id, string OrszagNev);
        public record CreateOrszagDTO(string Id, string OrszagNev);
        public record UpdateOrszagDTO(string OrszagNev);

        // Szakma

        public record SzakmaDTO(string Id, string SzakmaNev);
        public record CreateSzakmaDTO(string Id, string SzakmaNev);
        public record UpdateSzakmaDTO(string SzakmaNev);

        // Versenyzo

        public record VersenyzoDTO(int Id, string Nev, string SzakmaId, string OrszagId, int Pont);
        public record CreateVersenyzoDTO(int Id, string Nev, string SzakmaId, string OrszagId, int Pont);
        public record UpdateVersenyzoDTO(string Nev, string SzakmaId, string OrszagId, int Pont);
    }
}
