using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [Header("Selectable cars")]
    [SerializeField] private Sprite[] _cars;

    [Header("Selector buttons")]
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _prevBtn;

    [Header("SO")]
    [SerializeField] private GameData _gameData;

    [Header("Player ID")]
    [SerializeField] private int playerId;

    private int selected = 0;

    void Start()
    {
        Button next = _nextBtn.GetComponent<Button>();
        next.onClick.AddListener(Next);
        Button prev = _prevBtn.GetComponent<Button>();
        prev.onClick.AddListener(Prev);

        if (next == null)
        {
            Debug.LogError("Next button is NULL");
        }
        if (prev == null)
        {
            Debug.LogError("Prev button is NULL");
        }
        if (_cars == null)
        {
            Debug.LogError("Cars is NULL");
        }
        if (_gameData == null)
        {
            Debug.LogError("Gamedata is NULL");
        }
        if (playerId == 0) 
        {
            Debug.LogError("Player ID not set");
        }
    }

    void Update()
    {
        gameObject.GetComponent<Image>().sprite = _cars[selected];
        if (playerId == 1)
        {
            _gameData.Player1 = _cars[selected];
        }
        if (playerId == 2)
        {
            _gameData.Player2 = _cars[selected];
        }
    }

    public void Next()
    {
        if (selected < _cars.Length -1) 
        {
            selected++;
        }
    }

    private void Prev()
    {
        if (selected > 0)
        {
            selected--;
        }
    }
}
