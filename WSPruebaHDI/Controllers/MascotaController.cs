using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSPruebaHDI.Models;

namespace WSPruebaHDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase{
        public readonly CatalogoMascotasContext _dbcontext;
        public MascotaController(CatalogoMascotasContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("ListaMacotas")]
        public IActionResult Lista() {
            List<Mascota> lista = new List<Mascota>();

            try{
                lista = _dbcontext.Mascotas
                                            .Include(p => p.objPropietario) // Incluye la propiedad de navegación objPropietario
                                            .Include(r => r.objRaza) // Incluye la propiedad de navegación objRaza
                                            .ThenInclude(e => e.objEspecie) // Incluye la propiedad de navegación objEspecie dentro de objRaza
                                            .ToList();
                return StatusCode(StatusCodes.Status200OK,new {mensaje ="ok",response= lista});

            }catch (Exception ex){
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }
    }
}
