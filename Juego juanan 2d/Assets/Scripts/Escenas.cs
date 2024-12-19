using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public int Tiempo;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("IralJuego", Tiempo);
    }

    // Update is called once per frame
   
    public void IralJuego()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}

