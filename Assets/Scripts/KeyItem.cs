using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public Component doorCollider;
    public GameObject bodyGone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.E))
        doorCollider.GetComponent<BoxCollider>().enabled = true;

        if(Input.GetKey(KeyCode.E))
        bodyGone.SetActive(false);
    }
}
