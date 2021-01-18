using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStarter : MonoBehaviour
{
    private bool player;
    private WheelJoint2D[] wheels;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player==true)
        {
            wheels = gameObject.GetComponentsInChildren<WheelJoint2D>();

            foreach (var wheel in wheels)
            {
                wheel.GetComponent<WheelJoint2D>().useMotor = true;
            }
            player = false;
        }
    }
}
