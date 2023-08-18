using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CollectableBurger : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;
    public GameObject uWinScreen; // will be replaced with cutscenes

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;
        coinEndDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;
        WinGame();
    }

    public void WinGame()
    {
        if (coinCount == 100)
        {
            Debug.Log("You Won!");
            SceneManager.LoadScene(13);

            //play cutscene showing the rat running into the restaurant
        }
    }
}
