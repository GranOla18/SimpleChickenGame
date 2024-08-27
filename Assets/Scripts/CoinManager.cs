using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public AudioClip coinSound;
 
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position); 
    }
}
