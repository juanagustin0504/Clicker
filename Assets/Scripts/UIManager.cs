using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public DataController dataController;

    void Update() {
        goldDisplayer.text = "Gold" + dataController.GetGold();
        goldPerClickDisplayer.text = "Gold" + dataController.GetGoldPerClick();
    }
}
