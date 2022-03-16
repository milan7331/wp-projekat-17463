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
    public class OrderController : ControllerBase
    {
        public StoreContext Context { get; set; }

        public OrderController(StoreContext context)
        {
            Context = context;
        }

        [Route("ReturnAllOrders")]
        [HttpGet]
        public async Task<ActionResult> ReturnAllOrders()
        {
            var orders = await Context.Orders
                .Include(p => p.Buyer)
                .Include(p => p.Part)
                .Include(p => p.FromStore).ToListAsync();
            return Ok(orders);
        }

        [Route("ReturnOrder/{id}")]
        [HttpGet]
        public async Task<ActionResult> ReturnOrder(int id)
        {
            if(id < 0)
                return BadRequest("Pogrešno unet ID");
            
            try
            {
                var order = await Context.Orders.FindAsync(id);
                if(order == null)
                    return BadRequest("Porudžbina ne postoji u sistemu!");
                else
                    return Ok(order);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddOrder")]
        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] Order order) // FromForm??
        {
            if(order.Quantity <= 0)
                return BadRequest("Pogrešno uneta količina!");
            if(/*order.Buyer == null ||*/ order.FromStore == null || order.Part == null || order.Price <= 0)
                return BadRequest("Porudžbina nema validne informcije");
            try
            {
                await Context.Orders.AddAsync(order);
                await Context.SaveChangesAsync();
                return Ok($"Porudžbina je dodata u bazu!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddOrder/{quantity}/{price}/{buyerid}/{partid}/{storeid}")]
        [HttpPost]
        public async Task<ActionResult> AddOrderFromRoute(int quantity, int price, int buyerid, int partid, int storeid)
        {
            if(quantity <= 0)
                return BadRequest("Pogrešno uneta količina!");
            if(price <= 0)
                return BadRequest("Pogrešno izračunata cena!");
            if(buyerid <= 0 || partid <= 0 || storeid <= 0)
                return BadRequest("Pogrešan ID za kupca/deo/prodavnicu!");
            try
            {
                    var buyer = await Context.UserAccounts.FindAsync(buyerid);
                    var part = await Context.Parts.FindAsync(partid);
                    var store = await Context.Stores.FindAsync(storeid);

                    Order order = new Order
                    {
                        Quantity = quantity,
                        Price = price,
                        Buyer = buyer,
                        Part = part,
                        FromStore = store
                    };

                    await Context.Orders.AddAsync(order);
                    await Context.SaveChangesAsync();
                    return Ok("Porudžbina uspešno uneta u bazu!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
        }

        [Route("UpdateOrder")]
        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] Order order)
        {
            
            try
            {
                Context.Orders.Update(order);
                await Context.SaveChangesAsync();
                return Ok($"Porudžbina {order.FromStore} je promenjena!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("DeleteOrder/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            if(id < 0)
                return BadRequest("Pogrešan ID");
            if(Context.Orders.Find(id) == null)
                return BadRequest("Nepostojeća porudžbina");
            try
            {
                var order = await Context.Orders.FindAsync(id);
                Context.Orders.Remove(order);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno je obrisana porudžbina iz prodavnica {order.FromStore}!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}