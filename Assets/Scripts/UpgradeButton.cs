using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer;
    public string upgradeName;

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    public int currentCost; // item cost
    public int startCurrentCost = 1;

    public int level = 1; // level

    public float upgradePow = 1.1f; // upgrade
    public float costPow = 2.17f; // upgrade

    void Start() {
        DataController.GetInstance().LoadUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade() {
        if (DataController.GetInstance().GetGold() >= currentCost) {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this);
        }
    }

    public void UpdateUpgrade() {
        goldByUpgrade = startGoldByUpgrade * (int) Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int) Mathf.Pow(costPow, level);
    }

    public void UpdateUI() {
        upgradeDisplayer.text = upgradeName + "\nCost" + currentCost + "\nLevel" + level + "\nNext New GoldPerClick" + goldByUpgrade;
    }
}
