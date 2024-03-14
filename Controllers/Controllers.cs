using Ivadi_Zs_Beckend_ES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Ivadi_Zs_Beckend_ES.Models.DTOs;

namespace Ivadi_Zs_Beckend_ES.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class Controllers : ControllerBase {

        // 8. Feladat

        [HttpGet("Versenyzők")]
        public IActionResult GetVersenyzok() {
            using (var context = new EuroskillsContext()) {
                try {
                    return Ok(context.Versenyzos.ToList());
                }
                catch (Exception e) {

                    return StatusCode(400, e);
                }
            }
        }

        // 9. Feladat

        [HttpGet("{id}")]
        public IActionResult GetVersenyzoById(int id) {
            using (var context = new EuroskillsContext()) {
                try {

                    var result = context.Versenyzos.FirstOrDefault(x => x.Id == id);
                    return Ok(result.AsVersenyzo());
                }
                catch (Exception e) {

                    return StatusCode(400, e);
                }
            }
        }

        // 10. Feladat

        [HttpGet("Országok")]
        public IActionResult GetOrszagok() {
            using (var context = new EuroskillsContext()) {
                try {
                    return Ok($"Összes ország száma: {context.Orszags.Count()}");
                }
                catch (Exception e) {

                    return StatusCode(400, e);
                }
            }
        }

        // 11. Feladat

        [HttpPost("Versenyző")]
        public IActionResult PostVersenyzo(CreateVersenyzoDTO ver) {

            try {
                using (var context = new EuroskillsContext()) {

                    var request = new Versenyzo {

                        Id = ver.Id,
                        Nev = ver.Nev,
                        SzakmaId = ver.SzakmaId,
                        OrszagId = ver.OrszagId,
                        Pont = ver.Pont

                    };

                    context.Versenyzos.Add(request);
                    context.SaveChanges();
                    return Ok(request.AsVersenyzo());
                }
            }
            catch (Exception e) {

                return StatusCode(400, e);
            }

        }

        // 12. Feladat
    }
}
