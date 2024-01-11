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

    // Particle이라는 구조체를 List로 만듬
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
        // particle trigger발생 시, 이 함수가 호출된다.
        // particle의 Trigger는 particle System이 아니라 입자 하나하나의 충돌을 감지한다.
        // 충돌된 particle입자 리스트를 enterList에 받아준다.
        ps.GetTriggerParticles(
            ParticleSystemTriggerEventType.Enter, enterList);

        foreach (ParticleSystem.Particle particle in enterList)
        {
            Instantiate(explosionPrefab, particle.position, Quaternion.Euler(-90f, 0f, 0f));
            collisionCallback?.Invoke();
        }
    }

}
