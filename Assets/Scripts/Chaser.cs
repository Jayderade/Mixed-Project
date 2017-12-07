using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Zombie {

    [Header("Chaser")]
    public float screamRange = 5;
    public AudioSource scream;

    protected override void Awake()
    {
        health = 150;
        base.Awake();
        scream.enabled = false;
        
    }

    protected override void Update()
    {
        health = health - decay * Time.deltaTime;
        base.Update();
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < screamRange)
        {
            scream.enabled = true;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void Bite()
    {
        base.Bite();
    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected override void OnEndAttack()
    {
        
        scream.enabled = false;
        base.OnEndAttack();
        
    }

   
}
