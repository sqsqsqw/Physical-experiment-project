using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ManualExp : MonoBehaviour
{
    private int num = 0;
    private int[] loaddata = new int[10];
    private double[][] local;
    public Texture idelete;
    public Texture isave;
    public Texture izero;
    // Use this for initialization
    void Start()
    {
        num = 0;

        local = new double[5][];
        for (int i = 0; i < 5; i++)
        {
            local[i] = new double[50];
            for (int j = 0; j < 5; j++)
            {
                local[i][j] = -99999999;
            }
        }
        for (int i = 0; i < 10; i++)
            loaddata[i] = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充
        bb.normal.textColor = new Color(1, 1, 1);   //设置字体颜色的
        bb.fontSize = 50;//设置字体大小
        GUI.Label(new Rect(100, 300, 50, 30), "载 荷：", bb); //900, 50, 160, 50
        GetComponent<GUIbtnOfExperiment>().masterVolume = GUI.HorizontalSlider(new Rect(280, 325, 200, 30), GetComponent<GUIbtnOfExperiment>().masterVolume, 0.0f, 1.0f); //800, 50, 160, 50
        GUI.Label(new Rect(500, 300, 50, 30),(GetComponent<GUIbtnOfExperiment>().masterVolume * 250).ToString("f0")+"", bb); //900, 50, 160, 50
        var a = GUI.skin.horizontalSlider;
        GUI.Label(new Rect(1000, 300, 200, 30),
            "data1:"+ GetComponent<GUIbtnOfExperiment>().d1.ToString("f0") + "  data2:" + GetComponent<GUIbtnOfExperiment>().d2.ToString("f0") + "  data3:" + GetComponent<GUIbtnOfExperiment>().d3.ToString("f0") + "  data4:" + GetComponent<GUIbtnOfExperiment>().d4.ToString("f0") + "  data5:" + GetComponent<GUIbtnOfExperiment>().d5.ToString("f0")
            , bb );

        if (local[0][0] != -99999999 && local[0][1] != -99999999 && local[0][2] != -99999999 && local[0][3] != -99999999 && local[0][4] != -99999999)
        {
           // GUI.Label(new Rect(200, 260, 200, 30), "id   force   data1   data2   data3   data4   data5", bb);
            GUI.Label(new Rect(100, 400, 50, 40), "1" + " " + ":" + "   " + loaddata[0] + "  " + local[0][0].ToString("0.") + "  " + local[0][1].ToString("0.") + "  " + local[0][2].ToString("0.") + "  " + local[0][3].ToString("0.") + "  " + local[0][4].ToString("0."), bb);
        }
        if (local[1][0] != -99999999 && local[1][1] != -99999999 && local[1][2] != -99999999 && local[1][3] != -99999999 && local[1][4] != -99999999)
            GUI.Label(new Rect(100, 460, 50, 40), "2" + " " + ":" + "   " + loaddata[1] + "  " + local[1][0].ToString("0.") + "  " + local[1][1].ToString("0.") + "  " + local[1][2].ToString("0.") + "  " + local[1][3].ToString("0.") + "  " + local[1][4].ToString("0."), bb);
        if (local[2][0] != -99999999 && local[2][1] != -99999999 && local[2][2] != -99999999 && local[2][3] != -99999999 && local[2][4] != -99999999)  
            GUI.Label(new Rect(100, 520, 50, 40), "3" + " " + ":" + "   " + loaddata[2] + "  " + local[2][0].ToString("0.") + "  " + local[2][1].ToString("0.") + "  " + local[2][2].ToString("0.") + "  " + local[2][3].ToString("0.") + "  " + local[2][4].ToString("0."), bb);
        if (local[3][0] != -99999999 && local[3][1] != -99999999 && local[3][2] != -99999999 && local[3][3] != -99999999 && local[3][4] != -99999999)
            GUI.Label(new Rect(100, 580, 50, 40), "4" + " " + ":" + "   " + loaddata[3] + "  " + local[3][0].ToString("0.") + "  " + local[3][1].ToString("0.") + "  " + local[3][2].ToString("0.") + "  " + local[3][3].ToString("0.") + "  " + local[3][4].ToString("0."), bb);
        if (local[4][0] != -99999999 && local[4][1] != -99999999 && local[4][2] != -99999999 && local[4][3] != -99999999 && local[4][4] != -99999999)
            GUI.Label(new Rect(100, 640, 50, 40), "5" + " " + ":" + "   " + loaddata[4] + "  " + local[4][0].ToString("0.") + "  " + local[4][1].ToString("0.") + "  " + local[4][2].ToString("0.") + "  " + local[4][3].ToString("0.") + "  " + local[4][4].ToString("0."), bb);
        if (GUI.Button(new Rect(100, 180, 200, 55), isave))          //保存按钮
            if (num <= 4) {
                local[num][0] = GetComponent<GUIbtnOfExperiment>().d1;
                local[num][1] = GetComponent<GUIbtnOfExperiment>().d2;
                local[num][2] = GetComponent<GUIbtnOfExperiment>().d3;
                local[num][3] = GetComponent<GUIbtnOfExperiment>().d4;
                local[num][4] = GetComponent<GUIbtnOfExperiment>().d5;
                loaddata[num++] = (int)(GetComponent<GUIbtnOfExperiment>().masterVolume * 250);
            }
        if (GUI.Button(new Rect(350, 180, 200, 55), idelete)) {        //删除按钮
            num = 0;
            for (int i = 0; i < 10; i++)
                loaddata[i] = -1;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    local[i][j] = -99999999;
            File.Delete("jar:file://mandata.txt");

        }
        if (GUI.Button(new Rect(600, 180, 200, 55), izero))      //调零按钮
            GetComponent<GUIbtnOfExperiment>().zeo();
    }



}
