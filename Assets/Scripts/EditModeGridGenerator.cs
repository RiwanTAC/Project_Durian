using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditModeGridGenerator : MonoBehaviour
{

    //1- Variables
    //1.1- References
    public GameMaster gm;

    //1.2- Game Objects
    public GameObject tilesHolder;
    public GameObject tile;

    //1.3- Grid Generator
    public int collumns, rows;

    //1.4- Arrays and Lists
    
    public GameObject[,] tilesGoArray; //is used to store the game object of each tile to access and change it

    //1.5- Level Design
    public LevelDesign levelDesign; //will be used to store the state of the tiles between: Deep Sea: 0, Shallow Sea: 1, and Base: 2
    public LevelDesign _levelDesign;

    //2- Void Awake
    private void Awake()
    {

        gm = FindObjectOfType<GameMaster>();

        
        tilesGoArray = new GameObject[collumns, rows];

        levelDesign.tilesStateArray = new int[collumns * rows];

        GenerateEditModeGrid();

    }

    //3- Void Update
    private void Update()
    {

        

    }

    //4- Generate the Grid
    private void GenerateEditModeGrid()
    {

        for (int x = 0; x < collumns; x++)
        {

            for (int z = 0; z < rows; z++)
            {

                // Instantiation of the tiles
                GameObject thisTile = Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
                thisTile.transform.parent = tilesHolder.transform;

                //Saving the coordinates of each tile in their own individual script
                EditModeTile ct = thisTile.GetComponent<EditModeTile>();
                ct.tileX = x;
                ct.tileZ = z;
                                              
                //Adding the tile to an array with it's scripted coordinates
                tilesGoArray[x, z] = thisTile;

                //Assigning the grid GO to the newly generated Tile
                ct.grid = this;

                //Assigning the GameMaster to the newly generated Cube/Tile

                ct.gm = this.gm;

                //Adding a value too each array's cell
                //levelDesign.tilesStateArray[x * collumns + z] = 5;

                //ADD THE LEVEL 1 MAP

            }

        }

        print(levelDesign.tilesStateArray.Length);

    }

}
