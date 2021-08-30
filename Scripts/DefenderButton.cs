using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    // в инспекторе в Buttons - Background будем помещать префабы Crafty Bot, Defender, Shrine и Trophy.
    [SerializeField] Defender defenderPrefab;
   
    private void Start()
    {
        // вызываем метод при старте игры.
        LabelButtonWithCost();
    }

    // метод отображения стоимости префабов Crafty Bot, Defender, Shrine и Trophy.
    private void LabelButtonWithCost()
    {
        // получаем доступ к тексту у префабов Crafty Bot, Defender, Shrine и Trophy в их дочерних объектах Cost.
        Text costText = GetComponentInChildren<Text>();
        // если текст со стоимостью отсутсвует.
        if (!costText)
        {
            //Debug.LogError("No cost text!");
        }
        // иначе
        else
        {
            // заносим стоимость префабов Crafty Bot, Defender, Shrine и Trophy в поле объекта Cost и конвертируем их из числа в строку.
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    // метод нажатия левой кнопкой мыши.
    private void OnMouseDown()
    {
        // получаем доступ к префабу Buttons в инспекторе через массив.
        var buttons = FindObjectsOfType<DefenderButton>();
        // для каждой кнопки находящейся в Buttons, для активации префабов Crafty Bot, Defender, Shrine и Trophy.
        foreach (DefenderButton button in buttons)
        {
            // цвет по умолчанию пока не кликнули по префабам Crafty Bot, Defender, Shrine и Trophy.
            button.GetComponent<SpriteRenderer>().color = new Color32(106, 106, 106, 255);
        }
        // меняем цвет префабов Crafty Bot, Defender, Shrine и Trophy с черного на белый при клике на них.
        GetComponent<SpriteRenderer>().color = Color.white;
        // получаем доступ к скрипту DefenderSpawner и выбираем нужный префаб для спавна из Crafty Bot, Defender, Shrine и Trophy.
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
