using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorWithE : MonoBehaviour
{
    // Code Base courtesy of https://www.youtube.com/watch?v=iIBvTPC610M

    public Transform thePlayer;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 2;

    private bool isItOpen = false;
    private Animator moveJigga;

    [SerializeField] Image pickupPopup;

    private void Start()
    {
        DisablePickupPopup();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }

        RaycastHit hittingTheDoor;
        if (Physics.Raycast(thePlayer.transform.position, thePlayer.transform.forward, out hittingTheDoor, 2f))
        {
            EnablePickupPopup();
        } else
        {
            DisablePickupPopup();
        }

    }

    void Pressed()
    {
        RaycastHit hittingTheDoor;

        if (Physics.Raycast(thePlayer.transform.position, thePlayer.transform.forward, out hittingTheDoor, MaxDistance))
        {
         
            if (hittingTheDoor.transform.tag == "Door")
            {
                moveJigga = hittingTheDoor.transform.GetComponentInParent<Animator>();

                isItOpen = !isItOpen;

                moveJigga.SetBool("Opened", isItOpen);
            }
        }
    }

    void EnablePickupPopup()
    {
        pickupPopup.gameObject.SetActive(true);
    }
    void DisablePickupPopup()
    {
        pickupPopup.gameObject.SetActive(false);
    }
}

//YouTube Channel Twin Gaming Studios :P