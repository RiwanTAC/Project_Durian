using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    //1- Variable
    //1.1- Grid & Tile
    public GridManager grid;
    public Tile tile;
    public LevelDesign _levelDesign;
    //1.2- Painting Number
    public int numberOfTile;

    //1.3- End Turn
    public int teamTurn = 1; //1 = player's turn and 2 = ennemis' turn

    //1.4- Doing stuff
    public bool isInBuildingMode, isInPaintingMode, isInRepairMode;
    public BuildingMode buildMode;

    //1.4- Money
    private float templeGenMoney = 0.02f;
    public float buildingGenMoney, targetTime, resetTargetTime, moneyAmount;
    public Text moneyCounter;

    //2- Void Start
    private void Start()
    {
        //2.1- Reseting the Number of tile every game restart
        numberOfTile = 50;

    }

    //3- Void Start
    private void Update()
    {

        //3.1- generating Money
        if ((templeGenMoney + buildingGenMoney) * Time.deltaTime <= 1)
            moneyAmount ++;
        
        moneyCounter.text = moneyAmount.ToString();

    }

    //4- Changing Turns (to launch the path finding basically)
    public void EndTurn()
    {
        //4.1- Changing the ones in control
        if (teamTurn == 1)
        {

            teamTurn = 2;
            
        }

    }

    private void GenerateMoney(float _templeMoney, float _buildingMoney)
    {

        

    }

}
