using System.Collections;
using Microsoft.AspNetCore.Mvc;
using OxCAN.Shared.Models;
using OxCAN.Shared.Services;

namespace OxCAN.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{

    private readonly IProjectService _projectService;
    private readonly ILogger<ProjectsController> _logger;

    public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
    {
        _projectService = projectService;
        _logger = logger;
    }

    [HttpGet]
    [Route("Previous")]
    public IEnumerable<Project> GetPrevious()
    {
        return _projectService.Get(Project.Status.Past);
    }

    [HttpGet]
    [Route("Future")]
    public IEnumerable<Project> GetFuture()
    {
        return _projectService.Get(Project.Status.Future);
    }
}