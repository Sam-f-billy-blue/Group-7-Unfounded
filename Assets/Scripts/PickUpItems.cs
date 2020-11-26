using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{

    public int amountOfEvidence;
    public GameObject evidence;
    public GameObject theDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            evidence.SetActive(false);
            amountOfEvidence++;

            if (amountOfEvidence == 3)
            {
                theDoor.SetActive(true);
            }
        }


    }
}
