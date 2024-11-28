using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    Chasing Chasing;
    public GameObject Enemigo;
    public bool escondido = false;

    void Start()
    {
       Chasing = Enemigo.GetComponent<Chasing>();
    }
    private void Update()
    {
        if (escondido)
        {
            Debug.Log("Entra");
            Chasing._playerAwarenessDistance = 0;
        }
        else
        {
            Debug.Log("Sale");
            Chasing._playerAwarenessDistance = 13;
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
