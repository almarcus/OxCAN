using System.Collections;
using Microsoft.AspNetCore.Mvc;
using OxCAN.Shared.Models;
using OxCAN.Shared.Services;

namespace OxCAN.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{

    private readonly IProjectService _projectService;
    private readonly ILogger<ProjectsController> _logger;

    public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
    {
        _projectService = projectService;
        _logger = logger;
    }

    [HttpGet("{status}")]
    public IEnumerable<Project> Get(Project.Status status)
    {
        return _projectService.Get(status);
    }
}