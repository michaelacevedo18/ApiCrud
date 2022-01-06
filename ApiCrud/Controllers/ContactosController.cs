using ApiCrud.Data;
using ApiCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ContactosController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        //GET TODOS HACIA api/contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> ObtenerContactoItems()
        {
            return await _context.Contacto.ToListAsync();
        }

        //GET POR ID API/CONTACTOS/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> ObtenerContactoItems(int id)
        {
            var contactoItem = await _context.Contacto.FindAsync(id);
            if (contactoItem == null)
            {
                return NotFound();
            }
            return Ok(contactoItem);
        }

        //POST api/contactos
        [HttpPost]

        public async Task<ActionResult<Contacto>> PostearContactos(Contacto item)
        {
            _context.Contacto.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerContactoItems), new { id = item.Id }, item);//El Id es el del modelo y id es del id que se recibe en el metodo

        }

        //PUT API/Contactor/5 EL Put nos manda todos los campos por eso se demora, para que no se demore hare el patch
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarContactoItems(int id, Contacto item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteContactoItem(int id) 
        {
            var contactoItem = await _context.Contacto.FindAsync(id);
            
            if (contactoItem == null)
            {
                return NotFound();
            }
            _context.Contacto.Remove(contactoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
