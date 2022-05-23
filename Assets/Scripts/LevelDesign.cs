using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create a New Level")]
public class LevelDesign : ScriptableObject
{
    [SerializeField]
    public int[] tilesStateArray;

}
