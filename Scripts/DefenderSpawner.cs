using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // инициализируем класс для использования в скрипте.
    Defender defender;
    // объект defenderParent в инспекторе имеет название Defenders который содежрит в себе все префабы Crafty Bot, Defender, Shrine и Trophy.
    // для того чтобы префабы находились только в этом объекте, а не по всей ветки иерархии инспектора.
    GameObject defenderParent;
    // все названия с большой буквы так как они являются неизменяемыми константами.
    // DEFENDER_PARENT_NAME это название родительского объекта GameObject defenderParent.
    const string DEFENDER_PARENT_NAME = "Defenders";
    
    private void Start()
    {
        // выполняем со старта игры
        CreateDefenderParent();
    }
    // метод создания родительского объекта с названием Defenders в инспекторе, в котором будут все префабы Crafty Bot, Defender, Shrine и Trophy.
    private void CreateDefenderParent()
    {
        // получаем доступ к объекту Defenders в иерархии.
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        // если объект Defenders не существует в иерархии.
        if (!defenderParent)
        {
            // создаем новый объект Defenders в иерархии при старте игры.
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    // метод нажатия левой кнопки мыши
    private void OnMouseDown()
    {
        // при клике мышкой спавниться дефендер в нужных нам координатах.
        AttemptToPlaceDefenderAt(GetSquareClick());
    }

    // метод для выбора дефендера с параметром выбора префабов Crafty Bot, Defender, Shrine и Trophy.
    // метод публичный так как будем его вызывать в скрипте DefenderButton.
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        // Выбираем нужный префаб из Crafty Bot, Defender, Shrine и Trophy и передаем значение в текущий выбор дефендера.
        defender = defenderToSelect;
    }

    // метод покупки дефендера в нужной позиции.
    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        // получаем доступ к скрипту StarDisplay.
        var starDisplay = FindObjectOfType<StarDisplay>();
        // префабы Crafty Bot, Defender, Shrine и Trophy будут стоить.
        int defenderCost = defender.GetStarCost();
        // если у нас достаточно звезд для покупки префаба Crafty Bot или Defender, или Shrine, или Trophy.
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            // спавним префаб дефендера в нужной позиции.
            SpawnDefender(gridPos);
            // тратим количество звезд, которое стоит определенный дефендер.
            starDisplay.SpendingStars(defenderCost);
        }
    }

    // метод для клика левой кнопкой мыши.
    private Vector2 GetSquareClick()
    {
        // задаем позиции клика мыши по осям х и у.
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // конвертируем значения клика по осям х и у в ScreenToWorldPoint, для того чтобы понимать точно в каких координатах идет клик.
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        // конвертируем координаты мыши в точные координаты сетки например по оси х=3, по оси у=2.
        Vector2 gridPos = SnapToGrid(worldPos);
        // получаем результат в точных координатах например по оси х=2, по оси у=3.
        return gridPos;
    }

    // метод для конвертирования координат появления префабов Crafty Bot, Defender, Shrine и Trophy
    // с параметром для появления в точных координатах например х=2, у=2.
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        // конвертируем координаты появления префабов всех defender из float в int по оси х, чтобы появлялся в точных координатах например 2,4.
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        // конвертируем координаты появления префабов всех defender из float в int по оси у, чтобы появлялся в точных координатах например 4,2.
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        // получаем нужный результат в целых числах.
        return new Vector2(newX, newY);
    }

    // метод для спавна префабов Crafty Bot, Defender, Shrine и Trophy, с параметром клика в координатах мыши.
    private void SpawnDefender(Vector2 roundedPos)
    {
        // копируем префабы Crafty Bot, Defender, Shrine и Trophy, координаты в которых будут спавниться префабы, поворот оставляем по умолчанию.
        Defender newDefender = Instantiate(defender, roundedPos, transform.rotation) as Defender;
        // создаем префабы Crafty Bot, Defender, Shrine и Trophy как дочерний объект, объекта Defenders в иерархии.
        newDefender.transform.parent = defenderParent.transform;
    }
}
