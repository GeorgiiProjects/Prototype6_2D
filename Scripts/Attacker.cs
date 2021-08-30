using UnityEngine;

public class Attacker : MonoBehaviour
{
    // слайдер регулирования скорости перемещения префабов Kitty и NPC1 в инспекторе.
    [Range(0f, 3f)]
    // переменная для регулирования скорости передвижения префабов Kitty и NPC1.
    [SerializeField] float currentSpeed = 1f;
    // префабы Crafty Bot, Defender, Shrine и Trophy которые будут атакованы префабами Kitty и NPC1.
    GameObject currentTarget;

    // происходит в первую очередь до метода Start()
    private void Awake()
    {
        // получаем доступ к скрипту LevelController и выполняем метод спавна префабов Kitty и NPC1.
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // происходит в последнюю очередь после всех методов.
    private void OnDestroy()
    {
        // получаем доступ к скрипту LevelController.
        LevelController levelController = FindObjectOfType<LevelController>();
        // если префаб со скриптом LevelController все еще существует (не является нулем)
        if (levelController != null)
        {
            // выполняем метод уничтожения префабов Kitty и NPC1.
            levelController.AttackerDestroyed();
        }
    }

    void Update()
    {
        // Префабы Kitty и NPC1 двигаются справа налево каждый фрейм, с одинаковой скоростью на всех пк.
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        // префаб Kitty или NPC1 продолжает движение.
        UpdateAnimationState();
    }

    // метод для того чтобы префаб Kitty или NPC1 начал двигаться после уничтожения префаба Crafty Bot или Defender, или Shrine, или Trophy.
    private void UpdateAnimationState()
    {
        // если префабы Crafty Bot или Defender, или Shrine, или Trophy отсутствуют.
        if (!currentTarget)
        {
            // получаем доступ к аниматору префаба Kitty или NPC1, начинаем движение после уничтожения префаба дефендера.
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    // создаем метод с параметром скорость, скорость назначается в animation event префабов Kitty и NPC1.
    private void SetMovementSpeed(float speed)
    {
        // присваиваем значение 1 в переменную currentSpeed из speed (в animation event).
        currentSpeed = speed;
    }

    // публичный метод для смены анимации в префабах Kitty и NPC1 на атакующую с параметром обнаружения префабов Crafty Bot, Defender, Shrine и Trophy. 
    // метод будет вызываться в скрипте NpcOne и Kitty.
    public void Attack(GameObject target)
    {
        // Получаем доступ к аниматору префабов Kitty и NPC1 и начинаем анимацию атаки на префабы Crafty Bot или Defender, или Shrine, или Trophy.
        GetComponent<Animator>().SetBool("IsAttacking", true);
        // префабы Crafty Bot, Defender, Shrine и Trophy, которые будут атакованы префабами Kitty и NPC1.
        currentTarget = target;
    }

    // метод для нанесения урона префабам Crafty Bot, Defender, Shrine и Trophy, с параметром урона.
    // урон назначается в animation event префабов NpcOne и Kitty.
    private void StrikeCurrentTarget(float damage)
    {
        // если префабы Crafty Bot, Defender, Shrine и Trophy отсутствуют
        if (!currentTarget)
        {
            // ничего не делаем.
            return;
        }
        // получаем доступ к скрипту Health в префабах Crafty Bot, Defender, Shrine и Trophy.
        Health health = currentTarget.GetComponent<Health>();
        // если у префабов Crafty Bot, Defender, Shrine и Trophy есть компонент/скрипт здоровье.
        if (health)
        {
            // наносится урон префабам Crafty Bot, Defender, Shrine и Trophy.
            health.DealDamage(damage);
        }
    }
}
