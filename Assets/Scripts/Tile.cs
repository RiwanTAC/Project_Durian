using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //1- Variable
    //1.1- References
    public GridManager grid;
    public GameMaster gm;

    //1.1- Grid Generator
    public int tileX, tileZ;
    
    //1.2- Statements
    public bool isWalkable, isShallowSea, isDeepSea, isBeach, isPlain, isBase;

    //1.3- Painting
    public Material seaMaterial, seaHoverMaterial, shallowSeaMaterial, shallowSeaHoverMaterial, beachMaterial, beachHoverMaterial, plainMaterial, plainHoverMaterial;
    public float elevation;

    //1.4- Tile Checking
    private GameObject tileToCheck;

    public List<Vector2> neighbours = new List<Vector2>
    {
        new Vector2(0,1),
        new Vector2(0,-1),
        new Vector2(1,0),
        new Vector2(-1,0),
    };

    public List<Vector2> surrounding = new List<Vector2>
    {
        new Vector2(0,0),
        new Vector2(0,1),
        new Vector2(0,-1),
        new Vector2(1,0),
        new Vector2(-1,0),

        new Vector2(1, 1),
        new Vector2(1, -1),
        new Vector2(-1, 1),
        new Vector2(-1, -1),
    };

    #region OLD Path Finding (References)
    //1.5- Pathfinding
    //public float moveCost = 1;
    #endregion

    //2- Setting everything up
    private void Start()
    {
        
        this.GetComponent<MeshRenderer>().material = seaMaterial;

        isWalkable = true;
        isDeepSea = true;

    }

    //3- Checking any function or event
    //3.1- On Mouse Entering
    private void OnMouseEnter()
    {

        HoveringEnter();

    }
    //3.2- On Mouse Over
    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.LogWarning("tile painted : " + tileX + "," + tileZ);
            paintingTiles();
            checkingTiles();


        }
        if (Input.GetMouseButtonDown(1))
        {

            deletingTiles();
            checkingTiles();

        }

    }

    //3.3- On mouse exit 
    private void OnMouseExit()
    {

        HoveringExit();

    }


    //4- Hovering effect on mouse enter
    //4.1- Hovering on enter
    private void HoveringEnter()
    {
        //Checking the tile state
        if (isDeepSea == true)
        {
            this.GetComponent<MeshRenderer>().material = seaHoverMaterial;
        }
        else if (isBeach == true)
        {
            this.GetComponent<MeshRenderer>().material = beachHoverMaterial;
        }
        else if (isPlain == true)
        {
            this.GetComponent<MeshRenderer>().material = plainHoverMaterial;
        }
        else if(isShallowSea == true)
        {
            this.GetComponent<MeshRenderer>().material = shallowSeaHoverMaterial;
        }
        else
        {
            Debug.Log("we have a problem captain");
        }
    }
    //4.2- Hovering exit
    private void HoveringExit()
    {

        //Checking the tile state
        if (isDeepSea == true)
        {
            this.GetComponent<MeshRenderer>().material = seaMaterial;
        }
        else if (isBeach == true)
        {
            this.GetComponent<MeshRenderer>().material = beachMaterial;
        }
        else if (isPlain == true)
        {
            this.GetComponent<MeshRenderer>().material = plainMaterial;
        }
        else if(isShallowSea == true)
        {
            this.GetComponent<MeshRenderer>().material = shallowSeaMaterial;
        }
        else
        {
            Debug.Log("we have a problem captain");
        }

    }

    //5- Painting the Map
    //5.1- Painting the map
    private void paintingTiles()
    {
        if(gm.numberOfTile > 0)
        if (isDeepSea == true)
        {
            isBeach = true;
            isDeepSea = false;

            this.GetComponent<MeshRenderer>().material = beachMaterial;
            this.transform.position = new Vector3(tileX, elevation, tileZ);

            gm.numberOfTile = gm.numberOfTile - 1;

        }

    }

    //5.2- Deleting the map
    private void deletingTiles()
    {

        if (isBeach == true || isPlain == true && isBase == false)
        {

            isDeepSea = true;
            isBeach = false;
            isPlain = false;

            this.GetComponent<MeshRenderer>().material = seaMaterial;
            this.transform.position = new Vector3(tileX, -elevation, tileZ);

            gm.numberOfTile = gm.numberOfTile + 1;

        }

    }

    //6- Checking adjacent tiles
    //6.1- Checking the first round of tiles
    private void checkingTiles()
    {

        //Looping 8 times to make sure we get everything
        for (int i = 1; i < 8; i++)
        {

            //Here to ask the function to check all surroundings, based on the list surrounding, of the new/ancient tile to make sure everything is in place
            foreach (Vector2 n in surrounding)
            {

                //Checking if this tiels exist in teh gameworld by checking with the size of the grid
                if (tileX + Mathf.RoundToInt(n.x) * i > 0 && tileX + Mathf.RoundToInt(n.x) * i < grid.collumns && tileZ + Mathf.RoundToInt(n.y) * i < grid.rows && tileZ + Mathf.RoundToInt(n.y) * i > 0)
                {

                    GameObject tileToCheck = grid.tilesGoArray[tileX + Mathf.RoundToInt(n.x) * i, tileZ + Mathf.RoundToInt(n.y) * i]; //because n is a vector and vectors values are float, I needed to make them convert to int, and i is to check surrounding tiles

                    print("tileToCheck : " + tileToCheck.GetComponent<Tile>().tileX + "," + tileToCheck.GetComponent<Tile>().tileZ);
                    print("tileToCheck is beach: " + tileToCheck.GetComponent<Tile>().isBeach);

                    //If the tile is a beach it will chek the surroudning tiles to be sure they are as well
                    if (tileToCheck.GetComponent<Tile>().isBeach == true)
                    {
                        int _nbAdjSide = 0; //here to check the number of adjacent side the tile has to other beach tiles

                        //Here to ask the function to check all neighbours, based on the list neighbours, of each tile to make sure everything is in place
                        foreach (Vector2 m in neighbours)
                        {

                            GameObject _tileToCheck = grid.tilesGoArray[tileToCheck.GetComponent<Tile>().tileX + Mathf.RoundToInt(m.x), tileToCheck.GetComponent<Tile>().tileZ + Mathf.RoundToInt(m.y)]; //changed the reference tile to the tile we are currently checking

                            print("_tileToCheck : " + _tileToCheck.GetComponent<Tile>().tileX + "," + _tileToCheck.GetComponent<Tile>().tileZ);
                            print("_tileToCheck is beach: " + _tileToCheck.GetComponent<Tile>().isBeach);

                            //If the tile is a beach it will chek the neighbouring tiles to be sure they are as well
                            if (_tileToCheck.GetComponent<Tile>().isBeach == true || _tileToCheck.GetComponent<Tile>().isPlain == true)
                            {

                                _nbAdjSide++;

                                if (_nbAdjSide == 4)
                                {

                                    tileToCheck.GetComponent<Tile>().isBeach = false;
                                    tileToCheck.GetComponent<Tile>().isPlain = true;
                                    tileToCheck.GetComponent<MeshRenderer>().material = plainMaterial;

                                }

                            }

                        }

                    }

                }

            }

        }
        

        #region OLD Checking Tiles
        /*// Checking the tile on left and right
        for (int i = -1; i < 2; i = i + 2)
        {

            GameObject tileToCheck = grid.tilesGoArray[tileX + i, tileZ]; //getting the tiles to chek from the grid manager's array containing all tile's GO


            //Checking if the tile is in fact a beach tile
            if (tileToCheck.GetComponent<Tile>().isBeach == true) 
            {

                _nbAdjSide++; //we add one side that is correct

                //if all side are in fact adjacent to a beach tile we apply the change
                if (_nbAdjSide == 2) 
                {

                    //changing the tile we just placed
                    isBeach = false;
                    isPlain = true;
                    this.GetComponent<MeshRenderer>().material = plainMaterial;

                    //changing the tiles on the right and the left
                    for (int _i = -1; _i < 2; _i = _i + 2) 
                    {
                        GameObject _tileToCheck = grid.tilesGoArray[tileX + _i, tileZ];

                        
                        _tileToCheck.GetComponent<Tile>().isBeach = false;
                        _tileToCheck.GetComponent<Tile>().isPlain = true;

                        _tileToCheck.GetComponent<MeshRenderer>().material = plainMaterial;

                    }                    

                }                

            }

        }*/
        #endregion

    }
    //6.2- Checking the second round of tile
    private void checkingTiles2nd()
    {

        int _nbAdjSide = 0; //here to check the number of adjacent side the tile has to other beach tiles

        // Checking the tile on left and right
        for (int i = -2; i < 1; i = i + 2)
        {

            GameObject tileToCheck = grid.tilesGoArray[tileX + i, tileZ]; //getting the tiles to chek from the grid manager's array containing all tile's GO

            //Checking if the tile is in fact a beach tile
            if (tileToCheck.GetComponent<Tile>().isBeach == true)
            {

                _nbAdjSide++; //we add one side that is correct

                //if all side are in fact adjacent to a beach tile we apply the change
                if (_nbAdjSide == 2)
                {

                    /*//changing the tile we just placed
                    isBeach = false;
                    isPlain = true;
                    this.GetComponent<MeshRenderer>().material = plainMaterial;*/

                    //changing the tiles on the right and the left
                    for (int _i = -2; _i < 1; _i = _i + 1)
                    {
                        GameObject _tileToCheck = grid.tilesGoArray[tileX + _i, tileZ];


                        _tileToCheck.GetComponent<Tile>().isBeach = false;
                        _tileToCheck.GetComponent<Tile>().isPlain = true;

                        _tileToCheck.GetComponent<MeshRenderer>().material = plainMaterial;

                    }

                }

            }

        }

    }

    #region OLD Path Finding (CHeking of tile)
    /*//6- Pathfinding Related
    //6.1- Checking if the tile is clear
    public bool IsClear()
    {

        if (isBeach == true || isSea == true)
        {
            return true;
        }else if (isPlain == true)
        {
            return false;
        }
        else
        {
            return false;
        }

    }*/
    #endregion

}
