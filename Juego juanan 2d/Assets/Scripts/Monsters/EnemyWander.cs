using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float speed = 5;
    //public Rigidbody2D rb;
    public BoxCollider2D gridarea;
    Vector3 positionWander;

    void Start()
    {
       InvokeRepeating("randompos", 0, speed);
    }
    public void randompos()
    {
        Bounds limites = gridarea.bounds;

        float x = Random.Range(limites.min.x, limites.max.x);
        float y = Random.Range(limites.min.y, limites.max.y);
        positionWander = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
        transform.position = positionWander;
        Debug.Log(positionWander);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            randompos();
        }
    }

}
