using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem DestroyEffect;
    
    public event UnityAction<Block> BulletHit;

    private MeshRenderer meshRenderer;

    private void Awake() => 
        meshRenderer = GetComponent<MeshRenderer>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            Break((() => Destroy(gameObject)));
        }
            
    }

    public void SetColor(Color color) => 
        meshRenderer.material.color = color;

    private void Break(Action callback = null)
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer particleSystemRenderer = 
            Instantiate(DestroyEffect, transform.position, DestroyEffect.transform.rotation)
            .GetComponent<ParticleSystemRenderer>();
        particleSystemRenderer.material.color = meshRenderer.material.color;
        callback?.Invoke();
    }
}
