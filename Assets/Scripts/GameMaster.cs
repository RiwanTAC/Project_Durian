using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //1- Variable
    //1.1- References
    public GridManager grid;
    public Tile tile;

    //1.2- Painting Number
    public int numberOfTile;

    //1.3- En Turn
    public int teamTurn = 1; //1 = player's turn and 2 = ennemis' turn

    //2- Void Start
    private void Start()
    {
        //2.1- Reseting the Number of tile every game restart
        numberOfTile = 50;
    }

    //3- Void Start
    private void Update()
    {
        
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
}
