using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Toidupaevik.Services
{
    public class SettingsService
    {
        private const string LanguageKey = "Language";
        private const string SoundKey = "SoundEnabled";

        public event Action? LanguageChanged;

        public string Language
        {
            get => Preferences.Get(LanguageKey, "et");
            set
            {
                Preferences.Set(LanguageKey, value);

                CultureInfo.CurrentCulture = new CultureInfo(value);
                CultureInfo.CurrentUICulture = new CultureInfo(value);

                LanguageChanged?.Invoke();
            }
        }

        public bool SoundEnabled
        {
            get => Preferences.Get(SoundKey, true);
            set => Preferences.Set(SoundKey, value);
        }
    }
}