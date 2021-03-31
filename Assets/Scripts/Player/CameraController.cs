using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private InputManager input;

    [Header("GameObjects")]
    [SerializeField]
    private Transform player;

    [Header("Sensitivity")]
    [SerializeField]
    private bool linkedSensitivity = false;
    [SerializeField]
    private float hSensitivity = 100f;
    [SerializeField]
    private float vSensitivity = 100f;
    [SerializeField]
    private float sensitivity = 100f;

    [Header("Zoom")]
    [SerializeField]
    private float sprintFOV = 45f;
    [SerializeField]
    private float regularFOV = 60f;
    [SerializeField]
    private float crouchFOV = 80f;

    private float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
        Cursor.lockState = CursorLockMode.Locked;
        if (linkedSensitivity)
        {
            hSensitivity = sensitivity;
            vSensitivity = sensitivity;
        }
    }
    private void HandleLook(float delta)
    {

        float mouseX;
        float mouseY;

        if (hSensitivity == vSensitivity)
        {
            mouseX = (sensitivity * delta * input.look.x);
            mouseY = (sensitivity * delta * input.look.y);
        }
        else
        {
            mouseX = (hSensitivity * delta * input.look.x);
            mouseY = (vSensitivity * delta * input.look.y);
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up, mouseX);
    }

    private void HandleSprintZoom()
    {
        if (input.wantSprint)
        {
            GetComponent<Camera>().fieldOfView = sprintFOV;
        } 
        else if (input.wantCrouch)
        {
            GetComponent<Camera>().fieldOfView = crouchFOV;
        }
        else
        {
            GetComponent<Camera>().fieldOfView = regularFOV;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleLook(Time.deltaTime);
        HandleSprintZoom();
    }
}
