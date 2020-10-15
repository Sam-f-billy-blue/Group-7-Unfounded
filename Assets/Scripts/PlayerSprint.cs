using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    PlayerMove playerSprint;
        public float speedBoost = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerSprint = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            playerSprint.moveSpeed += speedBoost;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            playerSprint.moveSpeed -= speedBoost;
    }
}
