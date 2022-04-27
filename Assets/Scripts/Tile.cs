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
    public bool isWalkable, isSea, isBeach, isPlain;

    //1.3- Painting
    public Material seaMaterial, seaHoverMaterial, beachMaterial, beachHoverMaterial, plainMaterial, plainHoverMaterial;
    public float elevation;

    //1.4- Tile Scoring
    //int tileScore;

    //1.5- Pathfinding
    public float moveCost = 1;

    //2- Setting everything up
    private void Start()
    {

        this.GetComponent<MeshRenderer>().material = seaMaterial;

        isWalkable = true;
        isSea = true;

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

            paintingTiles();
        }
        if (Input.GetMouseButtonDown(1))
        {
            deletingTiles();
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
        if (isSea == true)
        {
            this.GetComponent<MeshRenderer>().material = seaHoverMaterial;
        }
        else if (isBeach == true)
        {
            this.GetComponent<MeshRenderer>().material = beachHoverMaterial;
        }
        else if (isPlain)
        {
            this.GetComponent<MeshRenderer>().material = plainHoverMaterial;
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
        if (isSea == true)
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
        if (isSea == true)
        {
            isBeach = true;
            isSea = false;

            this.GetComponent<MeshRenderer>().material = beachMaterial;
            this.transform.position = new Vector3(tileX, elevation, tileZ);

            gm.numberOfTile = gm.numberOfTile - 1;

        }

    }

    //5.2- Deleting the map
    private void deletingTiles()
    {

        if (isBeach == true || isPlain == true)
        {

            isSea = true;
            isBeach = false;
            isPlain = false;

            this.GetComponent<MeshRenderer>().material = seaMaterial;
            this.transform.position = new Vector3(tileX, -elevation, tileZ);

            gm.numberOfTile = gm.numberOfTile + 1;

        }

    }

    //6- Pathfinding Related
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

    }

}
