using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWindows.Api.Providers;

namespace TestWindows.Api.Controllers
{
    [Route("[controller]")]
    public class WindowsController : Controller
    {
        private readonly IWindowsProvider _windowsProvider;
        public WindowsController(IWindowsProvider windowsProvider)
        {
            _windowsProvider = windowsProvider;
        }
        [HttpGet()]
        public IActionResult Get([FromQuery] string name )
        {
            var resultWindows = _windowsProvider.GetWindowsByName(name);
            if (resultWindows == null || !resultWindows.Any())
            {
                return NotFound();
            }
            return Ok(resultWindows);
        }
    }
}
