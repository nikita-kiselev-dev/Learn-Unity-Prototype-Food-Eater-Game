using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    protected Rigidbody TargetRb;
    private const float _minForce = 12.0f;
    private const float _maxForce = 16.0f;
    private const float _maxTorque = 10.0f;
    private const float _xStartPosition = 4.0f;
    private const float _yStartPosition = 2.0f;

    [SerializeField] protected GameManager gameManager;
    
    [SerializeField] protected int pointValue;

    private protected ParticleHolder destroyParticlesHolder;
    private protected ParticleSystem destroyParticle1;
    private protected ParticleSystem destroyParticle2;
    
    [SerializeField] protected AudioSource destroySound;
    
    protected void Start()
    {
        TargetRb = gameObject.GetComponent<Rigidbody>();
        destroyParticlesHolder = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnTarget();
    }

    public virtual void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            InstantiateExplosion(destroyParticle1);
            InstantiateExplosion(destroyParticle2);
            gameManager.UpdateScore(pointValue);
            switch (gameObject.tag)
            {
                case ("Good"):
                    destroySound.Play();
                    break;
                case ("Premium"):
                    destroySound.Play();
                    break;
                case ("Bad"):
                    destroySound.Play();
                    break;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameManager.isGameActive == true &&!gameObject.CompareTag("Bad") && other.gameObject.CompareTag("Sensor"))
        {
            gameManager.LooseLive();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minForce, _maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomStartPosition()
    {
        return new Vector3(Random.Range(-_xStartPosition, _xStartPosition), -_yStartPosition);
    }

    private void InstantiateExplosion(ParticleSystem explosionParticle)
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }

    private void SpawnTarget()
    {
        TargetRb.AddForce(RandomForce(), ForceMode.Impulse);
        TargetRb.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        gameObject.transform.position = RandomStartPosition();
    }
}
