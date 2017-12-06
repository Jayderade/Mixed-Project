﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Zombie {
    [Header("Tank")]
    public AudioSource scream;

    protected override void Awake()
    {
        base.Awake();
        scream.enabled = false;
    }

    protected override void Update()
    {
        
        base.Update();
    }

    protected override void Attack()
    {
        
        scream.enabled = true;
    }

    protected override void OnEndAttack()
    {
        base.OnEndAttack();
        scream.enabled = false;
    }

    
}
