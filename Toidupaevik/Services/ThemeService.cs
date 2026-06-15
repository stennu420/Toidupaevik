using System;
using System.Collections.Generic;
using System.Text;

namespace Toidupaevik.Services
{
    public class ThemeService
    {
        private const string ThemeKey = "Theme";

        public void LoadTheme()
        {
            var theme = Preferences.Get(ThemeKey, "Light");
            ApplyTheme(theme);
        }

        public void ApplyTheme(string theme)
        {
            Application.Current!.UserAppTheme =
                theme == "Dark" ? AppTheme.Dark : AppTheme.Light;

            Preferences.Set(ThemeKey, theme);
        }
    }
}