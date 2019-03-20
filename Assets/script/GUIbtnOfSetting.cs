using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GUIbtnOfSetting : MonoBehaviour
{
    public Texture2D i1;
    public Texture2D i2;
    public static Texture2D i11;
    public Texture2D i12;
    public static Texture2D i21;
    public Texture2D i22;
    public static Texture2D btn1 ;
    public static Texture2D btn2 ;

    // Use this for initialization
    void Start ()
    {
        i11 = i1;
        i21 = i2;
        btn1 = i1;
        btn2 = i2;
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
        bb.fontSize = 50;       //当然，这是字体大小

  /*     if (GetComponent<GUIbtn>().Vuforiafound && !GetComponent<GUIbtn>().is_Experiment)
        {*/
            GUI.Label(new Rect(400, 60, 560, 20), "正在进行设置",bb);

            if (GUI.Button(new Rect(900, 50, 300, 85), btn1))
            {
                GameObject[] SmallScrews = GameObject.FindGameObjectsWithTag("小螺丝");    //获取小螺丝的组件
                GameObject[] BigScrews = GameObject.FindGameObjectsWithTag("大螺丝");      //获取大螺丝的组件
                if (btn1 == i11)
                {
                    btn1 = i12;
                    for (int i = 0; i < SmallScrews.Length; i++)
                    {
                        SmallScrews[i].AddComponent<RemoveSmallScrews>();
                    }
                    for (int i = 0; i < BigScrews.Length; i++)
                    {
                        BigScrews[i].AddComponent<RemoveBigScrews>();
                    }
                }
                else
                {
                    if (btn2 == i21)
                    {
                        btn1 = i11;
                        for (int i = 0; i < SmallScrews.Length; i++)
                        {
                            SmallScrews[i].AddComponent<InstallSmallScrews>();
                        }
                        for (int i = 0; i < BigScrews.Length; i++)
                        {
                            BigScrews[i].AddComponent<InstallBigScrews>();
                        }
                    }
                }
            }

            if (GUI.Button(new Rect(1250, 50, 300, 85), btn2))
            {
                GameObject[] Sensors = GameObject.FindGameObjectsWithTag("测重传感器");    //获取测重传感器的组件
                if (btn2 == i21)
                {
                    if (btn1 == i12)
                    {
                        btn2 = i22;
                     //   GameObject.Find("上部合金钢").transform.Translate(0, 0, -2);
                        GameObject.Find("刀口左上").transform.Translate(0, 0, -1.5f);
                        GameObject.Find("刀口右上").transform.Translate(0, 0, -1.5f);
                        GameObject.Find("上部架左").transform.Translate(0, 1f, 0);
                        GameObject.Find("上部架右").transform.Translate(0, 1f, 0);
                        GameObject.Find("连接杆左").transform.Translate(-8, 0, 0);
                        GameObject.Find("连接杆右").transform.Translate(8, 0, 0);
                        GameObject.Find("下部分合金钢 带刀口").transform.Translate(-1, 0, 0);
                        GameObject.Find("右端金属物").transform.Translate(0, 1f, 0);
                        GameObject.Find("圆柱桶支架").transform.Translate(0, -0.5f, 0);
                        GameObject.Find("左键").transform.Translate(0.5f, 0.8f, -0.5f);
                        GameObject.Find("右键").transform.Translate(0.5f, 0.5f, -0.5f);
                        GameObject.Find("圆柱桶").transform.Translate(0, 0.8f, -0.5f);
                        GameObject.Find("4个洞的装置").transform.Translate(-0.5f, 1.5f, 0);
                        GameObject.Find("上端薄盖").transform.Translate(0, 1f, 0);
                        GameObject.Find("油盖后").transform.Translate(0, 1f, 0);
                        for (int i = 0; i < Sensors.Length; i++)
                        {
                            Sensors[i].transform.Translate(0, 1f, 0);
                        }
                    }
                }
                else
                {
                    btn2 = i21;
                //    GameObject.Find("上部合金钢").transform.Translate(0, 0, 2);
                    GameObject.Find("刀口左上").transform.Translate(0, 0, 1.5f);
                    GameObject.Find("刀口右上").transform.Translate(0, 0, 1.5f);
                    GameObject.Find("上部架左").transform.Translate(0, -1f, 0);
                    GameObject.Find("上部架右").transform.Translate(0, -1f, 0);
                    GameObject.Find("连接杆左").transform.Translate(8, 0, 0);
                    GameObject.Find("连接杆右").transform.Translate(-8, 0, 0);
                    GameObject.Find("下部分合金钢 带刀口").transform.Translate(1, 0, 0);
                    GameObject.Find("右端金属物").transform.Translate(0, -1f, 0);
                    GameObject.Find("圆柱桶支架").transform.Translate(0, 0.5f, 0);
                    GameObject.Find("左键").transform.Translate(-0.5f, -0.8f, 0.5f);
                    GameObject.Find("右键").transform.Translate(-0.5f, -0.5f, 0.5f);
                    GameObject.Find("圆柱桶").transform.Translate(0, -0.8f, 0.5f);
                    GameObject.Find("4个洞的装置").transform.Translate(0.5f, -1.5f, 0);
                    GameObject.Find("上端薄盖").transform.Translate(0, -1f, 0);
                    GameObject.Find("油盖后").transform.Translate(0, -1f, 0);
                    for (int i = 0; i < Sensors.Length; i++)
                    {
                        Sensors[i].transform.Translate(0, -1f, 0);
                    }
                }
            }
 //       }
    }
}
