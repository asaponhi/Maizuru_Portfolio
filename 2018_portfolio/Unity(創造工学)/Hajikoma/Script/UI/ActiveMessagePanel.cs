using UnityEngine;
using System.Collections;
public class ActiveMessagePanel : MonoBehaviour
{
    //Script
    MasterStreetView master;
    private double[,] Map_Data = new double[100, 100];
    private string[,] Map_Data_info = new string[100, 100];


    //　MessageUIに設定されているMessageスクリプトを設定
    [SerializeField]
    private Message messageScript;
    //　表示させるメッセージ
    private string message;

    //const
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
        //Debug.Log("*************Map_Data_info[27,9]" + Map_Data_info[27, 9]);

    }
    private int detailPositinon = 0;
    public int receivePosition
    {
        get { return detailPositinon; }
        set
        {
            detailPositinon = value;
            Debug.Log("ActiveMessagePanel:DetailPositinon" + detailPositinon);
        }
    }
    private bool infoButtonFlag = false;
    public bool receiveInfoButtonFlag
    {
        get { return infoButtonFlag; }
        set
        {
            infoButtonFlag = value;
            //Debug.Log("master" + finishMessageFlag);
        }
    }

    private bool finishMessageFlag =true;
    public bool receiveMessageFlag
    {
        get { return finishMessageFlag; }
        set
        {
            finishMessageFlag = value;
            //Debug.Log("master" + finishMessageFlag);
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire2"))
        //if(Map_Data_info[You_are_here, detail_info] != "0")
        //メッセージ表示
        //if(Map_Data_info[receivePosition, detail_info] != "0" &&finishMessageFlag ==true)//矢印を触ったらtrueにするやな
        if (receiveInfoButtonFlag && finishMessageFlag == true)//矢印を触ったらtrue
        {
            messageScript.setMessagePanel(Map_Data_info[receivePosition, detail_info], Map_Data_info[receivePosition, build_picture_name]);
            infoButtonFlag = false;//クリックしたら、falseにする
            receiveMessageFlag = false;
            Debug.Log("AMP");
        }
    }
}
