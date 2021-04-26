using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public GameObject player;

    public void buildRaft()
    {
        if (player.GetComponent<PlayerController>().handItem.tag == "BuildRaft")
        {
            //place raft object
        }
    }

    public void buildCar()
    {
        if (player.GetComponent<PlayerController>().handItem.tag == "BuildCar")
        {
            //place car object
        }
    }
}
