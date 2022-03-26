using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;


public class readCSV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        using (var reader = new StreamReader(@"C:\Users\AClea\Documents\GitHub\TEAM-08\Assets\Neuos-Emotions-example.csv"))
        {
            List<float> enjoymentArr = new List<float>();
            // List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                float value = float.Parse(values[2], CultureInfo.InvariantCulture.NumberFormat);

                enjoymentArr.Add(value);
                Debug.Log("Neuro enjoyment values: " + value + "\n");
                // listB.Add(values[1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
