using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    Chasing Chasing;
    public GameObject Enemigo;
    public bool escondido = false;
    public Camera CamPrincipal;
    public float normal, cerca,tiempo;

    void Start()
    {
       Chasing = Enemigo.GetComponent<Chasing>();
    }

   
    private void Update()
    {
        if (escondido)
        {
            Chasing._playerAwarenessDistance = 0;
            CamPrincipal.GetComponent<Camera>().fieldOfView = Mathf.Lerp(CamPrincipal.fieldOfView,cerca, tiempo*Time.deltaTime);
        }
        else
        {
            Chasing._playerAwarenessDistance = 13;
            CamPrincipal.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cerca, normal, tiempo*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            escondido = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            escondido = false;

        }
    }
}
