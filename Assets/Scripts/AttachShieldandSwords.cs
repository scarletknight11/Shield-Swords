using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachShieldandSwords : MonoBehaviour {

    public GameObject child;

    public Transform parent;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            // Sets "newParent" as the new parent of the child GameObject.
            child.transform.SetParent(parent);
        }
    }
}
