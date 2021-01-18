using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D[] enemyCollider;
    private Health healthEnemy;
    private GameObject Player;
    private HealthBarPlayer healthBarPlayer;

    // Start is called before the first frame update
    void Start()
    {
        healthBarPlayer = GameObject.FindGameObjectWithTag("HealthBarPlayer").GetComponent<HealthBarPlayer>();
        anim = GetComponent<Animator>();
        enemyCollider = GetComponents<BoxCollider2D>();
        healthEnemy = GetComponent<Health>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position)<0.7f)
        {
            anim.SetTrigger("Attack");
        }

        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > 0.7f)
        {
            anim.SetTrigger("AttackBreak");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthEnemy.Damage(1);
            Player.GetComponent<Health>().Damage(1);
            healthBarPlayer.TakeDamageBar();
            TriggerDeath();
        }

        if(collision.CompareTag("Bullet"))
        {
            healthEnemy.Damage(1);
            TriggerDeath();
        }
    }

    private void TriggerDeath()
    {
        if (healthEnemy.isAlive == false)
        {
            foreach(BoxCollider2D collider in enemyCollider)
            {
                Destroy(collider);
            }
            anim.SetTrigger("EnemyDie");
        }
    }
}
