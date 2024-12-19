using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public static Musica instanciaMusica;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (instanciaMusica != null && instanciaMusica != this)
        {
            Destroy(gameObject);
        } 
        else
        {
            instanciaMusica = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
