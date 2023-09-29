using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _returningCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            StartCoroutine(ReturningCounterCourotine());
        }
    }

    IEnumerator ReturningCounterCourotine()
    {
        _returningCounter.text = "5";
        yield return new WaitForSeconds(1);
        _returningCounter.text = "4";
        yield return new WaitForSeconds(1); 
        _returningCounter.text = "3";
        yield return new WaitForSeconds(1); 
        _returningCounter.text = "2";
        yield return new WaitForSeconds(1); 
        _returningCounter.text = "1";
        yield return new WaitForSeconds(1); 
        _returningCounter.text = "0";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0); // Title screen
    }
}
