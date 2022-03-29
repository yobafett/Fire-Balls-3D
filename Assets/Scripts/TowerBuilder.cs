using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float TowerSize;
    [SerializeField] private Transform BuildPoint;
    [SerializeField] private Block Block;
    [SerializeField] private Color[] Colors;
    
    public List<Block> Build()
    {
        var blocks = new List<Block>();
        var previousColorId = 0;
        Transform currentPoint = BuildPoint;
        
        for (var i = 0; i < TowerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            var colorId = previousColorId;
            while (previousColorId == colorId) 
                colorId = Random.Range(0, Colors.Length);
            previousColorId = colorId;
            newBlock.SetColor(Colors[colorId]);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint) => 
        Instantiate(Block, GetBuildPoint(currentBuildPoint), Quaternion.identity, BuildPoint);

    private Vector3 GetBuildPoint(Transform currentSegment) 
        => new Vector3(BuildPoint.position.x,
            currentSegment.position.y + currentSegment.localScale.y / 2 + Block.transform.localScale.y / 2,
            BuildPoint.position.z);
}
