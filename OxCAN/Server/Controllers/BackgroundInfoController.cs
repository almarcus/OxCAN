using System.Collections;
using Microsoft.AspNetCore.Mvc;
using OxCAN.Shared.Models;
using OxCAN.Shared.Services;

namespace OxCAN.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BackgroundInfoController : ControllerBase
{

    private readonly IProjectService _projectService;
    private readonly ILogger<BackgroundInfoController> _logger;

    public BackgroundInfoController(IProjectService projectService, ILogger<BackgroundInfoController> logger)
    {
        _projectService = projectService;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Project> Get()
    {
        return _projectService.Get();
    }
}