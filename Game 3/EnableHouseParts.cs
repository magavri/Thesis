using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHouseParts : MonoBehaviour
{
   public List<GameObject> temp = new List<GameObject>();
   public static List<GameObject> parts;
   private void Start()
   {
      parts = new List<GameObject>(temp);
   }
}

