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

    public bool isBody;
    public bool isGun;
    public bool isSkull;

    public int amountOfEvidence;

    public KeyItemCounter evidenceRef;

    // Start is called before the first frame update
    void Start()
    {

    }

    //  if (amountOfEvidence == 3)
      //      {
       //         doorCollider.GetComponent<BoxCollider>().enabled = true;
        //        theText.SetActive(true);
       //     }

// Update is called once per frame
void OnTriggerStay(Collider other)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("this is not E");
            if (other.transform.tag == "Player")
            {
                print("this is E");
                if (isBody == true)
                {
                    print ("this is happenign");
                    evidenceRef.itemCount += 1;
                    Destroy(this.gameObject);
                }
                else if (isSkull == true)
                {
                    print("this is happenign");
                    evidenceRef.itemCount += 1;
                    Destroy(this.gameObject);
                }
                else if (isGun == true)
                {
                    print("this is happenign");
                    evidenceRef.itemCount += 1;
                    Destroy(this.gameObject);
                }
            }
        }
    }

}
