using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [System.Serializable]
    public enum DoorState
    {
        Closed,
        Closing,
        Opening,
        Open,
        Blocked,
        Jammed,
        Locked
    }
    public DoorState doorState;

    [System.Serializable]
    public enum KeyRequired
    {
        none,
        grey,
        gold
    }
    public KeyRequired keyRequired;

    [SerializeField] GameObject door;
    [SerializeField] Switch doorSwitch;
    [SerializeField] float moveDistance = 0.95f;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float autoCloseTime = 3f;
    [SerializeField] string playerTag = "Player";
    [SerializeField] string agentTag = "Enemy";
    [SerializeField] bool doorOpen = false;
    [SerializeField] bool doorBlocked = false;
    [SerializeField] KeyCode interactKey = KeyCode.Space;

    [Header("Audio")]
    [SerializeField] AudioClip doorClip;
    [SerializeField] AudioClip lockedClip;
    

    [Header("DEBUGGING - Don't Set")]
    [SerializeField] Vector3 closedPosition;
    [SerializeField] Vector3 openPosition;
    [SerializeField] bool doorLocked = false;
    [SerializeField] bool deadBlocked = false;

    [SerializeField] bool keyPressed = false;
    [SerializeField] bool doOnce = false;
    [SerializeField] float time = 0f;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        if (door != null)
        {
            closedPosition = door.transform.localPosition;
            openPosition = closedPosition;
            openPosition.z = openPosition.z + moveDistance;
        }
        if (doorState == DoorState.Locked) doorLocked = true;
    }

    void Update()
    {
        // this is hacked out of another project and only works for one-way triggered doors

        if (doorSwitch.switchOn && doorState != DoorState.Opening && doorState != DoorState.Open)
        {
            doorState = DoorState.Opening;

            if (doorState != DoorState.Locked)
            {
                doorOpen = !doorOpen;
                time = 0f;
                if (audioSource != null && doorClip != null)
                {
                    audioSource.clip = doorClip;
                    audioSource.Play();
                }
            }
            else
            {
                if (audioSource != null && doorClip != null)
                {
                    audioSource.clip = lockedClip;
                    audioSource.Play();
                }
            }
        }
        if (doorState != DoorState.Open || doorState != DoorState.Closed || doorState != DoorState.Locked || doorState != DoorState.Jammed) MoveDoor();
    }

    void MoveDoor()
    {
        if (doorState != DoorState.Jammed)
        {
            if (doorState == DoorState.Opening && door.transform.localPosition != openPosition)
            {
                time += Time.deltaTime / moveSpeed;
                door.transform.localPosition = Vector3.Lerp(closedPosition, openPosition, time);
            }
            else if (doorState == DoorState.Opening && door.transform.localPosition == openPosition)
            {
                doorOpen = true;
                doorState = DoorState.Open;
                time = 0f;
            }
            if (doorState == DoorState.Closing && door.transform.localPosition != closedPosition)
            {
                time += Time.deltaTime / moveSpeed;
                door.transform.localPosition = Vector3.Lerp(openPosition, closedPosition, time);
            }
            else if (doorState == DoorState.Closing && door.transform.localPosition == closedPosition)
            {
                doorOpen = false;
                doorState = DoorState.Closed;
                time = 0f;
            }
        }
    }
}
