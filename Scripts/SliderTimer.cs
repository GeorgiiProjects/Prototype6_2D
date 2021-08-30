using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    // при наведении мыши на Level Time в префабе Slider будем видеть надпись Our level timer in seconds.
    [Tooltip("Our level timer in seconds")]
    // префабы Kitty и NPC1 будут спавниться 10 секунд. т.е. длительность уровня будет 10 секунд.
    [SerializeField] float levelTime = 10f;
    // узнаем закончен уровень или нет (по умолчанию нет).
    bool triggeredLevelFinished = false;

    void Update()
    {
        // если уровень закончен
        if (triggeredLevelFinished)
        {
            // дальнейшая часть кода не выполняется так как уровень закончен.
            return;
        }
        // получаем доступ к слайдеру и его компоненту value в которое передаем значение из формулы получаем 5/10 = 0.5 секунд,
        // эта формула позволяет заполнить слайдер от 0 до 10 секунд, со старта уровня.
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        // таймер/слайдер останавливается когда значение timeSinceLevelLoad становится >= levelTime
        // т.е. уровень может длиться не более 10 секунд в нашем случае.
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        // если слайдер заполнился
        if (timerFinished)
        {
            // получаем доступ к скрипту LevelController и выполняем действия при заполненом слайдере.
            FindObjectOfType<LevelController>().LevelTimerFinished();
            // когда слайдер заполнен уровень заканчивается.
            triggeredLevelFinished = true;
        }
    }
}
