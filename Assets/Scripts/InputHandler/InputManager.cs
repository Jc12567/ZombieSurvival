using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }
    private Controls controls;

    public Vector2 move { get; private set; }
    public Vector2 look { get; private set; }

    public bool wantSprint { get; private set; } = false;
    public bool wantCrouch { get; private set; } = false;
    public bool wantInteract { get; private set; } = false;
    public bool wantUse { get; private set; } = false;
    public bool wantExtra { get; private set; } = false;
    public bool wantDrop { get; private set; } = false;
    public bool wantJump { get; private set; } = false;

    [Header("Movement")]
    [SerializeField]
    private bool holdSprint = true;
    [SerializeField]
    private bool holdCrouch = true;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        controls = new Controls();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    
            controls.Main.Move.performed += controls => move = controls.ReadValue<Vector2>();
            controls.Main.Look.performed += controls => look = controls.ReadValue<Vector2>();

            controls.Main.Interact.performed += controls => wantInteract = true;
            controls.Main.Interact.canceled += controls => wantInteract = false;
            controls.Main.Use.performed += controls => wantUse = true;
            controls.Main.Use.canceled += controls => wantUse = false;
            controls.Main.Extra.performed += controls => wantExtra = true;
            controls.Main.Extra.canceled += controls => wantExtra = false;
            controls.Main.Drop.performed += controls => wantDrop = true;
            controls.Main.Drop.canceled += controls => wantDrop = false;
            controls.Main.Jump.performed += controls => wantJump = true;
            controls.Main.Jump.canceled += controls => wantJump = false;

            if (holdSprint)
            {
                controls.Main.Sprint.performed += controls => wantSprint = true;
                controls.Main.Sprint.canceled += controls => wantSprint = false;
            }
            else
            {
                controls.Main.Sprint.performed += controls => wantSprint = !wantSprint;
            }
            if (holdCrouch)
            {
                controls.Main.Crouch.performed += controls => wantCrouch = true;
                controls.Main.Crouch.canceled += controls => wantCrouch = false;
            }
            else
            {
                controls.Main.Crouch.performed += controls => wantCrouch = !wantCrouch;
            }
    }
}
