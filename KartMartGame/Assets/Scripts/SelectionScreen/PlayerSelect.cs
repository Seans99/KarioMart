using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] private Sprite[] cars;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button prevBtn;

    private List<Sprite> selectedCars;
    private int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        Button next = nextBtn.GetComponent<Button>();
        next.onClick.AddListener(Next);
        Button prev = prevBtn.GetComponent<Button>();
        prev.onClick.AddListener(Prev);
    }

    void Update()
    {
        gameObject.GetComponent<Image>().sprite = cars[selected];
    }

    public void Next()
    {
        Button next = nextBtn.GetComponent<Button>();

        if (selected < cars.Length -1) 
        {
            selected++;
        }
    }

    private void Prev()
    {
        Button prev = prevBtn.GetComponent<Button>();

        if (selected > 0)
        {
            selected--;
        }
    }

    public void confirmPlayerSelection()
    {
        selectedCars.Add(cars[selected]);
    }
}
