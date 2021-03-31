using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool activated = false;
    protected InputManager input;
    public void Activate()
    {
        activated = true;
    }
    public void Deactivate()
    {
        activated = false;
    }
    private void Start()
    {
        input = InputManager.instance;
    }
    private void FixedUpdate()
    {
        HandleAnimation();
        HandleUse();
    }
    protected abstract void HandleAnimation();
    protected abstract void HandleUse();
}
