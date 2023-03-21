using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumFoodTarget : FoodTarget
{
    protected int PointValue = 8;
    
    private void Start()
    {
        destroySound = AudioPlayer.Instance.transform.Find("Eat Premium Sound").GetComponent<AudioSource>();
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        destroySound.Play();
    }
}
