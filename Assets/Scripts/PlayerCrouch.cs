using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    /* CharacterController playerCol; 
    float originalHeight; 
    public float reducedHeight; */


    // new crouch code proudly yoinked from  

    private CharacterController m_CharacterController;
    private Camera m_Camera;
    private float target_height = 1.6f;
    private float previous_y = 0;
    private bool is_crouching = false;

    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
    }
    private void Update()
    {
        previous_y = m_CharacterController.transform.position.y - m_CharacterController.height / 2 - m_CharacterController.skinWidth;
        //previous_y = 0f; 
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (is_crouching == false)
            {
                is_crouching = true;
                target_height = 0.9f;
            }
            else
            {
                is_crouching = false;
                target_height = 1.6f;
            }
        }
        m_CharacterController.height = Mathf.Lerp(m_CharacterController.height, target_height, 5f * Time.deltaTime);

        m_Camera.transform.position = Vector3.Lerp(m_Camera.transform.position, new Vector3(m_Camera.transform.position.x, m_CharacterController.transform.position.y + target_height / 2 - 0.1f, m_Camera.transform.position.z), 5f * Time.deltaTime);

        m_CharacterController.transform.position = Vector3.Lerp(m_CharacterController.transform.position, new Vector3(m_CharacterController.transform.position.x, previous_y + target_height / 2 + m_CharacterController.skinWidth, m_CharacterController.transform.position.z), 5f * Time.deltaTime);
    }
}



// old crouch


/*CharacterController playerCol;
float originalHeight;
public float reducedHeight;

void Start()
{
    playerCol = GetComponent<CharacterController>();
    originalHeight = playerCol.height;
}


void Update()
{
    if (Input.GetKeyDown(KeyCode.LeftControl))
        Crouch();
    else if (Input.GetKeyUp(KeyCode.LeftControl))
        GoUp();
}

void Crouch()
{
    playerCol.height = reducedHeight;
}


void GoUp()
{
    playerCol.height = originalHeight;
}*/