using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Target
{
    private void Start()
    {
        base.Start(); 
        PointValue = -10; 
        destroySound = GameObject.Find("Boom Sound").GetComponent<AudioSource>();
        destroyParticle1 = destroyParticlesHolder.destroyParticlesHolder["red"];
        destroyParticle2 = destroyParticlesHolder.destroyParticlesHolder["orange"];
    }
    
}
