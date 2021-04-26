using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private InputManager input;
    private CharacterController controller;

    [Header("Movement")]
    [SerializeField]
    private float gravity = -9.81f;
    private bool grounded;
    private Vector3 velocity;
    [SerializeField]
    private float jumpHeight = 1f;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private float runSpeed = 7f;
    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float crouchSpeed = 2f;
    private bool awayEdge;
    private float speed = 5f;
    [SerializeField]
    private float edgeRadius = 0.4f;

    [Header("Objects")]
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform crouchCheck;
    [SerializeField]
    private Transform interactCheck;
    [SerializeField]
    private Transform mainCamera;
    [SerializeField]
    private Transform rightHand;
    [SerializeField]
    private Transform leftHand;

    [Header("Interact")]
    [SerializeField]
    private float interactDistance = 2f;
    [SerializeField]
    public GameObject handItem;
    [SerializeField]
    private GameObject placeholderHandItem;
    [SerializeField]
    private LayerMask interactableLayer;
    [SerializeField]
    private TMP_Text tooltipText;
    [SerializeField]
    public bool isLeftHanded = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = InputManager.instance;
    }
    private void HandleMovement(float delta)
    {
        Vector3 movement = (input.move.x * transform.right) + (input.move.y * transform.forward);
        if (input.wantCrouch)
        {
            speed = crouchSpeed;
            awayEdge = Physics.CheckSphere(crouchCheck.position, edgeRadius, groundLayer);
            if (!awayEdge)
            {
                    WaitUntil.Equals(awayEdge, true);
            }
            else
            {
                controller.Move(movement * speed * delta);
            }
        }
        else if (input.wantSprint)
        {
            speed = runSpeed;
            controller.Move(movement * speed * delta);
        }
        else
        {
            speed = walkSpeed;
            controller.Move(movement * speed * delta);
        }
    }
    private void HandleGravity(float delta)
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (Physics.CheckSphere(groundCheck.position, groundDistance, interactableLayer))
        {
            grounded = true;
        }
        if (grounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * delta;
            controller.Move(velocity * delta);
        }
    }
    private void HandleJump()
    {
        if (grounded && input.wantJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    private void HandleInteract()
    {
        RaycastHit raycastHit;
        GameObject item;
        bool canInteract = Physics.Raycast(mainCamera.position, mainCamera.forward, out raycastHit, interactDistance, interactableLayer);
        if (canInteract)
        {
            item = raycastHit.collider.gameObject;
            tooltipText.SetText("Press 'E' to interact with " + item.name);
            if (input.wantInteract)
            {
                if (item.name == "Build Area")
                {
                    if (item.tag == "BuildRaft")
                    {
                        //build raft code
                    }
                    else if (item.tag == "BuildCar")
                    {
                        //build car code
                    }
                }
                else
                {
                    handItem = item;
                    handItem.GetComponent<Interactable>().Activate();
                    if (!isLeftHanded)
                    {
                        item.transform.SetParent(mainCamera);
                        item.transform.localPosition = rightHand.localPosition;
                        item.transform.localRotation = rightHand.localRotation;
                    }
                    else
                    {
                        item.transform.SetParent(mainCamera);
                        item.transform.localPosition = leftHand.localPosition;
                        item.transform.localRotation = leftHand.localRotation;
                    }
                }
            }
        }
        else
        {
            tooltipText.SetText("");
        }
    }

    private void HandleDrop()
    {
        if (input.wantDrop)
        {
            handItem.transform.SetParent(null);
            handItem.gameObject.GetComponent<Interactable>().Deactivate();
            handItem = placeholderHandItem;
        }
    }

    // Update is called once per fram
    private void FixedUpdate()
    {
        HandleGravity(Time.deltaTime);
        HandleMovement(Time.deltaTime);
        HandleJump();
        HandleInteract();
        HandleDrop();
    }
}
