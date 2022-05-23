using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMode : MonoBehaviour
{

    //1- Variable
    //1.1- References
    public GameObject tower, barrack, moneyGen;
    public GameMaster gm;
    //1.2- Cost
    public float towerCost, barrackCost, incomeCost;
    public Text textTowerCost, textBarrackCost, textIncomeCost;
    //1.3- Graphic
    public float towerElevation = 1.5f, barrackElevation = 1f, moneyElevation = 1.3f;

    public bool isBuildingTower = false, isBuildingBarrack = false, isBuildingMoney = false;

    //2- Start
    private void Start()
    {
        //Finding the game master
        gm = FindObjectOfType<GameMaster>();

        //Updating the text displayed from float to String
        textTowerCost.text = towerCost.ToString();
        textBarrackCost.text = barrackCost.ToString();
        textIncomeCost.text = incomeCost.ToString();

    }

    //3- Void Update
    private void Update()
    {

    }

    //4- Building the different buildings
    //4.1- Building the Tower
    public void BuildTower()
    {
        if(gm.moneyAmount >= towerCost)
            isBuildingTower = true;

        isBuildingMoney = false;
        isBuildingBarrack = false;

    }
    //4.2- Building the Barrack
    public void BuildBarrack()
    {

        if (gm.moneyAmount >= barrackCost)
            isBuildingBarrack = true;

        isBuildingMoney = false;
        isBuildingTower = false;

    }
    //4.3- Building the income generator
    public void BuildMoneyGen()
    {
        if (gm.moneyAmount >= incomeCost)
            isBuildingMoney = true;

        isBuildingTower = false;
        isBuildingBarrack = false;

    }
}
