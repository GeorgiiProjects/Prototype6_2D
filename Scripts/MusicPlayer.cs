using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // инициализируем компонент AudioSource.
    AudioSource audioSource;

    void Start()
    {
        // не позволяем уничтожить префаб MusicPlayer при загрузке следующей сцены, после сцены Splash Screen.
        DontDestroyOnLoad(this);
        // получаем доступ к AudioSource.
        audioSource = GetComponent<AudioSource>();
        // используем настройки громкости MasterVolume при старте, громкость (0.2f).
        audioSource.volume = PlayerPreferenceController.GetMasterVolume();
    }

    // публичный метод с параметром изменяемой громкости, метод будет вызываться в скрипте OptionsController.
    public void SetVolume(float volume)
    {
        // присваиваем значение громкости которое мы можем изменять.
        audioSource.volume = volume;
    }
}
