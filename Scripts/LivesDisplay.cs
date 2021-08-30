using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    // кол-во жизней при старте игры, используем float так как если будем использовать int могут быть различные ошибки.
    [SerializeField] float baseLives = 4;
    // столько жизней отнимается если префаб Kitty или NPC1 добираются до префаба DamageCollider.
    [SerializeField] int reducingLives = 1;
    // переменная для определения кол-ва жизней при выборе уровня сложности.
    float lives;
    // инициализируем компонент текст префаба Main Canvas - Lives Text.
    Text livesText;

    void Start()
    {
        // кол-во жизней со старта игры в зависимости от уровня сложности, высчитывается например 3-0 easy, 3-1 normal, 3-2 hard, итд.
        lives = baseLives - PlayerPreferenceController.GetDifficulty();
        // получаем доступ к полю Text в Main Canvas - Lives Text.
        livesText = GetComponent<Text>();
        // обновляем количество жизней со старта игры.
        UpdateDisplay();
    }

    // метод обновления жизней
    private void UpdateDisplay()
    {
        // обновляем жизни, конвертируя число в строку.
        livesText.text = lives.ToString();
    }

    // публичный метод для убавления начального кол-ва жизней. Метод будет вызываться в скрипте DamageCollider.
    public void TakeLife()
    {
        // когда префаб Kitty или NPC1 добираются до префаба DamageCollider, убавляем кол-во жизней.
        lives -= reducingLives;
        // отображаем на экране убавление жизней.
        UpdateDisplay();
        // если жизней <= 0
        if(lives <= 0)
        {
            // получаем доступ к скрипту LevelController и запускаем префаб Level Lost Canvas.
            FindObjectOfType<LevelController>().HadnleLoseCondition();
        }
    }
}
