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
    public Material seaMaterial, shallowSeaMaterial, plainMaterial;
    public float elevation;

    private void Awake()
    {

        this.GetComponent<MeshRenderer>().material = seaMaterial;

        isWalkable = false;
        isDeepSea = true;

    }

    private void Update()
    {
        
        if(isShallowSea == true)
        {

            isDeepSea = false;

            this.GetComponent<MeshRenderer>().material = shallowSeaMaterial;

            grid.levelDesign.tilesStateArray[tileX, tileZ] = 1;
            
        }

        if (isBase == true)
        {

            isDeepSea = false;

            this.GetComponent<MeshRenderer>().material = plainMaterial;

            grid.levelDesign.tilesStateArray[tileX, tileZ] = 2;
            
        }

    }

}
