using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ClickLogger : MonoBehaviour
{
    public List<Vector2> clickPositions = new List<Vector2>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPositions.Add(clickPosition);
            //Debug.Log("click position x:", clickPosition.x);
        }
        SaveClicks();
    }

    public void SaveClicks()
    {
        // TODO: relative path
        string filePath = "C:/Users/Install/Desktop/ClimateMuseum/ClimateEnv_3D_TouchTable_Exp/Assets" + "/clicks.csv";
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            foreach (Vector2 clickPosition in clickPositions)
            {
                writer.WriteLine($"{clickPosition.x},{clickPosition.y}");
            }
        }
    }
}
