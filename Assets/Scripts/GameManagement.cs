using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagement : MonoBehaviour
{
    public static int PointsP1 = 0;
    public static int PointsP2 = 0;
    public int maxPoints = 5;
    public TextMeshProUGUI PointsTxt1;
    public TextMeshProUGUI PointsTxt2;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PointsTxt1.text = PointsP1.ToString();
        PointsTxt2.text = PointsP2.ToString();
        if(PointsP1 == maxPoints)
        {

        }
        else if (PointsP1 == maxPoints)
        {
           
        }


    }
}
