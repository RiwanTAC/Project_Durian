using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMode : MonoBehaviour
{

    //1- Variable
    public GameObject tower, barrack, moneyGen;
    public GameMaster gm;
    public bool isBuildingTower = false, isBuildingBarrack = false, isBuildingMoney = false;
    public float towerElevation = 1.5f, barrackElevation = 1f, moneyElevation = 1.3f;
    public float towerCost, barrackCost, incomeCost;
    public Text textTowerCost, textBarrackCost, textIncomeCost;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();

        textTowerCost.text = towerCost.ToString();
        textBarrackCost.text = barrackCost.ToString();
        textIncomeCost.text = incomeCost.ToString();

    }

    private void Update()
    {



    }

    public void BuildTower()
    {
        if(gm.moneyAmount >= towerCost)
            isBuildingTower = true;

        isBuildingMoney = false;
        isBuildingBarrack = false;

    }

    public void BuildBarrack()
    {

        if (gm.moneyAmount >= barrackCost)
            isBuildingBarrack = true;

        isBuildingMoney = false;
        isBuildingTower = false;

    }

    public void BuildMoneyGen()
    {
        if (gm.moneyAmount >= incomeCost)
            isBuildingMoney = true;

        isBuildingTower = false;
        isBuildingBarrack = false;

    }
}
