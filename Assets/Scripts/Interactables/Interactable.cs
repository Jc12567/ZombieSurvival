using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool activated = false;
    protected InputManager input;
    protected Transform parent;
    public void Activate(Transform parent)
    {
        activated = true;
        this.parent = parent;
        Init();
    }
    public void Deactivate()
    {
        activated = false;
    }
    private void Start()
    {
        input = InputManager.instance;
    }
    protected virtual void FixedUpdate()
    {
        HandleAnimation();
        HandleUse();
    }
    protected abstract void Init();
    protected abstract void HandleAnimation();
    protected abstract void HandleUse();
}
