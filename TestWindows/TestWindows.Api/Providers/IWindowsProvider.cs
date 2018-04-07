using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWindows.Api.Models;

namespace TestWindows.Api.Providers
{
    public interface IWindowsProvider
    {
        IEnumerable<Window> GetWindowsByName(string name);
    }
}
