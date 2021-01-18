using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMover : MonoBehaviour
{
    private FixedJoint2D Fixed;
    private int p = 1;
    // Start is called before the first frame update
    void Start()
    {
        Fixed = GetComponent<FixedJoint2D>();
        StartCoroutine(SetForce());
    }

    IEnumerator SetForce()
    {
        if(Fixed != null)
        {
            p = 360;
        }
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1) * p, Random.Range(-1, 1) * p));
        StartCoroutine(SetForce());
    }
}
