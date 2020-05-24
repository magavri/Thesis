using UnityEngine;
using System.IO;
using System;

public class SavingData : MonoBehaviour
{
    //path to save the data file
    public static string path = @"C:\users\admin\Desktop\Game1.csv";
    //public static string path = Application.dataPath + "/Game1.txt";
  
    void Start()
    {
        CreateFile();
    }

    /// <summary>
    /// Checking if the file doesn't exists and writing the teplate
    /// </summary>
    void CreateFile()
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Date/Time , ROM , Speed , Left Hand , Right Hand");
            File.AppendAllText(path, Environment.NewLine);
        }
    }
   /// <summary>
   /// Writing all collected data to the file
   /// </summary>
    public static void WriteToFile()
    {
        var left = Score.sumL.ToString();
        var right = Score.sumR.ToString();
        var range = FirstGameMenu.limit.ToString();
        var date = System.DateTime.Now;
        var speed = FirstGameMenu.tempSpeed;
        string record = date + " , " + range + " , "+speed+ ", " + left +" / "+CreateObjects.amount+" , " + right + " / " + CreateObjects.amount + Environment.NewLine;
        File.AppendAllText(path, record);
    }
}
