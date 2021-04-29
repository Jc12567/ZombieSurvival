using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, .6f * Time.deltaTime);  //make the 10f to .1f
        //Debug.Log(.1f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
