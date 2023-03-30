using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodTarget : Target
{
    private new void Start()
    {
        base.Start();
        pointValue = 5;
        destroySound = GameObject.Find("Eat Sound").GetComponent<AudioSource>();
        destroyParticle1 = destroyParticlesHolder.DestroyParticlesHolder["blue"];
        destroyParticle2 = destroyParticlesHolder.DestroyParticlesHolder["pink"];
    }
}
