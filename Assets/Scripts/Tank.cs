using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private Bullet BulletPrefab;
    [SerializeField] private float ShootingDelay;
    [SerializeField] private float RecoilDistance;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (!Input.GetMouseButton(0)) 
            return;

        if (_timeAfterShoot > ShootingDelay)
        {
            Shoot();
            transform.DOMoveZ(transform.position.z - RecoilDistance, ShootingDelay / 2)
                .SetLoops(2, LoopType.Yoyo);
            transform.DORotate(new Vector3(-10f, 0f, 0f), ShootingDelay / 4)
                .SetLoops(2,LoopType.Yoyo);
            _timeAfterShoot = 0;
        }
    }

    private void Shoot() => 
        Instantiate(BulletPrefab, ShootPoint.position, Quaternion.identity);
}
