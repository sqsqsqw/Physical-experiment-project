using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GUIbtnOfExperiment : MonoBehaviour {

    public float masterVolume = 0.0f;
    public Texture iManExp;
    public Texture iAutoExp;
    private float database = 0f;
    private float rotateangle = 0f;

    private GameObject VuCamera;

    private static bool manual;
    private static bool auto;
    private static bool is_Random = false;
    public  double d1=0;
    public  double d2=0;
    public  double d3=0;
    public  double d4=0;
    public  double d5=0;
    private double D1 = 0;
    private double D2 = 0;
    private double D3 = 0;
    private double D4 = 0;
    private double D5 = 0;
    // Use this for initialization
    void Start ()
    {
        VuCamera = GameObject.FindGameObjectWithTag("camera");
        manual = false;
        auto = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (database <= (masterVolume * 250f)-1f || database >= (masterVolume * 250f) + 1f)
        {
            double val = masterVolume * 250f*11/50f;
            D1 += Random();
            D2 += Random();
            D3 += Random();
            D4 += Random();
            D5 += Random();
            database = (masterVolume * 250f);
            d1 = (val) * 2 + D1;
            d2 = (val) + D2;
            d3 = 0 + D3;
            d4 = -(val) + D3;
            d5 = -(val) * 2 + D4;
        }
        if(rotateangle < (masterVolume * 250f)-1f)
        {
            GameObject.Find("手轮2 ").transform.Rotate(new Vector3(0, 5, 0));
            rotateangle += 2f;
        }
        else  if (rotateangle > (masterVolume * 250f) + 1f)
        {
            GameObject.Find("手轮2 ").transform.Rotate(new Vector3(0, -5, 0));
            rotateangle -= 2f;
        }
        if(GameObject.Find("ARCamera").GetComponent<GUIbtn>().Vuforiafound == false)
        {
            manual = false;
            auto = false;
        }



    }
    void OnGUI()
    { 
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = new Color(1,1,1);   //设置字体颜色的



        bb.fontSize = 50;       //当然，这是字体大小

     /*   if (GetComponent<GUIbtn>().Vuforiafound && GetComponent<GUIbtn>().is_Experiment)
        {*/
            GUI.Label(new Rect(400, 60, 120, 23), "正在进行实验",bb);
        if (GUI.Button(new Rect(900, 50, 300, 85), iManExp) && manual == false)
        {
            VuCamera.GetComponent<ManualExp>().enabled = true;
            VuCamera.GetComponent<AutoExp>().enabled = false;
            manual = true;
            auto = false;
        }
        if (GUI.Button(new Rect(1250, 50, 300, 85), iAutoExp) && auto == false)
        {
            VuCamera.GetComponent<ManualExp>().enabled = false;
            VuCamera.GetComponent<AutoExp>().enabled = true;
            manual = false;
            auto = true;
        }
    }
    public double Random()
    {

        if (!is_Random)
        {
            System.Random rd = new System.Random();
            double result = 0;
            bool is_positive = true;
            if (rd.Next(0, 10) < 5)
                is_positive = false;
            if (rd.Next(0, 60) < 3)
            {
                result = 1;
                is_Random = !is_Random;
            }

            if (!is_positive)
                result = -result;
            return result;
        }
        else
        {
            is_Random = !is_Random;
            return 0;
        }

    }
    public void zeo()
    {
        D1 = 0;
        D2 = 0;
        D3 = 0;
        D4 = 0;
        D5 = 0;
        database = 0;
    }
}
