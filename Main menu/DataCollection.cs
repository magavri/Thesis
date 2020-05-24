using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataCollection : MonoBehaviour
{
    //path to save the data file
    //public static string pathCsv = @"C:\users\admin\Desktop\Game1.csv";
    private static string path = @"C:\users\Marietta\Desktop\Game1.csv";
    //instance of the class
    private static DataCollection instance = null;
    //hand selection
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

   /// <summary>
   /// Marking end time of the game
   /// </summary>
   private void OnApplicationQuit()
    {
        var date = DateTime.Now;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game end: " + date + Environment.NewLine);
        }
    }
   /// <summary>
   /// Collecting first game data
   /// </summary>
    public static void FirstGameData()
    {
        //final score for left hand
        var left = Score.sumL.ToString();
        //final score for the right hand
        var right = Score.sumR.ToString();
        //limit for range of morion
        var range = FirstGameMenu.limit.ToString();
        //date played
        var date = System.DateTime.Now;
        //speed of the moving obstacled
        var speed = FirstGameMenu.tempSpeed;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 1 , Abduction");
            sw.WriteLine("Date/Time , ROM , Speed , Left Hand , Right Hand");
            sw.WriteLine(date + " , " + range + " , "+speed+ ", " + left +" / "+CreateObjects.amount+" , " + right + " / " + CreateObjects.amount);
        }
    }
   
   /// <summary>
   /// Collecting data for the second game
   /// </summary>
   public static void SecondGameData()
    {
        //hand selection from settings menu
        if (SecondGameMenu.tempHand == 0)
        {
            hand = "Left";
        }
        else
            hand = "Right";
        //date played
        var date = DateTime.Now;
        //goal selected from menu
        var goal = SecondGameMenu.tempGoal;
        //time spent to achieve the goal
        var duration = Timer.time;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 2 , Horizontal flexion");
            sw.WriteLine("Date/Time , Goal , Hand , Duration");
            sw.WriteLine(date + " , " + goal+ " , "+hand+ ", " + duration);
        }
    }

   /// <summary>
   /// Collecting data for the third game
   /// </summary>
   public static void ThirdGameData()
    {
        //hand selection from menu
        if (ThirdGameMenu.tempHand == 0)
        {
            hand = "Left";
        }
        else
            hand = "Right";
        //date played
        var date = DateTime.Now;
        //time spent for the game
        var duration = TimerSecond.time;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 3 , Vertical flexion");
            sw.WriteLine("Date/Time , Hand , Duration");
            sw.WriteLine(date + " , " +hand+ ", " + duration);
        }
    }

   /// <summary>
   /// Collecting data for the fourth hand
   /// </summary>
    public static void FourthGameData()
    {
        //and selection
        if (ThirdGameMenu.tempHand == 0)
        {
            hand = "Left";
        }
        else
            hand = "Right";
        //date played
        var date = DateTime.Now;
        //time spent to complete the game
        var duration = TimerThird.time;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("Game 4 , Flexion/adduction");
            sw.WriteLine("Date/Time , Hand , Duration");
            sw.WriteLine(date + " , " +hand+ ", " + duration);
        }
    }
}
