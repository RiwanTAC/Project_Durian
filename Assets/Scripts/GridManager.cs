using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //1- Variables
    //1.1- References


    //1.2- Game Objects
    public GameObject tilesHolder;
    public GameObject tile;

    //1.3- Grid Generator
    public int collumns, rows;

    //1.4- Arrays and Lists
    int[,] tilesIntArray;
    GameObject[,] tilesGoArray;

    //2- Void Awake
    private void Awake()
    {
        //2.1- Setting up the Arrays
        tilesIntArray = new int[collumns, rows];
        tilesGoArray = new GameObject[collumns, rows];

        GenerateGrid();

    }


    //X- Generate grid
    void GenerateGrid()
    {

        for (int x = 0; x < collumns; x++)
        {

            for (int z = 0; z < rows; z++)
            {

                // Instantiation of the tiles
                GameObject thisTile = Instantiate(tile, new Vector3(x * 10, 0, z * 10), Quaternion.identity) as GameObject; //Tiles are bigger than coordinate, that's why there a *10
                thisTile.transform.parent = tilesHolder.transform;

                //Saving the coordinates of each tile in their own individual script
                Tile ct = thisTile.GetComponent<Tile>();
                ct.tileX = x;
                ct.tileZ = z;


                tilesGoArray[x, z] = thisTile;

                ct.grid = this;
            }

        }

    }

}
