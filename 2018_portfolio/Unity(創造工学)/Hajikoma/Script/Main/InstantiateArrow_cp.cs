using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class InstantiateArrow_cp : MonoBehaviour
{
    //Script
    MasterStreetView master;

    public GameObject warpUp;
    public GameObject warpDown;
    private GameObject objWarp;
    public GameObject infoButton;
    private GameObject objInfoButton;
    public GameObject arrow;
    public float arrow_position_z = -0.035f;
    public float r = 0.77f;

    GameObject[] objlist = new GameObject[100];
    List<GameObject> objList = new List<GameObject>() { null, null, null };

    private double[,] Map_Data = new double[100, 100];
    private string[,] Map_Data_info = new string[100, 100];
    float[] coordinate = new float[2];
    float arrow_position_x = 0;
    float arrow_position_y = 0;


    //const
    const int x = 3;
    const int y = 2;
    const int stairNumber = 6;
    const int dir_count = 13;
    const int build_name = 10;
    const int detail_info = 11;
    const int build_picture_name = 12;

    private void Start()
    {
        master = GetComponent<MasterStreetView>();
    }

    public void receiveMapData(double[,] a, string[,] b)
    {
        Map_Data = a;
        Map_Data_info = b;
    }

    private int You_are_here = 0;
    public int receivePosition
    {
        get { return You_are_here; }
        set
        {
            You_are_here = value;
            Debug.Log("InstantiateArrow" + You_are_here);
            //Instantiate();
        }
    }

    //Effect finish
    private bool cameraEffectFinshFlag = false;
    public bool receiveCameraEffectFinshFlag
    {
        get { return cameraEffectFinshFlag; }
        set
        {
            cameraEffectFinshFlag = value;
        }
    }


    void Instantiate()
    {
        ////削除処理start
        //if (objlist[0] != null)

        for (int j = 0; j < objList.Count; j++)
        {
            //Debug.Log("destroy:" + objlist[j].name);
            Destroy(objList[j]);
            objList[j] = null;
        }

        if (objInfoButton != null) Destroy(objInfoButton);
        Debug.Log("dir_count" + Map_Data[You_are_here, dir_count]);
        if (objWarp != null) Destroy(objWarp);

        //削除finish

        for (int i = 1; i <= Map_Data[You_are_here, dir_count]; i++)
        {
            //生成処理
            int next_dir = (int)Map_Data[You_are_here, dir_count + i];
            Debug.Log("next" + next_dir);
            //***********************************
            //階段だと座標差0なのでエラーがでるため、階段とそれ以外で分岐処理
            //ネクストが違う階ならだす
            if (Map_Data[You_are_here, stairNumber] != 0 && Map_Data[next_dir, stairNumber] != 0 && Map_Data[You_are_here, stairNumber] != Map_Data[next_dir, stairNumber])
            {
                if (Map_Data[next_dir, stairNumber] == 2)
                {
                    objWarp = Instantiate(warpUp);
                    objWarp.name = next_dir.ToString();
                    //obj.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                    objWarp.transform.GetChild(0).name = next_dir.ToString();
                    Debug.Log("Up:" + next_dir);
                }
                else if (Map_Data[next_dir, stairNumber] == 1)
                {
                    objWarp = Instantiate(warpDown);
                    objWarp.name = next_dir.ToString(); ;
                    objWarp.transform.GetChild(0).name = next_dir.ToString();
                    Debug.Log("Up:" + next_dir);
                }
            }
            else
            {
                double delta_x = Map_Data[next_dir, x] - Map_Data[You_are_here, x];
                double delta_y = Map_Data[next_dir, y] - Map_Data[You_are_here, y];
                Debug.Log("x1=" + Map_Data[next_dir, x] + "-" + Map_Data[You_are_here, x] + "x0=" + delta_x);
                Debug.Log("y1=" + Map_Data[next_dir, y] + "-" + Map_Data[You_are_here, y] + "y0=" + delta_y);
                //角度
                float degree = (float)(Math.Abs(Math.Atan(delta_y / delta_x) * Mathf.Rad2Deg));
                Debug.Log("degree_before" + degree);
                if (delta_x > 0 && delta_y > 0)
                {
                    arrow_position_x = r * Mathf.Cos(degree * Mathf.Deg2Rad);
                    arrow_position_y = r * Mathf.Sin(degree * Mathf.Deg2Rad);
                    degree = 90 - degree;
                    Debug.Log(i + "delta_x > 0 && delta_y > 0");

                }
                else if (delta_x > 0 && delta_y < 0)
                {
                    arrow_position_x = r * Mathf.Cos(degree * Mathf.Deg2Rad);
                    arrow_position_y = -(r * Mathf.Sin(degree * Mathf.Deg2Rad));
                    degree = 90 + degree;
                    Debug.Log(i + "delta_x > 0 && delta_y < 0");
                }
                else if (delta_x < 0 && delta_y < 0)
                {

                    arrow_position_x = -(r * Mathf.Cos(degree * Mathf.Deg2Rad));
                    arrow_position_y = -(r * Mathf.Sin(degree * Mathf.Deg2Rad));
                    degree = 180 + (90 - degree);
                    Debug.Log(i + "delta_x < 0 && delta_y < 0");
                }
                else if (delta_x < 0 && delta_y > 0)
                {
                    arrow_position_x = -(r * Mathf.Cos(degree * Mathf.Deg2Rad));
                    arrow_position_y = r * Mathf.Sin(degree * Mathf.Deg2Rad);
                    degree = 270 + degree;
                    Debug.Log(i + "delta_x < 0 && delta_y > 0");
                }
                Debug.Log("degree_after" + degree);
                arrow.transform.eulerAngles = new Vector3(0, degree + 6.34f, 0);
                //位置
                Debug.Log("arrow_position_x=" + arrow_position_x);
                Debug.Log("arrow_position_y=" + arrow_position_y);

                //生成
                GameObject obj1 = Instantiate(arrow, new Vector3(arrow_position_x, arrow_position_z, arrow_position_y), arrow.transform.rotation) as GameObject;
                //名前をつける
                obj1.name = next_dir.ToString();
                objList.Add(obj1);
                ////objlist[i - 1] = obj1;

                //主要建物なら→色変更
                if (Map_Data_info[next_dir, build_name] != "0")//ifなら二個のオブジェクトをつくる
                {
                    //特殊なスイッチ製作
                    //arrow.transform.eulerAngles = new Vector3(0, degree + 6.34f, 0);
                    objInfoButton = Instantiate(infoButton, new Vector3(arrow_position_x, arrow_position_z + 0.6f, arrow_position_y), arrow.transform.rotation) as GameObject;
                    objInfoButton.name = "infoButton";
                    master.receiveDetailPosition = next_dir;

                    //obj.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                    //obj.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
                    Debug.Log("mainbuild:" + next_dir);

                }

            }

        }
    }

    private void Update()
    {
        if (receiveCameraEffectFinshFlag)
        {
            Instantiate();
            receiveCameraEffectFinshFlag = false;
        }
    }
}
