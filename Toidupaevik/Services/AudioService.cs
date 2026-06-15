using Plugin.Maui.Audio;

namespace Toidupaevik.Services;

public class AudioService
{
    private readonly IAudioManager _audioManager;
    private IAudioPlayer? _player;

    public AudioService(IAudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public async Task PlaySoundAsync()
    {
        var stream = await FileSystem.OpenAppPackageFileAsync("click.mp3");

        _player = _audioManager.CreatePlayer(stream);

        _player.Play();
    }
}
