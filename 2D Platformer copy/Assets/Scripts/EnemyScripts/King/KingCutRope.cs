using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCutRope : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderer;

    private Animator animator;

    private int dialogueNumber = 1;

    private bool dialogueStarted;

    private PlayerMovement playerMovement;

    private Rigidbody2D Player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void CutRope()
    {
        Player.velocity = new Vector2(0, 0);
        animator.SetTrigger("Attack");
        StartCoroutine(StopAttack());
    }

    private void StartDialogue()
    {
        playerMovement.canMove = false;
        dialogueStarted = true;
        if (dialogueNumber < 4)
        {
            if (dialogueNumber != 1)
            {
                spriteRenderer[dialogueNumber - 1].enabled = false;
            }
            spriteRenderer[dialogueNumber].enabled = true;
        }
    }

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("StopAttack");
        StartDialogue();
    }

    private void Update()
    {
        if(dialogueNumber>3)
        {
            for (int i = 1; i <= 3; i++)
            {
                Destroy(spriteRenderer[i]);
            }
            playerMovement.canMove = true;
        }

        if(dialogueStarted == true)
        {
            if(Input.anyKeyDown)
            {
                dialogueNumber++;
                StartDialogue();
            }
        }
    }
}