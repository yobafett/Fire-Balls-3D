using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    public event UnityAction<int> SizeUpdate;
    
    private TowerBuilder towerBuilder;
    private List<Block> blocks;

    private void Start()
    {
        towerBuilder = GetComponent<TowerBuilder>();
        blocks = towerBuilder.Build();

        foreach (Block block in blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        
        SizeUpdate?.Invoke(blocks.Count);
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;
        
        blocks.Remove(hitedBlock);

        foreach (Block block in blocks)
        {
            Transform blockTransform = block.transform;
            Vector3 blockPosition = blockTransform.position;
            
            blockTransform.position = new Vector3(blockPosition.x,
                blockPosition.y - blockTransform.localScale.y,
                blockPosition.z);
        }
        
        SizeUpdate?.Invoke(blocks.Count);
    }
}
