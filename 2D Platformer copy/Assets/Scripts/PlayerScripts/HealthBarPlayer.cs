using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField]
    private Image[] HealthBar;

    [SerializeField]
    private Image[] DeathBar;

    private int healthBarRemover = 0;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        for(int i = 0; i< HealthBar.Length;i++)
        {
            HealthBar[i].enabled = true;
        }

        for (int i = 0; i < HealthBar.Length; i++)
        {
            DeathBar[i].enabled = false;
        }

    }

    public void TakeDamageBar()
    {
        healthBarRemover += 1;
        HealthBar[HealthBar.Length - healthBarRemover].enabled = false;
        DeathBar[HealthBar.Length - healthBarRemover].enabled = true;
        if(healthBarRemover == DeathBar.Length)
        {
            playerMovement.Death();
        }
    }
}
