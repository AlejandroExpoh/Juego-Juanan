using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public bool estaPausado = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                Pausa();
            }
            else
            {
                Continuar();
            }
        }
    }

    public void Pausa()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = false;
    }

    public void Continuar()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = true;
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Jugar()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1f;
    }
}
