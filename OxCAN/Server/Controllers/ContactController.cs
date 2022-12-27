using System.Collections;
using Microsoft.AspNetCore.Mvc;
using OxCAN.Shared.Models;
using OxCAN.Shared.Services;

namespace OxCAN.Server.Controllers;

[ApiController]
[Route("[controller]")]
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
}