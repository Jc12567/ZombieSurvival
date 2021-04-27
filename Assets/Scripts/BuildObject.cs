using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public GameObject player;

    public void buildRaft()
    {
        Debug.Log("NOW IMAGINE A RAFT HERE");

        if (player.GetComponent<PlayerController>().handItem.tag == "BuildRaft")
        {
            //place raft object
        }
    }

    public void buildCar()
    {
        Debug.Log("NOW IMAGINE A CAR HERE");

        if (player.GetComponent<PlayerController>().handItem.tag == "BuildCar")
        {
            //place car object
        }
    }
}
