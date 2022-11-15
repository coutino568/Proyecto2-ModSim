using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportA.csv" )) {}
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportB.csv" )) {}
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportC.csv" )) {}
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportLeft.csv" )) {}
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportTotal.csv" )) {}
    }

    public Text storeAText;
    public Text storeBText;
    public Text storeCText;
    public Text headCountText;
    public Text timeElapsedText;

    //infomraicon para exportar

    public static int visitorsA=0;
    public static int visitorsB=0;
    public static int visitorsC=0;
    public static float transitionTime = 3f;
    public static int headCount = 0;
    public static int left = 0;
    public static float xLowerEnd ;
    public static float xUpperEnd ;
    public static float zLowerEnd ;
    public static float zUpperEnd ;
    public static float probability;
    float mytime = 0;

    float timer =0f;
    float timerInterval = 1f;

    // probabilidades del input
    public static int customerTraffic =0;
    public static float probabilityStore= 0.5f;
    public static float probabilityA= 0.34f;
    public static float probabilityB= 0.33f;
    public static float probabilityC= 0.33f;


    // Update is called once per frame
    void Update()
    {
        mytime += Time.deltaTime;
        storeAText.text = visitorsA.ToString();
        storeBText.text = visitorsB.ToString();
        storeCText.text = visitorsC.ToString();
        headCountText.text = headCount.ToString();
        timeElapsedText.text = mytime.ToString();
        
        
        timer += Time.deltaTime;
        if (timer >= timerInterval)
        {
            //Debug.Log(timerInterval.ToString()+ " seconds have passed!");
            timer = 0;
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportA.csv"))
            {
                sw.WriteLine(visitorsA.ToString());

            }
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportB.csv"))
            {
                sw.WriteLine(visitorsB.ToString());

            }
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportC.csv"))
            {
                sw.WriteLine(visitorsC.ToString());

            }
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportTotal.csv"))
            {
                sw.WriteLine(headCount.ToString());

            }
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportLeft.csv"))
            {
                sw.WriteLine(left.ToString());

            }
            
        }

    }
}
