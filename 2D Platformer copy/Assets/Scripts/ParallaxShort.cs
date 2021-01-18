using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxShort : MonoBehaviour
{
    private GameObject Player;

    private float parallaxShort = 11f;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(-Player.transform.position.x / parallaxShort, transform.position.y);
    }
}