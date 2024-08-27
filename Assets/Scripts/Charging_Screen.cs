using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charging_Screen : MonoBehaviour
{
    public Image loadingBar;
    public Gradient gradient;
    //public bool loadCompelte;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void loadScene()
    {
        StartCoroutine(startLoading());
        Debug.Log("webos");
    }

    IEnumerator startLoading()
    {
        float tiempoTranscurrido = 0;
        //loadCompelte = false;

        AsyncOperation operation = SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            loadingBar.fillAmount = operation.progress;
            //Evaluate va de 0 - 1
            loadingBar.color = gradient.Evaluate(loadingBar.fillAmount);
            tiempoTranscurrido += Time.deltaTime;

            //if(loadingBar.fillAmount >= 1)
            //{
            //    loadCompelte = true;
            //}

            yield return new WaitForEndOfFrame();
        }
    }
}
