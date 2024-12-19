using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScenes : MonoBehaviour
{
    public string NameScena;
    public Vector2 spawnPoint;

    public void Cambio()
    {
        PlayerPrefs.SetString("Entrada", NameScena);
        PlayerPrefs.SetFloat("SpawnX", spawnPoint.x);
        PlayerPrefs.SetFloat("SpawnY", spawnPoint.y);

        SceneManager.LoadScene(NameScena);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cambio();
        }
    }
}
