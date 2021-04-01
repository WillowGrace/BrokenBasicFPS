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
    int shootableMask;
    LineRenderer gunLine;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shooting();
        }

    }




    void Shooting()
    {
        timer = 0f;

        //gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            Health Health = shootHit.collider.GetComponent<Health>();
            if (Health != null)
            {
                Health.TakeDamage(damagePerShot);
            }
           // gunLine.SetPosition(1,shootHit.point);
        }
        else
        {
           // gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
