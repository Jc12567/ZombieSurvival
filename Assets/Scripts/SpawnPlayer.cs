using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;

    public GameObject playerPrefab;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Spawn()
    {
        if(player != null)
        {
            return;
        }

        player = Instantiate(playerPrefab, transform.position, transform.localRotation);
    }
}
