using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Target
{
    private void Start()
    {
       PointValue = -10;
       destroySound = audioManager.transform.Find("Boom Sound").GetComponent<AudioSource>();
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        destroySound.Play();
    }
}
