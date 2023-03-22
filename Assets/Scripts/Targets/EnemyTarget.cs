using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Target
{
    private void Start()
    {
        base.Start(); 
        pointValue = -10; 
        destroySound = GameObject.Find("Boom Sound").GetComponent<AudioSource>();
        destroyParticle1 = destroyParticlesHolder.DestroyParticlesHolder["red"];
        destroyParticle2 = destroyParticlesHolder.DestroyParticlesHolder["orange"];
    }
    
}
