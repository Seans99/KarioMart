using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelect : MonoBehaviour
{
    [SerializeField] private Sprite[] _tracks;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _prevBtn;

    [SerializeField] private GameData _gameData;

    private int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        Button next = _nextBtn.GetComponent<Button>();
        next.onClick.AddListener(Next);
        Button prev = _prevBtn.GetComponent<Button>();
        prev.onClick.AddListener(Prev);
    }

    // Update is called once per frame
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
