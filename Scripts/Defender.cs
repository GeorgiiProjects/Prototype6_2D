using UnityEngine;

public class Defender : MonoBehaviour
{
    // стоимость вызова префаба Crafty Bot или Defender, или Shrine, или Trophy.
    [SerializeField] int starCost = 100;

    // публичный метод получения стоимости префабов Crafty Bot, Defender, Shrine и Trophy.
    // метод будет вызываться в скрипте DefenderSpawner и DefenderButton.
    public int GetStarCost()
    {
        // получаем стоимость префабов Crafty Bot, Defender, Shrine и Trophy.
        return starCost;
    }

    // метод для прибавления звезд (очков) с параметром нужного количества звезд (очков).
    public void AddStars(int amount)
    {
        // получаем доступ к скрипту StarDisplay и его методу прибавления звёзд c параметром количества прибавления звезд.
        // количество прибавленных звезд назначаем в animation event префаба Trophy.
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}
