using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float fireSpeed;

    [SerializeField]
    private Transform firePoint;

    private BoxCollider2D[] physicalPush;

    public void Shoot(int dir)
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        physicalPush = currentBullet.GetComponents<BoxCollider2D>();
        StartCoroutine(AlmightyPush());
        StartCoroutine(BulletDestroyer(currentBullet));

        if(dir >= 0)
        {
            currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
        }
        if (dir < 0)
        {
            currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
        }
    }

    IEnumerator BulletDestroyer(GameObject currentBullet)
    {
        yield return new WaitForSeconds(0.62f);
        {
            Destroy(currentBullet);
        }
    }

    IEnumerator AlmightyPush()
    {
        yield return new WaitForSeconds(0.03f);
        {
            foreach(BoxCollider2D boxcollider in physicalPush)
            {
                boxcollider.enabled = true;
            }
        }
    }
}
