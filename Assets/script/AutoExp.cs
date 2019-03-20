using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class AutoExp : MonoBehaviour
{
    public int data;
    private string Connect_ip;
    public int Connect_port;

    private GameObject VuCamera;
    private TcpClient tcpClient;
    private short[] rdata;
    private int num = 0;
    private int inum = 0;
    private int[] D = { 0, 0, 0, 0, 0, 0 };
    public int[] d = { 0, 0, 0, 0, 0, 0 };
    private double[][] local;
    public Texture idelete;
    public Texture isave;
    public Texture izero;

    // Use this for initialization
    void Start()
    {
        VuCamera = GameObject.FindGameObjectWithTag("camera");
        Connect_ip = "192.168.0.200";
        Connect_port = 4196;


        local = new double[5][];
        for (int i = 0; i < 5; i++)
        {
            local[i] = new double[5];
            for (int j = 0; j < 5; j++)
            {
                local[i][j] = -99999999;
            }
        }
        
        Open(Connect_ip, Connect_port);
    }

    // Update is called once per frame
    void Update()
    {
        num++;
        byte[] rData = null;
        if (num == 200)
        {

            if (ReceiveData(ref rData, 0x02, 1, 11))
            {
                for (int i = 1; i <= 5; i++)
                {
                    byte[] temp = {rData[i*4+4] , rData[i * 4 + 3], rData[i * 4 + 2], rData[i * 4 + 1]};
                    double num = BitConverter.ToSingle(temp,0)/500;
                    D[i - 1] = (int)Math.Round(num, 0);

                    /*  D[0] =(rData[5] * 256 * 256 * 256 + rData[6] * 256 * 256 + rData[7] * 256 + rData[8]);
                      D[1] = rData[9] * 256 * 256 * 256 + rData[10] * 256 * 256 + rData[11] * 256 + rData[12];
                      D[2] = rData[13] * 256 * 256 * 256 + rData[14] * 256 * 256 + rData[15] * 256 + rData[16];
                      D[3] = rData[17] * 256 * 256 * 256 + rData[18] * 256 * 256 + rData[19] * 256 + rData[20];
                      D[4] = rData[21] * 256 * 256 * 256 + rData[22] * 256 * 256 + rData[23] * 256 + rData[24];*/
                }
            }
            num = 0;
        }

    }
    void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = new Color(1, 1, 1);   //设置字体颜色的
        bb.fontSize = 50;

        GUI.Label(new Rect(1000, 300, 200, 30),
           "data1:" + (D[0] - d[0]) + "  data2:" + (D[1] - d[1]) + "  data3:" + (D[2] - d[2]) + "  data4:" + (D[3] - d[3]) + "  data5:" + (D[4] - d[4]), bb);

        if (GUI.Button(new Rect(600, 180, 200, 55), izero))//1400, 50, 160, 50
        {
            for (int i = 0; i < D.Length; i++)
                d[i] = D[i];
        }


        if (local[0][0] != -99999999 && local[0][1] != -99999999 && local[0][2] != -99999999 && local[0][3] != -99999999 && local[0][4] != -99999999)
        {
            // GUI.Label(new Rect(200, 260, 200, 30), "id   force   data1   data2   data3   data4   data5", bb);
            GUI.Label(new Rect(100, 400, 50, 40), "1" + " " + ":" + "     " + local[0][0].ToString("0.") + "     " + local[0][1].ToString("0.") + "     " + local[0][2].ToString("0.") + "     " + local[0][3].ToString("0.") + "     " + local[0][4].ToString("0."), bb);
        }
        if (local[1][0] != -99999999 && local[1][1] != -99999999 && local[1][2] != -99999999 && local[1][3] != -99999999 && local[1][4] != -99999999)
            GUI.Label(new Rect(100, 460, 50, 40), "2" + " " + ":" + "     " + local[1][0].ToString("0.") + "     " + local[1][1].ToString("0.") + "     " + local[1][2].ToString("0.") + "     " + local[1][3].ToString("0.") + "     " + local[1][4].ToString("0."), bb);
        if (local[2][0] != -99999999 && local[2][1] != -99999999 && local[2][2] != -99999999 && local[2][3] != -99999999 && local[2][4] != -99999999)
            GUI.Label(new Rect(100, 520, 50, 40), "3" + " " + ":" + "     " + local[2][0].ToString("0.") + "     " + local[2][1].ToString("0.") + "     " + local[2][2].ToString("0.") + "     " + local[2][3].ToString("0.") + "     " + local[2][4].ToString("0."), bb);
        if (local[3][0] != -99999999 && local[3][1] != -99999999 && local[3][2] != -99999999 && local[3][3] != -99999999 && local[3][4] != -99999999)
            GUI.Label(new Rect(100, 580, 50, 40), "4" + " " + ":" + "     " + local[3][0].ToString("0.") + "     " + local[3][1].ToString("0.") + "     " + local[3][2].ToString("0.") + "     " + local[3][3].ToString("0.") + "     " + local[3][4].ToString("0."), bb);
        if (local[4][0] != -99999999 && local[4][1] != -99999999 && local[4][2] != -99999999 && local[4][3] != -99999999 && local[4][4] != -99999999)
            GUI.Label(new Rect(100, 640, 50, 40), "5" + " " + ":" +  "     " + local[4][0].ToString("0.") + "     " + local[4][1].ToString("0.") + "     " + local[4][2].ToString("0.") + "     " + local[4][3].ToString("0.") + "     " + local[4][4].ToString("0."), bb);
        if (GUI.Button(new Rect(100, 180, 200, 55), isave))//1000, 50, 160, 50
            if (inum <= 4)
            {
                local[inum][0] = (D[0] - d[0]);
                local[inum][1] = (D[1] - d[1]);
                local[inum][2] = (D[2] - d[2]);
                local[inum][3] = (D[3] - d[3]);
                local[inum][4] = (D[4] - d[4]);
                inum++;
            }
        if (GUI.Button(new Rect(350, 180, 200, 55), idelete))//1200,50,160,50
        {
            inum = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    local[i][j] = -99999999;
            File.Delete("jar:file://data.txt");

        }

    }


    public bool Open(string ip, int port)//开启通信
    {
        try
        {
            tcpClient = new TcpClient();

            tcpClient.Connect(IPAddress.Parse(ip), port);

            return true;
        }
        catch (SocketException e)
        {
            string m = string.Format("modbus Client服务器连接错误:{0},ip:{1},port:{2}", e.Message, ip, port);
            print(m);
            return false;
        }
    }


    public bool ReceiveData(ref byte[] rData, byte id, byte address, byte len)//接收数据
    {


        try 
        {
            short m = Convert.ToInt16(new System.Random().Next(2, 20));

            byte[] bs = Receive(id, address, len);
            rData = bs;
            return true;
        }
        catch (Exception e)
        {
            print("返回Modbus数据错误" + e.Message);
            return false;
        }
    }


    private byte[] Receive(byte id, byte address, byte len)
    {
        try
        {
            if (tcpClient == null || !tcpClient.Connected) { return null; }

            byte[] data = GetSrcData(id, address, len);
            //00 00 00 00 00 06 01 03 00 00 00 05  

            tcpClient.Client.Send(data, data.Length, SocketFlags.None);
            int size = len * 2 + 5;

            byte[] rData = new byte[size];

            tcpClient.Client.Receive(rData, size, SocketFlags.None);
            //string t1 = TranBytes(rData);  

            return rData;

        }
        catch (SocketException e)
        {
            if (e.ErrorCode != 10004)
            {
                print(e.Message);
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }

            return null;
        }
    }

    private byte[] GetSrcData(byte id, byte add, byte len)
    {
        byte[] dtmp = new byte[6];
        dtmp[0] = 0x02;
        dtmp[1] = 0x03;
        dtmp[2] = 0x00;
        dtmp[3] = add;
        dtmp[4] = 0x00;
        dtmp[5] = len;
        byte[] ctmp = new byte[2];
        ctmp[0] = CRC16(dtmp)[0];
        ctmp[1] = CRC16(dtmp)[1];


        byte[] res = { dtmp[0], dtmp[1], dtmp[2], dtmp[3], dtmp[4], dtmp[5], ctmp[0], ctmp[1] };
        return res;
    }



    public static byte[] CRC16(byte[] data)
    {
        int len = data.Length;
        if (len > 0)
        {
            ushort crc = 0xFFFF;

            for (int i = 0; i < len; i++)
            {
                crc = (ushort)(crc ^ (data[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                }
            }
            byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
            byte lo = (byte)(crc & 0x00FF);         //低位置

            return new byte[] { lo, hi };
        }
        return new byte[] { 0, 0 };
    }
    

    






}
