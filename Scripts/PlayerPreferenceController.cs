using UnityEngine;

public class PlayerPreferenceController : MonoBehaviour
{
    // все названия с большой буквы так как они являются неизменяемыми константами.
    // MASTER_VOLUME_KEY выглядит как таблица где в левой части таблицы будет название "master volume".
    const string MASTER_VOLUME_KEY = "master volume";
    // все названия с большой буквы так как они являются неизменяемыми константами.
    // DIFFICULTY_KEY выглядит как таблица где в левой части таблицы будет название "difficulty".
    const string DIFFICULTY_KEY = "difficulty";
    // минимальный уровень громкости игры, все названия с большой буквы так как они являются неизменяемыми константами.
    const float MIN_VOLUME = 0f;
    // максимальный уровень громкости игры, все названия с большой буквы так как они являются неизменяемыми константами.
    const float MAX_VOLUME = 1f;
    // минимальный уровень сложности игры, все названия с большой буквы так как они являются неизменяемыми константами.
    const float MIN_DIFFICULTY = 0f;
    // максимальный уровень сложности игры, все названия с большой буквы так как они являются неизменяемыми константами.
    const float MAX_DIFFICULTY = 2;

    // static так как значения будут одни и те же на протяжении всей игры, например 10 всегда будет 10.
    // static вызывается без использования FindObjectOfType<>.
    // используем параметр float volume так как будем передавать в него значение уровня громкости.
    // метод публичный так как будем вызывать его в скрипте OptionsController.
    public static void SetMasterVolume(float volume)
    {
        // если громкость >= MIN_VOLUME и громкость <= MAX_VOLUME
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            // получаем доступ PlayerPrefs напрямую, не используя FindObjectOfType<>, так как метод статичный.
            // PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume) выглядит как таблица, слева отображается имя "master volume",
            // справа числовое значение уровня громкости например 0 или 1.
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        // иначе
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    // static так как значения не будут изменяться на протяжении всего проекта, например 10 всегда будет 10.
    // метод публичный так как будем вызывать его в скрипте OptionsController и MusicPlayer.
    public static float GetMasterVolume()
    {
        // запускаем уровень громкости с задаными параметрами.
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // static так как значения будут одни и те же на протяжении всей игры, например 10 всегда будет 10.
    // static вызывается без использования FindObjectOfType<>.
    // используем параметр float difficulty так как будем передавать в него значение уровня сложности.
    // метод публичный так как будем вызывать его в скрипте OptionsController.
    public static void SetDifficulty(float difficulty)
    {
        // если уровень сложности >= MIN_DIFFICULTY и уровень сложности <= MAX_DIFFICULTY
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            // получаем доступ PlayerPrefs напрямую, не используя FindObjectOfType<>, так как метод статичный.
            // PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty) выглядит как таблица, слева отображается имя "difficulty",
            // справа числовое значение уровня сложности например 1 или 2.
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        // иначе
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }
    // static так как значения не будут изменяться на протяжении всего проекта, например 10 всегда будет 10.
    // метод публичный так как будем вызывать его в скрипте OptionsController и LivesDisplay.
    public static float GetDifficulty()
    {
        // запускаем уровень сложности с задаными параметрами.
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
