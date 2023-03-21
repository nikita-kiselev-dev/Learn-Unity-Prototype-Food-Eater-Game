using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodTarget : Target
{
    private ParticleSystem particleEffect1;

    private int PointValue = 5;

    private void Start()
    {
        destroySound = AudioPlayer.Instance.transform.Find("Eat Sound").GetComponent<AudioSource>();
        //particleEffect1 = base.particleEffectSystem["Purple"];
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        destroySound.Play();
    }
}
