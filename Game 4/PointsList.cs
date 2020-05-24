using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsList : MonoBehaviour
{
    //list to store circle sprites
    [SerializeField]
    private List<GameObject> tempCircles = new List<GameObject>();
    //list to store star sprites
    [SerializeField]
    private List<GameObject> tempStars = new List<GameObject>();
    //list to store names of the constellations
    [SerializeField]
    private List<GameObject> tempNames = new List<GameObject>();
    //list to store constellation game objects
    [SerializeField]
    private List<GameObject> tempConstellations = new List<GameObject>();
    public static List<GameObject> circles;
    public static List<GameObject> stars;
    public static List<GameObject> names;
    public static List<GameObject> constellations;
   //storing game objects specified in the inspector to the static list
    private void Start()
    {
        circles= new List<GameObject>(tempCircles);
        stars = new List<GameObject>(tempStars);
        names = new List<GameObject>(tempNames);
        constellations = new List<GameObject>(tempConstellations);
    }
}