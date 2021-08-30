using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // переменная для спавна префабов Kitty и NPC1, по умолчанию активна.
    bool spawn = true;
    // минимальная задержка спавна префабов Kitty и NPC1.
    [SerializeField] float minSpawnDelay = 1f;
    // максимальная задержка спавна префабов Kitty и NPC1.
    [SerializeField] float maxSpawnDelay = 5f;
    // инициализируем массив Attacker для того чтобы в инспекторе помещать в него только префабы Kitty и NPC1.
    [SerializeField] Attacker[] attackerPrefabArray;

    // Курутина для спавна префабов Kitty и NPC1.
    IEnumerator Start()
    {
        // пока префабы Kitty и NPC1 спавнятся.
        while (spawn)
        {
            // префабы Kitty и NPC1 спавнятся рандомно от 1 до 5 секунд.
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            // запускаем метод случайного спавна префабов Kitty и NPC1.
            SpawnAttacker();
        }
    }

    // публичный метод остановки спавна префабов Kitty и NPC1 будет вызываться в скрипте LevelController.
    public void StopSpawning()
    {
        // префабы Kitty и NPC1 перестают спавниться.
        spawn = false;
    }

    //  метод для случайного спавна префабов Kitty и NPC1.
    void SpawnAttacker()
    {
        // количество рандомно отспавненых префабов Kitty и NPC1 будет от 0 до количества занесеных в массив префабов Kitty и NPC1.
        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        // спавним один рандомный префаб атакера из массива.
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    // метод для копирования префабов Kitty и NPC1 с параметром myattacker чтобы понимать что именно мы копируем.
    private void Spawn(Attacker myattacker)
    {
        // копируем префабы Kitty и NPC1, в координатах нахождения префабов Kitty и NPC1, поворот оставляем по умолчанию.
        Attacker newAttacker = Instantiate(myattacker, transform.position, transform.rotation) as Attacker;
        // определяем в какой линии в префабе Spawners находятся префабы Kitty и NPC1, для того чтобы префабы Crafty Bot и Defender
        // могли определить следует ли атаковать данную линию или нет, есть на ней аттакер в данный момент или нет.
        newAttacker.transform.parent = transform;
    }
}
