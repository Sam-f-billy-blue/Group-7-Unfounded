using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script from SpeedTutor [Youtube] https://www.youtube.com/watch?v=tB_ihytqGpo

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
}
