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
            gameObject.transform.localPosition += transform.parent.forward * power;
        }
        if(activated && input.wantExtra)
        {
            gameObject.transform.localPosition -= transform.parent.forward * power;
        }
    }
}
