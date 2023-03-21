using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumFoodTarget : FoodTarget
{

    private void Start()
    {
        base.Start();
        PointValue = 8;
        destroySound = GameObject.Find("Eat Premium Sound").GetComponent<AudioSource>();
        destroyParticle1 = destroyParticlesHolder.destroyParticlesHolder["blue"];
        destroyParticle2 = destroyParticlesHolder.destroyParticlesHolder["pink"];
    }

}
