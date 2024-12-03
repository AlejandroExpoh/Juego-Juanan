using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScenes : MonoBehaviour
{
    public int IndiceScena;
    public void Cambio()
    {
        SceneManager.LoadScene(IndiceScena);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cambio();
        }
    }
}
