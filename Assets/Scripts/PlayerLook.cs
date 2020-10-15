using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float lookClampMax = -80f;
    [SerializeField] float lookClampMmin = 80f;

    [SerializeField] Transform cameraRootObject;
    Vector3 cameraRootPositionStart;
    [SerializeField] PlayerMove move;

    [SerializeField] float xRotation = 0f;

    [SerializeField] Vector3 deathOffset = Vector3.zero;
    [SerializeField] float deathSpeed = 20f;

    Camera camera;
    Vector3 cameraPositionStart;
    Transform playerBody;
    Player player;

    void Start()
    {
        // maybe can simplify these..?
        camera = cameraRootObject.gameObject.GetComponentInChildren<Camera>();
        playerBody = GetComponentInChildren<Transform>();
        cameraRootPositionStart = cameraRootObject.localPosition;
        cameraPositionStart = camera.gameObject.transform.localPosition;
        player = GetComponentInChildren<Player>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!player.IsDead)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, lookClampMax, lookClampMmin);

            if (cameraRootObject != null) cameraRootObject.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            if (playerBody != null) playerBody.Rotate(Vector3.up * mouseX);
        }
        else camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, cameraPositionStart + deathOffset, Time.deltaTime * deathSpeed);
    }
}
