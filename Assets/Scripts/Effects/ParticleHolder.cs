using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    [SerializeField] private string[] destroyParticlesName;
    [SerializeField] private ParticleSystem[] destroyParticles;
    public Dictionary<string, ParticleSystem> DestroyParticlesHolder { get; private set; } = new Dictionary<string, ParticleSystem>();

    void Awake()
    {
        for (int i = 0; i < destroyParticles.Length; i++)
        {
            DestroyParticlesHolder.Add(destroyParticlesName[i], destroyParticles[i]);
        }

        
    }
}
