using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectieCollision : MonoBehaviour
{
    public TextMeshProUGUI count;
    public int currentcount;

    void Start()
    {
        count.text = "Shield: " + currentcount.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            currentcount += 1;
            count.text = "Shield: " + currentcount.ToString();
        }
    }
}
