using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // метод для соприкосновения коллайдеров префабов Kitty или NPC1 с коллайдером префаба Damage Collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // получаем доступ к скрипту LivesDisplay, когда префаб Kitty или NPC1 соприкасается с префабом DamageCollider, жизни игрока убавляются.
        FindObjectOfType<LivesDisplay>().TakeLife();
        // при столкновении префаба Kitty или NPC1 с префабом DamageCollider, префаб Kitty или NPC1 уничтожаются.
        Destroy(other.gameObject);
    }
}
