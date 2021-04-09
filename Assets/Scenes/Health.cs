using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int maxHealth = 10;
    int itemHealth;
    int damagePerShot;
    // Start is called before the first frame update
    void Start()
    {
        itemHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damagePerShot)
    {
        itemHealth -= damagePerShot;
    }
}
