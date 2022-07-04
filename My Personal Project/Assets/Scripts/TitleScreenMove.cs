using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenMove : MonoBehaviour
{
    [SerializeField] int speed;

    /*
       This script moves forward the chicken object and rotates it 180 degrees on trigger to create back-and-forth movement

    */
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.Rotate(0, 180, 0);
    }

}
