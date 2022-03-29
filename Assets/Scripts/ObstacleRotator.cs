using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float AnimationDuration;
    
    private void Start()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), AnimationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
