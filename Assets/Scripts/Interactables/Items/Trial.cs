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
    protected override void HandleAnimation()
    {
        if (activated)
        {
            Quaternion rotation = Quaternion.Euler(speed, speed, speed);
            transform.rotation *= rotation;
        }
    }

    protected override void HandleUse()
    {
        if(activated && input.wantUse)
        {
            transform.Translate(parent.forward);
        }
        if(activated && input.wantExtra)
        {
            transform.Translate(-parent.forward);
        }
    }
    protected override void Init()
    {
        transform.position = parent.position;
        transform.parent = parent;
    }
}
