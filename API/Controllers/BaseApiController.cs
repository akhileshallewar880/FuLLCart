using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;




[ApiController]
//  where [controller] will be replaced by the controller name
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{

}
