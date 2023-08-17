using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectableController : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;
    
    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" +  coinCount;
        coinEndDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;
        WinGame();
    }

    public void WinGame()
    {
        if(coinCount >= 10)
        {
            Debug.Log("You Won!");
            //play cutscene showing the rat running into the restaurant
        }
    }
}
