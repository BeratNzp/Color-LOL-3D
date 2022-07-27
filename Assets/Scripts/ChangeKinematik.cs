using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKinematik : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Object" || other.tag == "Obstacle")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }
}
