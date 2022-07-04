using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

//    public static int powerUpCount;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 180*Time.deltaTime, 0);
    }
}
