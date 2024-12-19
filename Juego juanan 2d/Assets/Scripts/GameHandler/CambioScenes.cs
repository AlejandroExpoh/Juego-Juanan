using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScenes : MonoBehaviour
{
    public string NameScena;
    public Transform spawnPoint;

    public void Cambio()
    {
        PlayerPrefs.SetString("Entrada", NameScena);
        PlayerPrefs.SetFloat("SpawnX", spawnPoint.position.x);
        PlayerPrefs.SetFloat("SpawnY", spawnPoint.position.y);

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
