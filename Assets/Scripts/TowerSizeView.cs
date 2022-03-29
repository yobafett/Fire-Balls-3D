using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TowerSizeText;
    [SerializeField] private Tower Tower;

    private void OnEnable()
    {
        Tower.SizeUpdate += UpdateTowerSizeText;
    }

    private void OnDisable()
    {
        Tower.SizeUpdate -= UpdateTowerSizeText;
    }

    private void UpdateTowerSizeText(int value) => 
        TowerSizeText.text = value.ToString();
}
