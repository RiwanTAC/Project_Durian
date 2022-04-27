using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
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
    int[,] tilesIntArray;
    GameObject[,] tilesGoArray;
    public Node[,] graph;

    //2- Void Awake
    private void Awake()
    {
        //2.1- Setting up the Arrays
        tilesIntArray = new int[collumns, rows];
        tilesGoArray = new GameObject[collumns, rows];

        GeneratePathfindingGraph();

        GenerateGrid();

    }

    //3- Generating Pathfinding
    void GeneratePathfindingGraph()
    {

        //3.1- Initialization fo the array
        graph = new Node[collumns, rows];

        //3.2- Creating nodes for each elements of the array
        for (int x = 0; x < collumns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                //3.2.1- Creating a new node
                graph[x, z] = new Node();

                //3.2.2- Adding its coordinates
                graph[x, z].x = x;
                graph[x, z].z = z;

            }
        }

        //3.3- Calculating all the neighbours once we created all the nodes
        for (int x = 0; x < collumns; x++)
        {
            for(int z = 0; z < rows; z++)
            {
                //3.3.1- For West, South-West and North-West
                if (x > 0)
                {
                    //West
                    graph[x, z].neighbours.Add(graph[x - 1, z]);
                    //South-West
                    if (z > 0)
                        graph[x, z].neighbours.Add(graph[x - 1, z - 1]);
                    //North-West
                    if (z < rows - 1)
                        graph[x, z].neighbours.Add(graph[x - 1, z + 1]);
                }
                //3.3.2- For East, South-East and North-East
                if (x < collumns - 1)
                {
                    //East
                    graph[x, z].neighbours.Add(graph[x + 1, z]);
                    //South-East
                    if (z > 0)
                        graph[x, z].neighbours.Add(graph[x + 1, z - 1]);
                    //North-East
                    if (z < rows - 1)
                        graph[x, z].neighbours.Add(graph[x + 1, z + 1]);
                }
                //3.3.3- South
                if (z > 0)
                    graph[x, z].neighbours.Add(graph[x, z - 1]);
                //3.3.4- North
                if (z < rows - 1)
                    graph[x, z].neighbours.Add(graph[x, z + 1]);

            }
        }

    }

    //4- Generate grid
    void GenerateGrid()
    {

        for (int x = 0; x < collumns; x++)
        {

            for (int z = 0; z < rows; z++)
            {

                // Instantiation of the tiles
                GameObject thisTile = Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
                thisTile.transform.parent = tilesHolder.transform;

                //Saving the coordinates of each tile in their own individual script
                Tile ct = thisTile.GetComponent<Tile>();
                ct.tileX = x;
                ct.tileZ = z;

                //Adding the tile to an array with it's scripted coordinates
                tilesGoArray[x, z] = thisTile;

                //Assigning the grid GO to the newly generated Tile
                ct.grid = this;

                //Assigning the GameMaster to the newly generated Cube/Tile

                ct.gm = this.gm;

            }

        }

    }

    //5- A Vector 3 to calculate coordinate in case the grid moves or the scale changes
    public Vector3 TileCoordToWorldCoord(int x, float y, int z)
    {
        return new Vector3(x, y, z); //rn the tiles have the same coordinates in arrays than in the world
    }

    //6- Cost to Enter a tile
    public float CostToEnterTile(int sourceX, int sourceZ, int targetX, int targetZ)
    {

        GameObject _thisTile = tilesGoArray[targetX, targetZ];

        if (_thisTile.GetComponent<Tile>().IsClear() == false) //permet de vérifier si la case est libre ou pas, si elle ne l'est pas on augmente son coût de passage
        {

            return _thisTile.GetComponent<Tile>().moveCost = Mathf.Infinity; //j'ai pris large dans le doute

        }
        else
        {
            if (sourceX != targetX && sourceZ != targetZ)//pour faire en sorte que l'unité préfère les ligne droite au diagonale mais ça ne change rien à par un effet esthétique
            {
                return _thisTile.GetComponent<Tile>().moveCost = 1.001f;
            }
            else
                return _thisTile.GetComponent<Tile>().moveCost = 1;
        }

    }

}
