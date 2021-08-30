using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    // количество звезд при старте игры.
    [SerializeField] int stars = 500;
    // инициализируем компонент текст в префабе Main Canvas - Star Text.
    Text starText;

    void Start()
    {
        // получаем доступ к полю Text в префабе Main Canvas - Star Text.
        starText = GetComponent<Text>();
        // обновляем количество звезд со старта игры.
        UpdateDisplay();
    }

    // метод обновления количества звезд.
    private void UpdateDisplay()
    {
        // обновляем кол-во звёзд, конвертируя число в строку.
        starText.text = stars.ToString();
    }

    // публичный метод для проверки достаточно ли у нас звезд для покупки дефендера с параметром нужного количества звезд (очков).
    // метод будет вызываться в скрипте DefenderSpawner.
    public bool HaveEnoughStars(int amount)
    {
        // если звезд >= кол-ва звезд нужного для покупки префаба Crafty Bot или Defender, или Shrine, или Trophy, то мы можем их покупать.
        return stars >= amount;
    }

    // публичный метод для прибавления звезд (очков) с параметром нужного количества звезд (очков). Метод будет вызываться в скрипте Defender.
    public void AddStars(int amount)
    {
        // прибавляем 15 звезд каждую секунду.
        stars += amount;
        // отображаем на экране прибавление звезд.
        UpdateDisplay();
    }

    // публичный метод для траты звезд с параметром нужного количества звезд (очков). Метод будет вызываться в скрипте DefenderSpawner.
    public void SpendingStars(int amount)
    {
        // если звезд >= стоимости покупки пребафа Crafty Bot или Defender, или Shrine, или Trophy.
        if (stars >= amount)
        {
            // когда происходит покупка пребафа Crafty Bot или Defender, или Shrine, или Trophy убавляем кол-во звезд.
            stars -= amount;
            // отображаем на экране убавление звезд.
            UpdateDisplay();
        }       
    }
}
