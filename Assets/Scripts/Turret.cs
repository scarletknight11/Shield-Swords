using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Turret : MonoBehaviour {

    public bool canAttack;
    public string enemyTag = "Player";
    public float attackRange;

    [Space(15)]
    public Transform target;
    public Transform turretBarrel;
    public float BarrelrotateSpeed;
    [Space(15)]
    public float fireRate = 0.5f;
    public TextMeshProUGUI Hittext;
    public int hitcount;
    float nextFireTime = 1.5f;

    public GameObject bullet;
    //get all the enemies in the range
    //get the cloest enemey
    //rotate the barrell of turrett towards enemy
    //apply damage to eneemy
    //some particles muzzleflash and explosion effect
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //getting all the enemies    
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //Float variable for shortest distance
        float shortestDistance = Mathf.Infinity;
        //Closest enemy
        GameObject closestEnemy = null;

        //loop through every enemy in enemytag
        foreach (GameObject en in enemies)
        {
            //get the distance from turret to each enemy
            float EnemyDistance = Vector3.Distance(transform.position, en.transform.position);
            if(EnemyDistance < shortestDistance)
            {
                //getting distance of cloest eneemy
                shortestDistance = EnemyDistance;
                closestEnemy = en;
            }

            //cloest enemy is found
            //check if we already have found our enemy
            if(closestEnemy != null && shortestDistance <= attackRange && canAttack)
            {
                //some gameObject target = enemy
                target = closestEnemy.transform;
                //rotate turret towards target
                LookAtTarget();
                //attacking

                if (canAttack && (Time.time > nextFireTime))
                {
                    nextFireTime = Time.time + fireRate;

                    applyDamage();
                }
            }
        }
    }

    void applyDamage()
    {
        Debug.Log("Hit");
        hitcount++;
        Hittext.text = "Hit: " + hitcount.ToString();

        Instantiate(bullet, target.transform.position, Quaternion.identity);
    }

    void LookAtTarget()
    {
        //rotate towards target
        Vector3 tarDir = target.position - transform.position;

        Quaternion lookTarget = Quaternion.LookRotation(tarDir);
        Vector3 rotate = Quaternion.Lerp(turretBarrel.rotation, lookTarget, Time.deltaTime * BarrelrotateSpeed).eulerAngles;
    
        //apply rotation to barrel
        turretBarrel.rotation = Quaternion.Euler(rotate.x, rotate.y, 0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
