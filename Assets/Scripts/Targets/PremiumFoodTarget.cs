using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumFoodTarget : FoodTarget
{

    private new void Start()
    {
        base.Start();
        pointValue = 8;
        destroySound = GameObject.Find("Eat Premium Sound").GetComponent<AudioSource>();
        destroyParticle1 = destroyParticlesHolder.DestroyParticlesHolder["blue"];
        destroyParticle2 = destroyParticlesHolder.DestroyParticlesHolder["pink"];
    }

}
