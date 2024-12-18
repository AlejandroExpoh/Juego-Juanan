using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    public int escena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("meteorito"))
        {
            SceneManager.LoadScene(escena);
        }
        if (collision.CompareTag("meteorito"))
        {
            SceneManager.LoadScene(escena);
        }
    }
}
