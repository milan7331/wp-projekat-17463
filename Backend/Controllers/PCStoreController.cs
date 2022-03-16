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
    public class PCStoreController : ControllerBase
    {
        public StoreContext Context { get; set; }

        public PCStoreController(StoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("ReturnAllStores")]
        public ActionResult ReturnAllStores()
        {
            return Ok(Context.Stores);
        }

        [HttpGet]
        [Route("ReturnStore/{id}")]
        public async Task<ActionResult> ReturnStoreID(int id)
        {
            if(id < 0)
                return BadRequest("Prodajno mesto nije u bazi!");
            try
            {
                var store = await Context.Stores.Where(p => p.ID == id).FirstOrDefaultAsync();
                return Ok(store);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddStore")]
        [HttpPost]
        public async Task<ActionResult> AddStore([FromBody] PCStore store) // FromForm??
        {
            if(string.IsNullOrWhiteSpace(store.Name) || store.Name.Length > 35)
                return BadRequest("Pogrešno uneto ime!");
            if(store.StorePhoneNumber <= 0)
                return BadRequest("Pogrešno unet broj telefona!");
            if(string.IsNullOrWhiteSpace(store.StoreLocation) || store.StoreLocation.Length > 150)
                return BadRequest("Pogrešno uneta lokacija!");
            if(string.IsNullOrWhiteSpace(store.StoreMailAdress) || store.StoreMailAdress.Length > 100)
                return BadRequest("Pogrešno uneta mail adresa prodavnice!");
            try
            {
                await Context.Stores.AddAsync(store);
                await Context.SaveChangesAsync();
                return Ok($"Prodajno mesto je dodato u bazu!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("UpdateStore")]
        [HttpPut]
        public async Task<ActionResult> UpdateStore([FromBody] PCStore store)
        {
            if(store.ID < 0)
                return BadRequest("Pogrešan ID!");
            if(string.IsNullOrWhiteSpace(store.Name) || store.Name.Length > 35)
                return BadRequest("Pogrešno uneto ime!");
            if(store.StorePhoneNumber <= 0)
                return BadRequest("Pogrešno unet broj telefona!");
            if(string.IsNullOrWhiteSpace(store.StoreLocation) || store.StoreLocation.Length > 150)
                return BadRequest("Pogrešno uneta lokacija!");
            if(string.IsNullOrWhiteSpace(store.StoreMailAdress) || store.StoreMailAdress.Length > 100)
                return BadRequest("Pogrešno uneta mail adresa prodavnice!");
            try
            {
                Context.Stores.Update(store);
                await Context.SaveChangesAsync();
                return Ok($"Prodajno mesto {store.Name} je promenjeno!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DeleteStore/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteStore(int id)
        {
            if(id < 0)
                return BadRequest("Pogrešan ID");
            if(Context.Stores.Find(id) == null)
                return BadRequest("Nepostojeći deo");
            try
            {
                var store = await Context.Stores.FindAsync(id);
                Context.Stores.Remove(store);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno je obrisana prodavnica {store.Name}!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}