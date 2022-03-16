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
    public class UserAccountController : ControllerBase
    {
        public StoreContext Context { get; set; }

        public UserAccountController(StoreContext context)
        {
            Context = context;
        }
        [HttpGet]
        [Route("ReturnAllAccounts")]
        public ActionResult ReturnAllAccounts()
        {
            return Ok(Context.UserAccounts);
        }

        [HttpGet]
        [Route("ReturnAccount/{id}")]
        public async Task<ActionResult> ReturnAccountID(int id)
        {
            if(id < 0)
                return BadRequest("Korisnik nije u bazi!");
            try
            {
                var acc = await Context.UserAccounts.Where(p => p.ID == id).FirstOrDefaultAsync();
                return Ok(acc);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ReturnAccountOrders/{id}")]
        public async Task<ActionResult> ReturnAccountOrders(int id)
        {
            if(id < 0 || Context.UserAccounts.Find(id) == null)
                return BadRequest("Korisnik nije u bazi!");
            try
            {
                    var orders = await Context.UserAccounts.Where(p => p.ID == id)
                        .Include(p => p.Orders)
                        .ThenInclude(p => p.Buyer)
                        .Include(p => p.Orders)
                        .ThenInclude(p => p.FromStore)
                        .ToListAsync();
                    return Ok(orders);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("AddUserAccount")]
        [HttpPost]
        public async Task<ActionResult> AddAccount([FromBody] UserAccount user)       // FromForm??
        {
            if(string.IsNullOrWhiteSpace(user.FirstName) || user.FirstName.Length > 50)
                return BadRequest("Pogrešno ime!");
            if(string.IsNullOrWhiteSpace(user.LastName) || user.LastName.Length > 50)
                return BadRequest("Pogrešno prezime!");
            if(string.IsNullOrWhiteSpace(user.Address) || user.Address.Length > 50)
                return BadRequest("Pogrešno uneta Adresa!");
            if(string.IsNullOrWhiteSpace(user.City) || user.City.Length > 40)
                return BadRequest("Pogrešno unet grad!");
            if(string.IsNullOrWhiteSpace(user.MailAddress) || user.MailAddress.Length > 320 )
                return BadRequest("Pogrešno uneta mail adresa!");
            if(Context.UserAccounts.Contains(user))
                return BadRequest($"Korisnički nalog {user.MailAddress} već postoji!");
            try
            {
                await Context.UserAccounts.AddAsync(user);
                await Context.SaveChangesAsync();
                return Ok($"Korisnik je dodat u bazu!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("UpdateUserAccount")]
        [HttpPut]
        public async Task<ActionResult> UpdateAccount([FromBody] UserAccount user)
        {
            if(user.ID < 0)
                return BadRequest("Pogrešan ID!");
            if(string.IsNullOrWhiteSpace(user.FirstName) || user.FirstName.Length > 50)
                return BadRequest("Pogrešno ime!");
            if(string.IsNullOrWhiteSpace(user.LastName) || user.LastName.Length > 50)
                return BadRequest("Pogrešno prezime!");
            if(string.IsNullOrWhiteSpace(user.Address) || user.Address.Length > 50)
                return BadRequest("Pogrešno uneta Adresa!");
            if(string.IsNullOrWhiteSpace(user.City) || user.City.Length > 40)
                return BadRequest("Pogrešno unet grad!");
            if(string.IsNullOrWhiteSpace(user.MailAddress) || user.MailAddress.Length > 320 )
                return BadRequest("Pogrešno uneta mail adresa!");
            try
            {
                Context.UserAccounts.Update(user);
                await Context.SaveChangesAsync();
                return Ok($"Korisnički nalog {user.MailAddress} je promenjen!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("UpdateUserAccountNewOrder/{userid}/{orderid}")]
        [HttpPut]
        public async Task<ActionResult> UpdateAccountOrder(int userid, int orderid)
        {
            if(userid < 0 || orderid < 0)
                return BadRequest("Pogrešan ID!");
            try
            {
                var user = await Context.UserAccounts.FindAsync(userid);
                var order = await Context.Orders.FindAsync(orderid);
                if( user == null || order == null)
                return BadRequest($"Traženi korisnički nalog/porudžbina ne postoji u bazi!");
                user.Orders.Add(order);
                Context.UserAccounts.Update(user);
                await Context.SaveChangesAsync();
                return Ok("Korisničke porudžbine update!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("DeleteUserAccount/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            if( id < 0)
                return BadRequest("Pogrešan ID!");
            if(Context.UserAccounts.Find(id) == null)
                return BadRequest("Nalog nije pronađen!");
            try
            {
                var account = await Context.UserAccounts.FindAsync(id);
                Context.UserAccounts.Remove(account);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno je izbrisan korisnički nalog: {account.FirstName} {account.LastName}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}