using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // переменная для задержки загрузки следующего уровня, после уровня Splash Screen.
    [SerializeField] int timeToWait = 3;
    // номер текущей сцены, какой уровень сейчас запущен.
    int currentSceneIndex;

    private void Start()
    {
        // узнаем номер текущей сцены через класс SceneManager, получаем доступ к активной сцене через метод GetActiveScene() и номер сцены buildIndex.
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // если номер текущей сцены 0
        if(currentSceneIndex == 0)
        {
            // запускаем курутину с загрузкой уровня Start Screen через 3 секунды после уровня Splash Screen.
            StartCoroutine(WaitForTime());
        }    
    }

    // создаем курутину/интерефейс для загрузки уровня Start Screen через 3 секунды после уровня Splash Screen.
    IEnumerator WaitForTime()
    {
        // запускаем уровень Start Screen через 3 секунды после Splash Screen.
        yield return new WaitForSeconds(timeToWait);
        // запускаем следующую сцену (уровень).
        LoadNextScene();
    }

    // метод для перезапуска текущей сцены.
    private void LoadRestartScene()
    {
        // когда перезапускаем уровень, время и префабы активируются.
        Time.timeScale = 1;
        // перезапускаем текущую сцену после проигрыша.
        SceneManager.LoadScene(currentSceneIndex);
    }

    // публичный метод для запуска уровня Main Menu, будет вызываться в скрипте OptionsController.
    public void LoadMainMenuScene()
    {
        // когда переходим в уровень Main Menu, время и префабы активируются.
        Time.timeScale = 1;
        // запускаем уровень Main Menu после проигрыша.
        SceneManager.LoadScene(1);
    }

    // метод для запуска следующей сцены, будет вызываться в скрипте LevelController.
    public void LoadNextScene()
    {
        // запускаем уровень Start Screen после уровня Splash Screen.
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // метод запуска опций игры.
    private void LoadOptionsScene()
    {
        // Запускаем опции из меню.
        SceneManager.LoadScene(4);
    }

    // метод запуска уровня конец игры.
    private void LoadGameOverScene()
    {
        // запускаем уровнь конец игры.
        SceneManager.LoadScene(5);
    }

    // метод выхода из игры.
    private void LoadQuitGame()
    {
        // выходим из игры.
        Application.Quit();
    }
}
