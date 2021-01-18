using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionSliderJoint : MonoBehaviour
{
    private SliderJoint2D Platform;
    private Rigidbody2D PlatformHolder;
    // Start is called before the first frame update
    void Start()
    {
        Platform = GetComponent<SliderJoint2D>();
        PlatformHolder = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Point"))
        {
            StartCoroutine(ChangeDirection());
        }
    }

    IEnumerator ChangeDirection()
    {
        //Platform.enabled = false;
        PlatformHolder.velocity = Vector2.zero;
        PlatformHolder.isKinematic = true;

        yield return new WaitForSeconds(4f);

        PlatformHolder.isKinematic = false;
        //Platform.enabled = true;
        JointMotor2D motor = Platform.motor;
        motor.motorSpeed = -Platform.motor.motorSpeed;
        Platform.motor = motor;
    }
}