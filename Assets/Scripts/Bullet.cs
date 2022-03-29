using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float BounceForce;
    [SerializeField] private float BounceRadius;

    private Vector3 _moveDirection;
    private bool _move;

    private void Start()
    {
        _moveDirection = Vector3.forward;
        _move = true;
    }

    private void Update()
    {
        if(_move)
            transform.Translate(_moveDirection * (Speed * Time.deltaTime));
    }

    public void Bounce()
    {
        //_moveDirection = Vector3.back + Vector3.up;
        _move = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddExplosionForce(BounceForce, transform.position + new Vector3(0,-1,1),BounceRadius);
    }

}
