using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class DataCollection : MonoBehaviour
{
    //path to save the data file
    //public static string pathCsv = @"C:\users\admin\Desktop\Game1.csv";
    //private static string pathTxt = @"C:\users\Marietta\Documents\Game1.txt";
    private static string path = @"C:\users\Marietta\Desktop\Game1.csv";
    //public static string pathCsv = Application.dataPath + "/Game1.txt";
    private static DataCollection instance = null;
    private static string hand;
    private void Awake()
    {
        var streamWriters = new List<StreamWriter>();
        var date = DateTime.Now;
        if (instance == null) 
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this);
            return;
        }
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Game start: " + date);
            }

        }
        else
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Game start: " + date);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        var date = DateTime.Now;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game end: " + date + Environment.NewLine);
        }
    }
    public static void FirstGameData()
    {
        var left = Score.sumL.ToString();
        var right = Score.sumR.ToString();
        var range = FirstGameMenu.limit.ToString();
        var date = System.DateTime.Now;
        var speed = FirstGameMenu.tempSpeed;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 1 , Abduction");
            sw.WriteLine("Date/Time , ROM , Speed , Left Hand , Right Hand");
            sw.WriteLine(date + " , " + range + " , "+speed+ ", " + left +" / "+CreateObjects.amount+" , " + right + " / " + CreateObjects.amount);
        }
    }
    public static void SecondGameData()
    {
        if (SecondGameMenu.tempHand == 0)
        {
            hand = "Left";
        }
        else
            hand = "Right";
        var date = DateTime.Now;
        var goal = SecondGameMenu.tempGoal;
        var duration = Timer.time;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 2 , Horizontal flexion");
            sw.WriteLine("Date/Time , Goal , Hand , Duration");
            sw.WriteLine(date + " , " + goal+ " , "+hand+ ", " + duration);
        }
    }

    public static void ThirdGameData()
    {
        if (ThirdGameMenu.tempHand == 0)
        {
            hand = "Left";
        }
        else
            hand = "Right";
        var date = DateTime.Now;
        var duration = TimerSecond.time;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 3 , Vertical flexion");
            sw.WriteLine("Date/Time , Hand , Duration");
            sw.WriteLine(date + " , " +hand+ ", " + duration);
        }
    }

    public static void FourthGameData()
    {
        if (ThirdGameMenu.tempHand == 0)
        {
            hand = "Left";
        }
        else
            hand = "Right";
        var date = DateTime.Now;
        var duration = TimerThird.time;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 4 , Flexion/adduction");
            sw.WriteLine("Date/Time , Hand , Duration");
            sw.WriteLine(date + " , " +hand+ ", " + duration);
        }
    }
}
