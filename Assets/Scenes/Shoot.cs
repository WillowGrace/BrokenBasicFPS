using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int damagePerShot = 5;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;


    void Awake()
    {
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shooting();
            Debug.Log("Pew");
        }

    }




    void Shooting()
    {
        timer = 0f;


        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            Health Health = shootHit.collider.GetComponent<Health>();
            if (Health != null)
            {
                Health.TakeDamage(damagePerShot);
            }
        }
     
    }

}
