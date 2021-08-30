using UnityEngine;

public class Projectile : MonoBehaviour
{

    // скорость движения префабов Hatchet и Shovel.
    [SerializeField] float speed = 7f;
    // количество урона наносимых префабами Hatchet и Shovel.
    [SerializeField] float damage = 50f;

    void Update()
    {
        // направление полета префабов Hatchet и Shovel вправо по оси x * со скоростью 7 * на любом пк двигается с одинаковой скоростью.
        transform.Translate(Vector2.right * speed * Time.deltaTime); 
    }

    // метод взаимодействия коллайдеров префабов Hatchet и Shovel и префабов Kitty и NPC1.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // получаем доступ к коллайдеру из скрипта Health.
        var health = other.GetComponent<Health>();
        // получаем доступ к коллайдеру из скрипта Attacker.
        var attacker = other.GetComponent<Attacker>();
        // Если коллайдеры префабов Kitty и NPC1 взаимодействуют с коллайдерами префабов Hatchet и Shovel.
        if (attacker && health)
        {
            // уменьшаем здоровье префабов Kitty и NPC1.
            health.DealDamage(damage);
            // уничтожаем префабы Hatchet и Shovel.
            Destroy(gameObject);
        }     
    }
}
