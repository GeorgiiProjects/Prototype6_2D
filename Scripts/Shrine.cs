using UnityEngine;

public class Shrine : MonoBehaviour
{
    // Скрипт создан для того чтобы можно было использовать анимацию прыжка при взаимодействии префаба Kitty с префабом Shrine.
    // метод взаймодействия коллайдера префаба Shrine с коллайдером префабов Kitty и NPC1 каждый кадр.
    private void OnTriggerStay2D(Collider2D other)
    {
        // префаб Kitty или NPC1 содержат в себе коллайдер и скрипт Attacker.
        Attacker attacker = other.GetComponent<Attacker>();
    }
}
