using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenManager : MonoBehaviour
{
    public float health;
    public AudioClip damage;
    public AudioClip victory;

    public Image healthBar;
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "poisonMushroom")
        {
            AudioSource.PlayClipAtPoint(damage, transform.position);
            StartCoroutine(RutinaRecibirDanio(health, health - 0.1f));
            health -= 10;
            Debug.Log("Poision Mushroom!");
            Debug.Log("Health: " + health);
            Destroy(other.gameObject);
        }

        else if(other.tag == "Nest")
        {
            AudioSource.PlayClipAtPoint(victory, transform.position);
            Debug.Log("Juego Terminado");
        }
    }

    public IEnumerator RutinaRecibirDanio(float valInicial, float valFinal)
    {
        float tiempoTranscurrido = 0;

        while (tiempoTranscurrido < 3)
        {
            health = Mathf.Lerp(valInicial, valFinal, tiempoTranscurrido / 3);
            healthBar.fillAmount = health;
            healthBar.color = gradient.Evaluate(1 - health);
            tiempoTranscurrido += Time.deltaTime;
            Debug.Log("Procesando");
            //Obliga a que cada ciclo del while se ejecute en un frame
            yield return new WaitForEndOfFrame();
        }
    }
}
