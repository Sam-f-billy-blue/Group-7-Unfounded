using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    public Component doorCollider;
    public GameObject bodyGone;
    public GameObject theText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            doorCollider.GetComponent<BoxCollider>().enabled = true;
            theText.SetActive(true);
        }

        if (Input.GetKey(KeyCode.E))
            bodyGone.SetActive(false);
    }
}
