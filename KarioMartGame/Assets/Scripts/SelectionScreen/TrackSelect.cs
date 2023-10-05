using UnityEngine;
using UnityEngine.UI;

public class TrackSelect : MonoBehaviour
{
    [Header("Selectable tracks")]
    [SerializeField] private Sprite[] _tracks;

    [Header("Selector buttons")]
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _prevBtn;

    [Header("SO")]
    [SerializeField] private GameData _gameData;

    private int selected = 0;

    void Start()
    {
        Button next = _nextBtn.GetComponent<Button>();
        next.onClick.AddListener(Next);
        Button prev = _prevBtn.GetComponent<Button>();
        prev.onClick.AddListener(Prev);
    }

    void Update()
    {
        gameObject.GetComponent<Image>().sprite = _tracks[selected];
        _gameData.TrackId = selected;
    }

    public void Next()
    {
        if (selected < _tracks.Length - 1)
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
