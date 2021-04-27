using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : Interactable
{
    [Header("Usage")]
    [SerializeField]
    private float power = 2f;

    [Header("Animation")]
    [SerializeField]
    private float speed = 2f;

    public Transform childTransform;
    protected override void HandleAnimation()
    {
        if (activated)
        {        
            Debug.Log(childTransform.gameObject.name);
            Quaternion rotation = Quaternion.Euler(speed, speed, speed);
            childTransform.rotation *= rotation;
        }
    }

    protected override void HandleUse()
    {
        if(activated && input.wantUse)
        {
            transform.Translate(parent.forward * power, transform);
        }
        if(activated && input.wantExtra)
        {
            transform.Translate((transform.position - parent.position), transform);
        }
    }
    protected override void Init()
    {
        transform.position = parent.position;
        transform.parent = parent;
    }
}
