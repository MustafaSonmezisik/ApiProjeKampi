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

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Mesajınız başarıyla silindi.");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new();
            contact.ContactId = updateContactDto.ContactId;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.OpenHours = updateContactDto.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Mesajınız başarıyla güncellendi.");
        }


    }
}
