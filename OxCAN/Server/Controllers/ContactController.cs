using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OxCAN.Shared.Models;
using OxCAN.Shared.Services;

namespace OxCAN.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{

    private readonly ILogger<ContactController> _logger;
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService, ILogger<ContactController> logger)
    {
        _contactService = contactService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Submit([FromBody] Contact contact)
    {
        _contactService.Submit(contact);

        return Ok(contact);
    }

    [HttpGet]
    [Authorize(Roles =  "Admin")]
    public IEnumerable<Contact> Get()
    {
       return _contactService.Get();
    }
}