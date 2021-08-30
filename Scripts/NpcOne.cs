using UnityEngine;

public class NpcOne : MonoBehaviour
{
    // метод для взаймодействия коллайдера префаба NPC1 с коллайдером префабов Crafty Bot, Defender, Shrine и Trophy.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // игровой объект у которого есть коллайдер.
        GameObject otherObject = other.gameObject;
        // если игровой объект имеет компонент/скрипт Defender.
        if (otherObject.GetComponent<Defender>())
        {
            // Тогда получаем доступ к скрипту Attacker и атакуем префабы Crafty Bot, Defender, Shrine и Trophy.
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
