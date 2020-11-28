using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] bool isDead = false;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

   // public Transform thePlayer;

  //  int pickupLayerMask;
  //  [SerializeField] Image pickupPopup;

    [SerializeField] string enemyTag = "Enemy";

   // private void Start()
   // {
   //   pickupLayerMask = LayerMask.GetMask("Pickup");
//
   //   DisablePickupPopup();
   // }

  //  private void Update()
  //  {
  //      RaycastHit hittingTheItems;
  //      if (Physics.Raycast(thePlayer.transform.position, thePlayer.transform.forward, out hittingTheItems, 1f))
  //      {
  //          EnablePickupPopup();
  //      }
  //      else
  //      {
  //          DisablePickupPopup();
  //      }
  //  }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag ("Enemy"))
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

   // void EnablePickupPopup()
   // {
    //    pickupPopup.gameObject.SetActive(true);
    //}

   // void DisablePickupPopup()
  //  {
   //     pickupPopup.gameObject.SetActive(false);
   // }

}
