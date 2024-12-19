using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitarpanel : MonoBehaviour
{
    public int Tiempo;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Quitarpanel", Tiempo);
    }

    // Update is called once per frame

    public void Quitarpanel()
    {
        gameObject.SetActive(false);
    }
   
}
