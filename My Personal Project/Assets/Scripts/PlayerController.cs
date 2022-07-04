using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed;
    private Rigidbody playerRb;
    Animator animator;

    
    public static Vector3 worldPosition;
    public GameObject projectile;
    Plane plane = new Plane(Vector3.up, 0);
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        if(GameManager.isGameActive==true)
        transform.LookAt(worldPosition);


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //movementDirection.Normalize();

        if(GameManager.isGameActive == true)
        transform.Translate(movementDirection * speed * Time.deltaTime,Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 1);

        }
        else
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }




    private void Shoot()
    {
        if (GameManager.isGameActive ==true)
            Instantiate(projectile, transform.position+Vector3.up*1.5f, projectile.transform.rotation);
    }
    
}
