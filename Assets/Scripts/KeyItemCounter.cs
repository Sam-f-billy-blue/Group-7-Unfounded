using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemCounter : MonoBehaviour
{
    public Component doorCollider;
    public GameObject firstGone;
    public GameObject secondGone;
    public GameObject thirdGone;
    public GameObject theText;

    private int howManyAreThere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay()
    {

        if (Input.GetKey(KeyCode.E) && firstGone)
        {
            firstGone.SetActive(false);
            howManyAreThere += 1;

            if (howManyAreThere <= 1 && secondGone)
            {
                secondGone.SetActive(false);
                howManyAreThere += 1;

                if (howManyAreThere == 2 && thirdGone)
                {
                    theText.SetActive(true);
                    thirdGone.SetActive(false);
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && firstGone)
        {
            firstGone.SetActive(false);
            howManyAreThere += 1;

            if (howManyAreThere <= 1 && thirdGone)
            {
                thirdGone.SetActive(false);
                howManyAreThere += 1;

                if (howManyAreThere == 2 && secondGone)
                {
                    theText.SetActive(true);
                    secondGone.SetActive(false);
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && secondGone)
        {
            secondGone.SetActive(false);
            howManyAreThere += 1;

            if (howManyAreThere <= 1 && firstGone)
            {
                firstGone.SetActive(false);
                howManyAreThere += 1;

                if (howManyAreThere == 2 && thirdGone)
                {
                    theText.SetActive(true);
                    thirdGone.SetActive(false);
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && secondGone)
        {
            secondGone.SetActive(false);
            howManyAreThere += 1;

            if (howManyAreThere <= 1 && thirdGone)
            {
                thirdGone.SetActive(false);
                howManyAreThere += 1;

                if (howManyAreThere == 2 && firstGone)
                {
                    theText.SetActive(true);
                    firstGone.SetActive(false);
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && thirdGone)
        {
            thirdGone.SetActive(false);
            howManyAreThere += 1;

            if (howManyAreThere <= 1 && firstGone)
            {
                firstGone.SetActive(false);
                howManyAreThere += 1;

                if (howManyAreThere == 2 && secondGone)
                {
                    theText.SetActive(true);
                    secondGone.SetActive(false);
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && thirdGone)
        {
            thirdGone.SetActive(false);
            howManyAreThere += 1;

            if (howManyAreThere <= 1 && secondGone)
            {
                secondGone.SetActive(false);
                howManyAreThere += 1;

                if (howManyAreThere == 2 && firstGone)
                {
                    theText.SetActive(true);
                    firstGone.SetActive(false);
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

    }

}
