using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // переменная ожидания загрузки следующего уровня 4 секунды.
    [SerializeField] float waitToLoad = 4f;
    // поместим в инспекторе в префаб Level Controller префаб Level Complete Canvas.
    [SerializeField] GameObject winLabel;
    // поместим в инспекторе в префаб Level Controller префаб Level Lost Canvas.
    [SerializeField] GameObject loseLabel;
    // количество префабов Kitty и NPC1 при завершении уровня.
    public int numberOfAttackers = 0;
    // заполнен ли слайдер таймера, по умолчанию нет.
    bool levelTimerFinished = false;

    private void Start()
    {
        // при старте игры Level Complete Canvas отключен.
        winLabel.SetActive(false);
        // при старте игры Level Lost Canvas отключен.
        loseLabel.SetActive(false);
    }

    // публичный метод спавна префабов Kitty и NPC1 будет вызываться в скрипте Attacker.
    public void AttackerSpawned()
    {
        // кол-во префабов Kitty и NPC1 увеличивается.
        numberOfAttackers++;
    }
    
    // публичный метод уничтожения префабов Kitty и NPC1 будет вызываться в скрипте Attacker.
    public void AttackerDestroyed()
    {
        // кол-во префабов Kitty и NPC1 уменьшается.
        numberOfAttackers--;
        // если кол-во префабов Kitty и NPC1 <= 0 и таймер/слайдер заполнен.
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            // запускаем курутину для загрузки следующего уровня и выполнений условий по окончанию уровня.
            StartCoroutine(HadnleWinCondition());
        }
    }
    
    // создаем интерфейс/курутину для того чтобы использовать таймер загрузки следующего уровня и выполнений условий по окончанию уровня.
    IEnumerator HadnleWinCondition()
    {
        // Level Complete Canvas включен, когда мы побеждаем.
        winLabel.SetActive(true);
        // победная музыка играет, когда мы побеждаем.
        GetComponent<AudioSource>().Play();
        // запускаем следующий уровень через 4 секунды после уничтожения последнего префаба Kitty или NPC1.
        yield return new WaitForSeconds(waitToLoad);
        // получаем доступ к скрипту LevelLoader и его методу загрузки следующего уровня.
        FindObjectOfType<LevelLoader>().LoadNextScene();       
    }

    // публичный метод включения Level lost Canvas будет вызываться в скрипте LivesDisplay.
    public void HadnleLoseCondition()
    {
        // Level lost Canvas включен.
        loseLabel.SetActive(true);
        // останавливаем время/игру (движение всех префабов), когда проигрываем и не позволяем кликать по ним мышкой.
        Time.timeScale = 0;
    }

    // публичный метод действий когда слайдер заполнен, будет вызываться в скрипте SliderTimer.
    public void LevelTimerFinished()
    {
        // слайдер заполнен
        levelTimerFinished = true;
        // останавливаем спавн префабов Kitty и NPC1.
        StopSpawners();
    }
    
    // метод остановки спавна префабов Kitty и NPC1.
    private void StopSpawners()
    {
        // получаем доступ ко всем пяти линиям префабов Spawners содержащих в себе префабы Kitty и NPC1, через массив.
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        // для каждой линии префабов Spawners содержащих в себе префабы Kitty и NPC1 в массиве.
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            // Все пять линии префабов Spawners содержащих в себе префабы Kitty и NPC1 перестают спавниться.
            spawner.StopSpawning();
        }
    }
}
