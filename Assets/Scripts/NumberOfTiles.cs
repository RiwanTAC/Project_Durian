using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfTiles : MonoBehaviour
{
    //1-Variables
    //1.1- References
    GameMaster gm;

    public Text scoreText;

    // Void Start
    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    // Updating number of tile
    private void Update()
    {
        scoreText.text = gm.numberOfTile.ToString();
    }
}
