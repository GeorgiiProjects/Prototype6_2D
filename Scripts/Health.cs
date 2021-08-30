using UnityEngine;

public class Health : MonoBehaviour
{
    // начальное кол-во жизней префабов Kitty, NPC1, Crafty Bot, Defender, Shrine и Trophy.
    [SerializeField] float health = 100f;
    // объект в который будем помещать в инспекторе эффект смерти.
    [SerializeField] GameObject deathVFX;

    // публичный метод нанесения урона с параметром количества урона, количество урона инициалиозировано в скрипте Projectile.
    // метод будет вызываться в скриптах Projectile и Attacker.
    public void DealDamage(float damage)
    {
        // 100 здоровья - 50 урона
        health -= damage;
        // если здоровья <= 0
        if(health <= 0)
        {
            // вызываем метод анимации уничтожения префабов Kitty и NPC1.
            TriggerDeathVFX();
            // уничтожаем префабы Kitty, NPC1, Crafty Bot, Defender, Shrine и Trophy.
            Destroy(gameObject);
        }
    }

    // метод для проигрывания анимации уничтожения префабов Kitty и NPC1.
    private void TriggerDeathVFX()
    {
        // если на префабах Kitty и NPC1 отсутствует анимация.
        if (!deathVFX)
        {
            // ничего не делаем.
            return;
        }
        // копируем анимацию смерти, в координатах префабов Kitty и NPC1, поворот анимации оставляем по умолчанию.
        GameObject DeathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        // уничтожаем анимацию через 1 секунду после уничтожения префабов Kitty и NPC1.
        Destroy(DeathVFXObject, 1f);
    }
}
