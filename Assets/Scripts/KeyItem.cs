using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    public Component doorCollider;
    public GameObject bodyGone;
    public GameObject gunGone;
    public GameObject skullGone;
    public GameObject theText;

    public int amountOfEvidence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E) && gunGone)
        {
            gunGone.SetActive(false);
            amountOfEvidence++;

        }

        if (Input.GetKey(KeyCode.E) && skullGone)
        {
            skullGone.SetActive(false);
            amountOfEvidence++;

        }

        if (Input.GetKey(KeyCode.E) && bodyGone)
        {
            bodyGone.SetActive(false);
            amountOfEvidence++;
            
        }
    }

}
