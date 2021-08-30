using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // слайдер настройки громкости Volume Slider поместим в префаб Options Controller.
    [SerializeField] Slider volumeSlider;
    // громкость звука по умолчанию.
    [SerializeField] float defaultVolume = 0.1f;
    // слайдер настройки сложности Difficulty Slider поместим в префаб Options Controller.
    [SerializeField] Slider difficultySlider;
    // сложность по умолчанию.
    [SerializeField] float defaultDifficulty = 0f;

    void Start()
    {
        // передаем сохраненное значение громкости выставленное в Options в слайдер громкости и запускаем игру с такой громкостью со старта.
        volumeSlider.value = PlayerPreferenceController.GetMasterVolume();
        // передаем сохраненное значение сложности выставленное в Options в слайдер сложности и запускаем игру с такой сложностью со старта.
        difficultySlider.value = PlayerPreferenceController.GetDifficulty();
    }

    void Update()
    {
        // получаем доступ к скрипту MusicPlayer.
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        // если префаб Music Player есть в сцене.
        if (musicPlayer)
        {
            // музыка играет с громкостью сохраненной в опциях.
            musicPlayer.SetVolume(volumeSlider.value);
        }
        // иначе
        else
        {
            Debug.LogWarning("No music player, start from splash screen?");
        }
    }

    // метод для сохранения настроек громкости и сложности.
    private void SaveAndExit()
    {   // получаем доступ PlayerPreferenceController напрямую, не используя FindObjectOfType<>, так как вызов идет из статичного метода.
        // сохраняем настройки громкости на любой сцене.
        PlayerPreferenceController.SetMasterVolume(volumeSlider.value);
        // получаем доступ PlayerPreferenceController напрямую, не используя FindObjectOfType<>, так как вызов идет из статичного метода.
        // сохраняем настройки сложности на любой сцене.
        PlayerPreferenceController.SetDifficulty(difficultySlider.value);
        // при нажатии кнопки Back возвращаемся в Main Menu.
        FindObjectOfType<LevelLoader>().LoadMainMenuScene();
    }

    // метод для настройки громкости и сложности по умолчанию.
    private void SetDefaults()
    {
        // делаем настройки звука по умолчанию, нажимая кнопку Defaults в игре.
        volumeSlider.value = defaultVolume;
        // делаем настройки сложности по умолчанию, нажимая кнопку Defaults в игре.
        difficultySlider.value = defaultDifficulty;
    }
}
