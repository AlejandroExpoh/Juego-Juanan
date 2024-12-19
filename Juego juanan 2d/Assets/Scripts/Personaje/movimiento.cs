using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D personajeRB;
    public float rota = 5f;
    public bool escondido = false;
    float change = .8f;
    float moveX;
    float moveY;
    [SerializeField] private FOV FOV;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Entrada"))
        {
            string entrada = PlayerPrefs.GetString("Entrada");
            float spawnX = PlayerPrefs.GetFloat("SpawnX");
            float spawnY = PlayerPrefs.GetFloat("SpawnY");

            transform.position = new Vector3(spawnX, spawnY, transform.position.z);

            PlayerPrefs.DeleteKey("Entrada");
            PlayerPrefs.DeleteKey("SpawnX");
            PlayerPrefs.DeleteKey("SpawnY");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        rotation();
        if (moveX != 0 || moveY != 0)
        {
            animator.SetBool("Caminar", true);
        }
        else 
        {
            animator.SetBool("Caminar", false);
        }

    }
   
    public void movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        Vector2 fullMovement = new Vector2(moveX, moveY).normalized;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float directchanger = Vector2.Dot(fullMovement, direction);
        float newspeed = directchanger > 0 ? speed : speed * change;
        FOV.SetOrigin(transform.position);
        personajeRB.velocity = fullMovement * newspeed * Time.deltaTime;

    }
    public void rotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        personajeRB.rotation = Mathf.LerpAngle(personajeRB.rotation, angle, rota * Time.deltaTime);
        FOV.SetAimDirection(direction);

    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
 
    
}
