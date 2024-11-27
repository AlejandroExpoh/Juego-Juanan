using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    Chasing Chasing;
    public Collider2D player;
    public bool escondido = false;

    void Start()
    {
       Chasing = GetComponent<Chasing>();
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        escondido = true;
        if (escondido)
        {
            Chasing._playerAwarenessDistance = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        escondido=false;
        if (!escondido)
        {
            Chasing._playerAwarenessDistance = 11;
        }
    }
}
