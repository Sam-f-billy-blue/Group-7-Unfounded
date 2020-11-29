using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class KeyItem : MonoBehaviour
{

    public Component doorCollider;
    public GameObject bodyGone;
    public GameObject gunGone;
    public GameObject skullGone;
    public GameObject theText;

    public bool isBody;
    public bool isGun;
    public bool isSkull;

    public int amountOfEvidence;

    public KeyItemCounter evidenceRef;

    public Transform thePlayer;
    [SerializeField] Image pickupPopup;

    // Start is called before the first frame update
    void Start()
    {
        DisablePickupPopup();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {

        EnablePickupPopup();
        if (Input.GetKeyDown(KeyCode.E))
        {
            //  print("this is not E");
            if (other.transform.tag == "Player")
            {
                // print("this is E");
                if (isBody == true)
                {
                    //print ("this is happenign");
                    evidenceRef.itemCount += 1;
                    Destroy(this.gameObject);
                    DisablePickupPopup();
                }
                else if (isSkull == true)
                {
                    //print("this is happenign");
                    evidenceRef.itemCount += 1;
                    Destroy(this.gameObject);
                    DisablePickupPopup();
                }
                else if (isGun == true)
                {
                    //print("this is happenign");
                    evidenceRef.itemCount += 1;
                    Destroy(this.gameObject);
                    DisablePickupPopup();
                }
            }
        }
        Invoke("DisablePickupPopup", 3);
        //DisablePickupPopup();

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
