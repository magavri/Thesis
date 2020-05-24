using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSortingLayer : MonoBehaviour
{
  
    /// <summary>
    /// Assigning sorting layer for the textmesh
    /// containing spent time result
    /// </summary>
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = "End menu";
        gameObject.GetComponent<MeshRenderer>().sortingOrder = 2;
    }

}
