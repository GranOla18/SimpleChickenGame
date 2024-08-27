using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public LineRenderer lineaRender;
    public GameObject decal;
    Ray rayo;
    RaycastHit choque;

    private void FixedUpdate()
    {
        rayo.origin = transform.position;
        rayo.direction = transform.forward;

        if (Physics.Raycast(rayo, out choque))
        {
            Debug.DrawLine(rayo.origin, choque.point, Color.red);
            lineaRender.SetPosition(0, rayo.origin);
            lineaRender.SetPosition(1, choque.point);

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.DrawRay(rayo.origin, rayo.direction * 10);
                Debug.Log("El rayo esta en colision " + choque.collider);
                GameObject pivoteObjeto = Instantiate(decal, choque.point, Quaternion.identity);
                pivoteObjeto.transform.forward = -choque.normal;
            }
        }
        else
        {

            lineaRender.SetPosition(0, rayo.origin);
            lineaRender.SetPosition(1, rayo.origin + (rayo.direction * 10));
            Debug.DrawRay(rayo.origin, rayo.direction * 10, Color.blue);
        }
    }
}
