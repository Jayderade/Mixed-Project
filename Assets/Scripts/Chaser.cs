using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Zombie {

    [Header("Chaser")]
    public float screamRange = 5;
    public AudioSource scream;

    protected override void Awake()
    {
        base.Awake();
        scream.enabled = false;
        
    }

    protected override void Update()
    {
        
        base.Update();
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < screamRange)
        {
            scream.enabled = true;
        }
        
    }

    protected override void Attack()
    {        
        
    }

    protected override void OnEndAttack()
    {
        
        scream.enabled = false;
        base.OnEndAttack();
        
    }

   
}
