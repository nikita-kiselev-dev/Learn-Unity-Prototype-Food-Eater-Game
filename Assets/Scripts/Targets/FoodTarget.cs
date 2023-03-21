using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodTarget : Target
{

    private void Start()
    {
        base.Start();
        PointValue = 5;
        destroySound = GameObject.Find("Eat Sound").GetComponent<AudioSource>();
        destroyParticle1 = destroyParticlesHolder.destroyParticlesHolder["blue"];
        destroyParticle2 = destroyParticlesHolder.destroyParticlesHolder["pink"];
    }
}
