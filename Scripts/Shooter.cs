using UnityEngine;

public class Shooter : MonoBehaviour
{

    // в префаб Defender и префаб Crafty Bot будем помещать префабы Gun, Hatchet или Shovel.
    [SerializeField] GameObject projectile, gun;
    // переменная для выяснения  есть ли префабы Kitty или NPC1 на линии или нет, имеются ли у них дочерние объекты и.т.д.
    AttackerSpawner myLaneSpawner;
    // инициализируем Animator префабов Crafty Bot и Defender.
    Animator animator;
    // объект projectileParent в инспекторе имеет название Projectiles который содежрит в себе все префабы Hatchet и Shovel.
    // для того чтобы префабы находились только в этом объекте, а не по всей ветки иерархии.
    GameObject projectileParent;
    // все названия с большой буквы так как они являются неизменяемыми константами.
    // PROJECTILE_PARENTS_NAME это название родительского объекта GameObject projectileParent.
    const string PROJECTILE_PARENTS_NAME = "Projectiles";

    private void Start()
    {
        // вызываем метод при старте игры.
        SetLaneSpawner();
        // получаем доступ к аниматору префабов Crafty Bot и Defender.
        animator = GetComponent<Animator>();
        // запускаем при старте игры.
        CreateProjectileParent();
    }

    private void Update()
    {
        // если префаб Kitty или NPC1 на линии огня.
        if (IsAttackerInLane())
        {
            // аниматор в префабах Crafty Bot и Defender будет активен и переходить из состояния idle в состояние attacking.
            animator.SetBool("IsAttacking", true);
        }
        // иначе
        else
        {
            // аниматор в префабах Crafty Bot и Defender будет оставаться в состоянии idle.
            animator.SetBool("IsAttacking", false);
        }   
    }

    // метод создания родительского объекта с названием Projectiles в инспекторе, в котором будут все префабы Hatchet и Shovel.
    private void CreateProjectileParent()
    {
        // получаем доступ к объекту Projectiles в иерархии.
        projectileParent = GameObject.Find(PROJECTILE_PARENTS_NAME);
        // если объект Projectiles не существует в иерархии.
        if (!projectileParent)
        {
            // создаем новый объект Projectiles в иерархии при старте игры.
            projectileParent = new GameObject(PROJECTILE_PARENTS_NAME);
        }
    }

    // метод для определения координат, узнаем находятся ли префабы Kitty или NPC1 на линии огня.
    private void SetLaneSpawner()
    {
        // получаем доступ ко всем префабам имеющим скрипт AttackerSpawner через массив.
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        // для каждого префаба Kitty или NPC1 находящегося в префабе Spawner.
        foreach (AttackerSpawner spawner in spawners)
        {
            // узнаем находятся ли префабы Kitty или NPC1 на той же линии что и префабы Crafty Bot, Defender, Shrine или Trophy по оси y.
            // используем Mathf.Epsilon который ищет наименьшее число близкое к нулю, иначе могут появиться баги, если используем просто <=0.
            // (Mathf.Abs()) используется когда мы не хотим получать негативные значения например -3, а только позитивные т.е. -3 становится 3.
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            // если префабы Kitty или NPC1 на той же линии что и префабы Crafty Bot, Defender, Shrine или Trophy по оси y.
            if (IsCloseEnough)
            {
                // можем атаковать префабы Kitty или NPC1, а так же применить какие-либо другие методы к данному полю.
                myLaneSpawner = spawner;
            }
        }
    }

    // метод проверки находятся ли префабы Kitty или NPC1 на линии атаки.
    private bool IsAttackerInLane()
    {
        // если позиция префабов Kitty или NPC1 по y <= 0
        if (myLaneSpawner.transform.childCount <= 0)
        {
            // префабы Kitty или NPC1 не находятся на линии огня.
            return false;
        }
        // иначе
        else
        {
            // префабы Kitty или NPC1 находятся на линии огня.
            return true;
        }
    }

    // метод для атаки префабами Hatchet и Shovel.
    public void Fire()
        {
        // создаем клоны префаба Hatchet или Shovel, в позиции игрового объекта gun, поворот оставляем по умолчанию.
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        // создаем префабы Hatchet или Shovel, как дочерний объект, объекта Projectiles в иерархии инспектора.
        newProjectile.transform.parent = projectileParent.transform;
        }
    }
