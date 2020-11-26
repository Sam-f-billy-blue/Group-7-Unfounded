using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemCounter : MonoBehaviour
{
    public Component doorCollider;
    public GameObject theText;

    public bool openTheDoor = false;
    public int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = 4;
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (itemCount >= 3 && openTheDoor == false)
        {
            doorCollider.GetComponent<BoxCollider>().enabled = true;
            theText.SetActive(true);
            openTheDoor = true;
        }
    }

}
