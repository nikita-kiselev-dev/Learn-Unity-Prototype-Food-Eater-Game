using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRB;
    private float minForce = 12.0f;
    private float maxForce = 16.0f;
    private float maxTorque = 10.0f;
    private float xStartPosition = 4.0f;
    private float yStartPosition = 2.0f;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle1;
    public ParticleSystem explosionParticle2;

    private AudioSource eatSound;
    private AudioSource eatPremiumSound;
    private AudioSource boomSound;

    void Start()
    {
        targetRB = gameObject.GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        gameObject.transform.position = RandomStartPosition();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        eatSound = GameObject.Find("Eat Sound").GetComponent<AudioSource>();
        eatPremiumSound = GameObject.Find("Eat Premium Sound").GetComponent<AudioSource>();
        boomSound = GameObject.Find("Boom Sound").GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            InstantiateExplosion(explosionParticle1);
            InstantiateExplosion(explosionParticle2);
            gameManager.UpdateScore(pointValue);
            switch (gameObject.tag)
            {
                case ("Good"):
                    eatSound.Play();
                    break;
                case ("Premium"):
                    eatPremiumSound.Play();
                    break;
                case ("Bad"):
                    boomSound.Play();
                    break;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && other.gameObject.CompareTag("Sensor"))
        {
            gameManager.LooseLive();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomStartPosition()
    {
        return new Vector3(Random.Range(-xStartPosition, xStartPosition), -yStartPosition);
    }

    private void InstantiateExplosion(ParticleSystem explosionParticle)
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }
}
