using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    protected Rigidbody targetRB;
    private float minForce = 12.0f;
    private float maxForce = 16.0f;
    private float maxTorque = 10.0f;
    private float xStartPosition = 4.0f;
    private float yStartPosition = 2.0f;

    [SerializeField] protected GameManager gameManager;
    
    [SerializeField] protected int PointValue;

    [SerializeField] protected ParticleHolder destroyParticlesHolder;
    [SerializeField] protected ParticleSystem destroyParticle1;
    [SerializeField] protected ParticleSystem destroyParticle2;

    protected GameObject audioManager;

    [SerializeField] protected AudioSource destroySound;
    
    protected void Start()
    {
        targetRB = gameObject.GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        gameObject.transform.position = RandomStartPosition();
        destroyParticlesHolder = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public virtual void OnMouseDown()
    {
        Debug.Log(gameManager.isGameActive);
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            InstantiateExplosion(destroyParticle1);
            InstantiateExplosion(destroyParticle2);
            gameManager.UpdateScore(PointValue);
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
