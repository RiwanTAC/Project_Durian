using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //1- Variable
    public List<Node> neighbours;

    public int x;
    public int z;

    //2- Creating the Node's list
    public Node()
    {
        neighbours = new List<Node>();
    }

    //3- Calculating the distance between two nodes
    public float DistanceTo(Node n)
    {
        return Vector3.Distance(new Vector3(x, 0, z), new Vector3(n.x, 0, n.z));
    }

}
