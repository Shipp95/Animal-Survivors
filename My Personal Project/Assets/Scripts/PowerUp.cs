using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public static int powerUpCount;
    // Start is called before the first frame update

    private void Awake()
    {
        powerUpCount++;
    }

    // Update is called once per frame
    void Update()
    {
        //the power up with go up and down over time
        transform.Translate(Vector3.forward * 0.2f * Mathf.Sin(Time.time) * Time.deltaTime);
    }
}
