using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] bool smoothMove = false;

    [SerializeField] bool enableGravity = true;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] bool enableDrag = true;

    [SerializeField] bool enableJump = false;
    [SerializeField] float jumpHeight = 0.25f;

    [Header("Do NOT set. Debug:")]
    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGrounded;

    [SerializeField] bool isMoving = false;
    public bool IsMoving
    {
        get { return isMoving; }
    }

    [SerializeField] CharacterController controller;
    [SerializeField] Vector3 currentPos = Vector3.zero;
    [SerializeField] Vector3 lastPos = Vector3.zero;

    Player player;

    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
        currentPos = transform.position;
        lastPos = transform.position;
        player = GetComponentInChildren<Player>();
    }

    void Update()
    {
        if(enableGravity && controller != null)
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0) velocity.y = -2f;
            if (isGrounded && enableJump && Input.GetButtonDown("Jump")) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float x;
        float z;

        if (smoothMove)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        else // the below clamps values to either on (1f) or off (0f) for when using a keyboard
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
        }

        lastPos = currentPos;
        currentPos = transform.position;
        float distance = Vector3.Distance(currentPos, lastPos);

        if (x > 0f || x < 0f) isMoving = true;
        else if (z > 0f || z < 0f) isMoving = true;
        else isMoving = false;

        if (isMoving && distance > 0.01f) isMoving = true;
        else isMoving = false;

        Vector3 move = transform.right * x + transform.forward * z;
        float speed;
        speed = moveSpeed;
        move = move * speed * Time.deltaTime;

        if (enableDrag)
        {
            Vector3 drag = new Vector3(20f, 20f, 20f);

            move.x /= 1 + drag.x * Time.deltaTime;
            move.y /= 1 + drag.y * Time.deltaTime;
            move.z /= 1 + drag.z * Time.deltaTime;
        }

        if (controller != null && !player.IsDead) controller.Move(move);

        if(enableGravity)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
