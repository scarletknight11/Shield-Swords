using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    public TextMeshProUGUI Hitcount;
    public int currentcount;

    // Start is called before the first frame update
    void Start()
    {
        Hitcount.text = "Hit: " + currentcount.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            currentcount += 1;
            Hitcount.text = "Hit: " + currentcount.ToString();
        }
    }
}
