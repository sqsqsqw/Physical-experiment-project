using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIbtn : MonoBehaviour {
    public  bool is_Experiment = false;
    public Texture btn11 ;
    public bool Vuforiafound = false;
    public Texture iClickToStart;
    public Texture iExp;
    public Texture iSet;
    public GameObject VuCamera;


    // Use this for initialization
    void Start ()
    {
        VuCamera.GetComponent<GUIbtnOfExperiment>().enabled = false;
        VuCamera.GetComponent<GUIbtnOfSetting>().enabled = false;
        VuCamera.GetComponent<ManualExp>().enabled = false;
        VuCamera.GetComponent<AutoExp>().enabled = false;
        btn11 = iClickToStart;
    }
	
	// Update is called once per frame
	void Update () 
    {
    }
    void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = new Color(1,1,1);   //设置字体颜色的
        bb.fontSize = 50;       //这是字体大小  
        if (Vuforiafound)
        {
            if (GUI.Button (new Rect(50,50,300,85),btn11)) 
            {
                if (is_Experiment)
                {
                    is_Experiment = !is_Experiment;
                    btn11 = iSet;
                    VuCamera.GetComponent<GUIbtnOfSetting>().enabled = true;
                    VuCamera.GetComponent<GUIbtnOfExperiment>().enabled = false;
                    VuCamera.GetComponent<ManualExp>().enabled = false;
                    VuCamera.GetComponent<AutoExp>().enabled = false;
                }
                else
                {
                    if (GUIbtnOfSetting.btn1 == GUIbtnOfSetting.i11 && GUIbtnOfSetting.btn2 == GUIbtnOfSetting.i21)
                    {
                        is_Experiment = !is_Experiment;
                        btn11 = iExp;
                        VuCamera.GetComponent<GUIbtnOfExperiment>().enabled = true;
                        VuCamera.GetComponent<GUIbtnOfSetting>().enabled = false;
                    }
                }
            
            }

        }
        else
        {

            GUI.Label(new Rect(680, 20, 500, 23), "请将镜头放置在对应的图片上",bb);
            VuCamera.GetComponent<GUIbtnOfSetting>().enabled = false;
            VuCamera.GetComponent<GUIbtnOfExperiment>().enabled = false;
            VuCamera.GetComponent<ManualExp>().enabled = false;
            VuCamera.GetComponent<AutoExp>().enabled = false;
            btn11 = iClickToStart;
            is_Experiment = false;
        }
       
    }
        
}
