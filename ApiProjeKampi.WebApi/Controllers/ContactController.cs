using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactController(ApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContact)
        {
            // nesne örneği alıp manuel mapleme yapma
            Contact contact = new();
            contact.MapLocation = createContact.MapLocation;
            contact.Email = createContact.Email;
            contact.Address = createContact.Address;
            contact.Phone = createContact.Phone;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Mesajınız başarıyla iletildi.");



        }


    }
}
