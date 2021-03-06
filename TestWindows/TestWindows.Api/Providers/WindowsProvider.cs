﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestWindows.Api.Integration;
using TestWindows.Api.Models;

namespace TestWindows.Api.Providers
{
    public class WindowsProvider : IWindowsProvider
    {
        public IEnumerable<Window> GetAllWindows()
        {
            var windows = new List<Window>();
            WinApi.EnumWindows((hWnd, lParam) =>
            {
                var windowName = WinApi.GetWindowText(hWnd);

                if (string.IsNullOrEmpty(windowName) || !WinApi.IsWindowVisible(hWnd))
                {
                    return true;
                }
                WinApi.GetWindowRect(hWnd, out var rect);
                if (rect.Width == 0 || rect.Height == 0)
                {
                    return true;
                }
                windows.Add(
                    new Window
                    {
                        Name = windowName,
                        Height = rect.Height,
                        Width = rect.Width,
                        X = rect.X,
                        Y = rect.Y
                    });
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        IEnumerable<Window> IWindowsProvider.GetWindowsByName(string name)
        {
            return GetAllWindows().Where(el => string.Equals(el.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
