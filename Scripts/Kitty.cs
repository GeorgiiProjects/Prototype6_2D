using UnityEngine;

public class Kitty : MonoBehaviour
{
    // метод для взаймодействия коллайдера префаба Kitty с коллайдером префабов Crafty Bot, Defender, Shrine и Trophy.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // игровой объект у которого есть коллайдер.
        GameObject otherObject = other.gameObject;

        // если игровой объект имеет компонент/скрипт Shrine.
        if (otherObject.GetComponent<Shrine>())
        {
            // тогда меняем анимацию префаба Kitty на прыжок.
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        // или же игровой объект имеет компонент/скрипт Defender.
        else if (otherObject.GetComponent<Defender>())
        {
            // Тогда получаем доступ к скрипту Attacker и атакуем префабы Crafty Bot, Defender и Trophy.
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
