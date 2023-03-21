using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Target
{
    protected int PointValue = -10;
    private void Start()
    {
        destroySound = AudioPlayer.Instance.transform.Find("Boom Sound").GetComponent<AudioSource>();
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        destroySound.Play();
    }
}
