using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public AudioClip[] clipSonido;
    public AudioSource audioSource;

    public float volumenMusica;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        volumenMusica = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReproducirSonido(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            subirVolumen();
        }
    }

    public void ReproducirSonido(int indiceClip)
    {
        //audioSource.Play();
        audioSource.PlayOneShot(clipSonido[indiceClip]);
    }

    public void subirVolumen()
    {
        volumenMusica += 5;
        mixer.SetFloat("VolumenMusica", volumenMusica);
    }

    public void AsignarVolumen(float numero)
    {
        Debug.Log("Estoy cambiando el volumen a: " + numero);
        mixer.SetFloat("VolumenMusica", numero);
    }
}
