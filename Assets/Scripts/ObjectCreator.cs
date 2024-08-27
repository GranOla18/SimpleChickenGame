using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public Transform puntoDeInstancia;
    public GameObject objetoACrear;

    public List<GameObject> objetosCreados;

    // Start is called before the first frame update
    void Start()
    {
        objetosCreados = new List<GameObject>();
        StartCoroutine(RutinaInstanciarObjeto());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RutinaInstanciarObjeto()
    {
        float tiempoTranscurrido = 0;
        while (true)
        {
            tiempoTranscurrido += Time.deltaTime;

            bool hayObjDesactivados = false;

            for(int i = 0; i < objetosCreados.Count; i++)
            {
                if (!objetosCreados[i].activeInHierarchy)
                {
                    objetosCreados[i].SetActive(true);
                    hayObjDesactivados = true;
                    break;
                }
            }

            if(!hayObjDesactivados)
                objetosCreados.Add(Instantiate(objetoACrear, puntoDeInstancia.position, Quaternion.identity));
            
            yield return new WaitForSeconds(5);
        }
    }
}
