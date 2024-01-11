using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public delegate void CollisionDelegate();
    private CollisionDelegate collisionCallback = null;

    [SerializeField]
    private GameObject explosionPrefab = null;

    private ParticleSystem ps = null;

    // Particle�̶�� ����ü�� List�� ����
    private List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();

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
        // particle trigger�߻� ��, �� �Լ��� ȣ��ȴ�.
        // particle�� Trigger�� particle System�� �ƴ϶� ���� �ϳ��ϳ��� �浹�� �����Ѵ�.
        // �浹�� particle���� ����Ʈ�� enterList�� �޾��ش�.
        ps.GetTriggerParticles(
            ParticleSystemTriggerEventType.Enter, enterList);

        foreach (ParticleSystem.Particle particle in enterList)
        {
            Instantiate(explosionPrefab, particle.position, Quaternion.Euler(-90f, 0f, 0f));
            collisionCallback?.Invoke();
        }
    }

}
