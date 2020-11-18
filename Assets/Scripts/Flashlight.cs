using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public AudioSource clickSound;

    public GameObject Light;
    public bool lightOn;

    void Start()
    {
        Light.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            lightOn = !lightOn;
            Light.SetActive(lightOn);
            clickSound.Play();
        }

    }
}
