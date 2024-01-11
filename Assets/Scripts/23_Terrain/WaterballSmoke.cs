using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterballSmoke : MonoBehaviour
{
    public delegate void CollisionDelegate();
    private CollisionDelegate collisionCallback = null;
    private List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();

    [SerializeField]
    private GameObject explosionPrefab = null;

    ParticleSystem ps = null;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void SetCollisionCallback(CollisionDelegate _callback)
    {
        collisionCallback = _callback;
        
    }
    private void OnParticleTrigger()
    {
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
        foreach(ParticleSystem.Particle particle in enterList)
        {
            Instantiate(explosionPrefab, particle.position, Quaternion.Euler(-270f, 0f, 0f));
            collisionCallback?.Invoke();
        }
    }
}
