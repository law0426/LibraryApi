// using Core.Models; //unnecessary due to references. but good for clarity.
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/[Controller]/")]
public class TasksController(ILogger<TasksController> logger) : ControllerBase
{

}