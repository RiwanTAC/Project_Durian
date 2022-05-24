using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditModeTile : MonoBehaviour
{

    //1- Variable
    //1.1- References
    public EditModeGridGenerator grid;
    public GameMaster gm;

    //1.1- Grid Generator
    public int tileX, tileZ;

    //1.2- Statements
    public bool isWalkable, isShallowSea, isDeepSea, isPlain, isBase;

    //1.3- Painting
    public Material seaMaterial, shallowSeaMaterial, plainMaterial, pathMaterial;
    public float elevation;

    //2- Awake
    private void Awake()
    {
        //by default it will be deepsea and not walkable
        this.GetComponent<MeshRenderer>().material = seaMaterial;

        isWalkable = false;
        isDeepSea = true;

    }

    //3- Void Update
    private void Update()
    {
        //Will change the information in the array when you change the bool in the properties of the tile

        if(isShallowSea == true)
        {

            isDeepSea = false;

            this.GetComponent<MeshRenderer>().material = shallowSeaMaterial;

            grid.levelDesign.tilesStateArray[tileX * grid.collumns + tileZ] = 1;

        }

        if (isBase == true)
        {

            isDeepSea = false;

            this.GetComponent<MeshRenderer>().material = plainMaterial;

            grid.levelDesign.tilesStateArray[tileX * grid.collumns + tileZ] = 2;

        }

        if (isDeepSea == true)
        {

            isBase = false;
            isShallowSea = false;

            this.GetComponent<MeshRenderer>().material = seaMaterial;

            grid.levelDesign.tilesStateArray[tileX * grid.collumns + tileZ] = 5;


        }

        if (isWalkable == true)
        {

            isDeepSea = false;

            this.GetComponent<MeshRenderer>().material = pathMaterial;

            grid.levelDesign.tilesStateArray[tileX * grid.collumns + tileZ] = 8;

        }

    }

}
