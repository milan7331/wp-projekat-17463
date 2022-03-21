using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PCPartController : ControllerBase
    {
        public StoreContext Context { get; set; }

        public PCPartController(StoreContext context)
        {
            Context = context;
        }

        [Route("ReturnAllParts")]
        [HttpGet]
        public async Task<ActionResult> ReturnAllParts()
        {
            return Ok(await Context.Parts.ToListAsync());
        }

        [Route("ReturnPart/{serial}")]
        [HttpGet]
        public async Task<ActionResult> ReturnPart(int serial)
        {
            if(serial <= 0)
                return BadRequest("Pogrešno unet serijski broj");
            ///JOŠ PROVERA
            try
            {
                var part = await Context.Parts.Where(p => p.SerialNumber == serial).FirstOrDefaultAsync();
                return Ok(part);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddPCPart")]
        [HttpPost]
        public async Task<ActionResult> AddPCPartAsync([FromBody] PCPart part) // FromForm??
        {
            if(part.SerialNumber == 0)
                return BadRequest("Pogrešan serijski broj!");
            if(part.Price < 0)
                return BadRequest("Pogrešna cena!");
            if(string.IsNullOrWhiteSpace(part.ProductName) || part.ProductName.Length > 50)
                return BadRequest("Pogrešno ime komponente!");
            if(string.IsNullOrWhiteSpace(part.ProductCategory) || part.ProductCategory.Length > 30)
                return BadRequest("Pogrešno ime kategorije komponente!");
            if(Context.Parts.Contains(part))
                return BadRequest($"Komponenta sa serijskim brojem {part.ProductCategory} je već u bazi podataka!");
            try
            {
                await Context.Parts.AddAsync(part);
                await Context.SaveChangesAsync();
                return Ok($"Komponenta je dodata u bazu!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Route("AddPCPartForm")]
        [HttpPost]
        public async Task<ActionResult> AddPCPartForm([FromForm] PCPart part)
        {

            
            if(part.SerialNumber == 0)
                return BadRequest("Pogrešan serijski broj!");
            if(part.Price < 0)
                return BadRequest("Pogrešna cena!");
            if(string.IsNullOrWhiteSpace(part.ProductName) || part.ProductName.Length > 50)
                return BadRequest("Pogrešno ime komponente!");
            if(string.IsNullOrWhiteSpace(part.ProductCategory) || part.ProductCategory.Length > 30)
                return BadRequest("Pogrešno ime kategorije komponente!");
            try
            {
                await Context.Parts.AddAsync(part);
                await Context.SaveChangesAsync();
                return Ok($"Komponenta je dodata u bazu!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("UpdatePCPart")]
        [HttpPut]
        public async Task<ActionResult> UpdatePCPart([FromBody] PCPart part)
        {
            if(part.ID < 0)
                return BadRequest("Pogrešno unet ID!");
            if(part.SerialNumber == 0)
                return BadRequest("Pogrešan serijski broj!");
            if(part.Price < 0)
                return BadRequest("Pogrešna cena!");
            if(string.IsNullOrWhiteSpace(part.ProductName) || part.ProductName.Length > 50)
                return BadRequest("Pogrešno ime komponente!");
            if(string.IsNullOrWhiteSpace(part.ProductCategory) || part.ProductCategory.Length > 30)
                return BadRequest("Pogrešno ime kategorije komponente!");
            try
            {
                Context.Parts.Update(part);
                await Context.SaveChangesAsync();
                return Ok($"Komponenta {part.ProductName} je promenjena!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DeletePCPart/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if(id < 0)
                return BadRequest("Pogrešan ID");
            if(Context.Parts.Find(id) == null)
                return BadRequest("Nepostojeći deo");
            try
            {
                var part = await Context.Parts.FindAsync(id);
                Context.Parts.Remove(part);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno je obrisan deo {part.ProductName}!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}