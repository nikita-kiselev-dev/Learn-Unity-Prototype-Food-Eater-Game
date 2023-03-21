using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumFoodTarget : FoodTarget
{

    private void Start()
    {
        PointValue = 8;
        destroySound = audioManager.transform.Find("Eat Premium Sound").GetComponent<AudioSource>();
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        destroySound.Play();
    }
}
