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
        public IActionResult listaMascotas() {
            List<Mascota> lista = new List<Mascota>();

            try{
                lista = _dbcontext.Mascotas
                                            .Include(p => p.objPropietario)
                                            .Include(r => r.objRaza)
                                            .ThenInclude(e => e.objEspecie)
                                            .ToList();
                return StatusCode(StatusCodes.Status200OK,new {mensaje ="ok",response= lista});

            }catch (Exception ex){
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpPost]
        [Route("RegristrarMascota")]
        public IActionResult guardarMascotas([FromBody] Mascota mascota) {
            try
            {
                _dbcontext.Mascotas.Add(mascota);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});
            }
        }

        [HttpGet]
        [Route("BuscarMascota/{IdMascota}")]
        public IActionResult buscarMascota(int IdMascota){
            try{
                Mascota mascota = _dbcontext.Mascotas
                                            .Include(p => p.objPropietario)
                                            .Include(r => r.objRaza)
                                            .ThenInclude(e => e.objEspecie)
                                            .Where(m => m.IdMascota == IdMascota)
                                            .FirstOrDefault() ?? new Mascota();

                if (mascota != null){
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = mascota });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontró la mascota con el ID especificado", response = new Mascota() });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("EditarMascota/{IdMascota}")]
        public IActionResult editarMascota(int IdMascota, [FromBody] Mascota mascotaActualizada)
        {
            try
            {
                Mascota mascota = _dbcontext.Mascotas
                                            .Include(p => p.objPropietario)
                                            .Include(r => r.objRaza)
                                            .ThenInclude(e => e.objEspecie)
                                            .Where(m => m.IdMascota == IdMascota)
                                            .FirstOrDefault() ?? new Mascota();

                if (mascota == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontró la mascota con el ID especificado" });
                }

                mascota.Nombre = mascotaActualizada.Nombre;
                mascota.Edad = mascotaActualizada.Edad;
                mascota.IdPropietario = mascotaActualizada.IdPropietario;
                mascota.IdRaza = mascotaActualizada.IdRaza;

                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Mascota actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("EliminarMascota/{IdMascota}")]
        public IActionResult eliminarMascota(int IdMascota)
        {
            try
            {
                Mascota mascota = _dbcontext.Mascotas
                                            .Include(p => p.objPropietario)
                                            .Include(r => r.objRaza)
                                            .ThenInclude(e => e.objEspecie)
                                            .Where(m => m.IdMascota == IdMascota)
                                            .FirstOrDefault() ?? new Mascota();

                if (mascota == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontró la mascota con el ID especificado" });
                }

                _dbcontext.Mascotas.Remove(mascota);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Mascota eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


    }
}
