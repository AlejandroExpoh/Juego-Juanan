using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform personaje;
    public float cameraDistance = 30f;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(personaje.position.x, personaje.position.y, personaje.position.z -10);
    }
}
