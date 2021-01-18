using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInvis : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            color.a = 0.65f;
            spriteRenderer.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            color.a = 0.99f;
            spriteRenderer.color = color;
        }
    }
}
