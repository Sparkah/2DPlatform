using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    private GameObject Player;
    private CinemachineVirtualCamera cinemachine;

    // Start is called before the first frame update
    void Start()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindGameObjectWithTag("Player");
        cinemachine.Follow = Player.transform;
    }
}
