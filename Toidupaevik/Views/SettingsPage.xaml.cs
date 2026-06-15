using Toidupaevik.Services;

namespace Toidupaevik.Views;

public partial class SettingsPage : ContentPage
{
    private readonly ThemeService _themeService;
    private readonly SettingsService _settingsService;

    public SettingsPage(
        ThemeService themeService,
        SettingsService settingsService)
    {
        InitializeComponent();

        _themeService = themeService;
        _settingsService = settingsService;

        SoundSwitch.IsToggled = _settingsService.SoundEnabled;

        SoundSwitch.Toggled += (s, e) =>
        {
            _settingsService.SoundEnabled = e.Value;
        };

        LanguagePicker.SelectedItem =
            _settingsService.Language;

        LanguagePicker.SelectedIndexChanged += (s, e) =>
        {
            if (LanguagePicker.SelectedItem != null)
            {
                _settingsService.Language =
                    LanguagePicker.SelectedItem.ToString()!;

                Application.Current!.MainPage = new AppShell();
            }
        };
    }

    private void OnLightThemeClicked(object sender, EventArgs e)
    {
        _themeService.ApplyTheme("Light");
    }

    private void OnDarkThemeClicked(object sender, EventArgs e)
    {
        _themeService.ApplyTheme("Dark");
    }
}