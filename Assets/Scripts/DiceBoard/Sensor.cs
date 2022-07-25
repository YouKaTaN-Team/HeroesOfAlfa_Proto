using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Sensor : MonoBehaviour
{
    public int Value;
    public bool sensorIsActive;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Board>())
        {
            sensorIsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Board>())
        {
            sensorIsActive = false;
        }
    }
}
