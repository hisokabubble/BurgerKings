using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CStoDrink : MonoBehaviour
{
    public float delay = 400;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(delay));
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(4);
    }
}
