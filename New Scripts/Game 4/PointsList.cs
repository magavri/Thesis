using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tempCircles = new List<GameObject>();
    [SerializeField]
    private List<GameObject> tempStars = new List<GameObject>();
    [SerializeField]
    private List<GameObject> tempNames = new List<GameObject>();
    [SerializeField]
    private List<GameObject> tempConstellations = new List<GameObject>();
    public static List<GameObject> circles;
    public static List<GameObject> stars;
    public static List<GameObject> names;
    public static List<GameObject> constellations;
    private void Start()
    {
        circles= new List<GameObject>(tempCircles);
        stars = new List<GameObject>(tempStars);
        names = new List<GameObject>(tempNames);
        constellations = new List<GameObject>(tempConstellations);
    }
}