using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Wheel"))
        {
            gameObject.GetComponent<PointEffector2D>().enabled = true;
            StartCoroutine(StopExplosion());
        }
    }

    IEnumerator StopExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
