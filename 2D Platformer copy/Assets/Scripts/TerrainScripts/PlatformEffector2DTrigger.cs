using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffector2DTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject StoneHolder;

    [SerializeField]
    private KingCutRope kingCutRope;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            kingCutRope.CutRope();
            StartCoroutine(Destroyer());
        }
    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(StoneHolder);
        Destroy(gameObject);
    }
}
