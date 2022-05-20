using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    //1- Variable
    public GameMaster gm;
    public GameObject buildingPanel;

    //2- Void Start
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        buildingPanel.SetActive(false);
    }

    //3- Different Modes
    //3.1- Building Mode
    public void BuildingMode()
    {
        gm.isInBuildingMode = true;
        gm.isInPaintingMode = false;
        gm.isInRepairMode = false;

        buildingPanel.SetActive(true);
    }
    //3.2- Painting Mode
    public void PaintingMode()
    {
        gm.isInBuildingMode = false;
        gm.isInPaintingMode = true;
        gm.isInRepairMode = false;

        buildingPanel.SetActive(false);
    }
    //3.3- Repair Mode
    public void RepairMode()
    {
        gm.isInBuildingMode = false;
        gm.isInPaintingMode = false;
        gm.isInRepairMode = true;

        buildingPanel.SetActive(false);
    }
}
