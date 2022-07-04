using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    private Rigidbody projRb;
    Vector3 throwPos;
    float speed=10;
    float rotationSpeed;
    float timeStart;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //when projectile is created, find player object to determine throw direction
        //and start counting time to track how long is the projectile in the air,
        //and propel projectile
        player = GameObject.Find("Player");
        throwPos = player.transform.forward;
        timeStart = Time.time;

        projRb = gameObject.GetComponent<Rigidbody>();
        projRb.AddForce(throwPos*speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()//when the projectile is thrown, rotate it and destroy it after 2 seconds
    {
        transform.Rotate(0, 0, 0.5f);
        if (Time.time>(timeStart+ 2))
        {
            Destroy(gameObject);
        }
    }
}
