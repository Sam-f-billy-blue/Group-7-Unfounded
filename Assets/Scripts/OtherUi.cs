using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUi : MonoBehaviour
{
    public float timeUntilTextDies;

    void Start()
    {
        Destroy(gameObject, timeUntilTextDies);
    }
}
