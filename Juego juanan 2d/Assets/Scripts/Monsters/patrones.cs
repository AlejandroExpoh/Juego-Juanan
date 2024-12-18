using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrones : MonoBehaviour
{
    public float speed = 5;
    //public Rigidbody2D rb;
    //public BoxCollider2D gridarea;
    public Vector3[] posiciones;
    Vector3 positionWander;
    public Transform EnemigoWander;
    int i = 0;

    void Start()
    {
        positionWander = posiciones[i];
    }

    private void Update()
    {
        positionWander = posiciones[i];
        transform.position = positionWander;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            if(i != 3)
            {
                i += 1;
            }
            else
            {
               i = 0;
            }

        }
    }
}
