using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterStreetView : MonoBehaviour
{
    //Script
    CameraEffecter cameraEffecter;
    Display360Picture display360;
    InstantiateArrow instantiateArrow;
    ActiveMessagePanel messagePanel;
    TouchCameraController touchCamera;
    MouseCameraController mouseCamera;

    GameObject gameObject;

    // Use this for initialization
    void Start()
    {
        display360 = GetComponent<Display360Picture>();
        instantiateArrow = GetComponent<InstantiateArrow>();
        messagePanel = GetComponent<ActiveMessagePanel>();

        gameObject = GameObject.Find("Camera");
        touchCamera = gameObject.GetComponent<TouchCameraController>();
        mouseCamera = gameObject.GetComponent<MouseCameraController>();
        cameraEffecter = gameObject.GetComponent<CameraEffecter>();

        if (Application.platform == RuntimePlatform.Android)
        {
            mouseCamera.enabled = false;//AndroidならMouseスクリプトをOFFにする
        }
        //demoは初めのポジションを送る
        receivePosition = StaticGameDatabase.getViewPointNumber();
        //receiveCameraEffectFinshFlag = true;
    }
    //ピグマンから現在地うけとる
    private int You_are_here;
    public int receivePosition
    {
        get { return You_are_here; }
        set
        {
            You_are_here = value;
            Debug.Log("master" + You_are_here);
            Debug.Log("master:receiveLocationChageFlagTrue");
            //情報が変わったら現在地情報を送る
            display360.receiveDirection = You_are_here;
            instantiateArrow.receivePosition = You_are_here;
            cameraEffecter.receiveLocationChageFlag = true;
            //messagePanel.receivePosition = You_are_here;
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
            display360.receiveCameraEffectFinshFlag = cameraEffectFinshFlag;
            instantiateArrow.receiveCameraEffectFinshFlag = cameraEffectFinshFlag;
            Debug.Log("EffectFinish");
        }
    }
    //バックキーを押されたら、ストリートビューモード終了
    private bool backKeyFlag=false;
    public bool receiveBackKeyFlag
    {
        get { return backKeyFlag; }
        set
        {
            backKeyFlag = value;
            Debug.Log("finish");
            //scene切り替えプログラムにフラグ渡す********切り替えたあとに、backKeyFlagをfalseにする

            //messagePanel.receiveMessageFlag = finishMessageFlag;
        }
    }
    
    private bool finishMessageFlag=false;
    public bool receiveMessageFlag
    {
        get { return finishMessageFlag; }
        set
        {
            finishMessageFlag = value;//trueしかよばれない
            //Debug.Log("master" + finishMessageFlag);
            messagePanel.receiveMessageFlag = finishMessageFlag;
        }
    }

    private bool scriptEnabledFlag;
    public bool receiveScriptEnabledFlag
    {

        get { return scriptEnabledFlag; }
        set
        {
            scriptEnabledFlag = value;//ActiveMessagePanelで始まりでfalse,Messageで終了でtrue
            touchCamera.enabled = scriptEnabledFlag;
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                //Debug.Log("くりっくしおっわたら、MOUSEONに");
                mouseCamera.enabled = scriptEnabledFlag;
            }
        }
    }
    //詳細情報表示用
    //INSTANTで場所記録→アクティブメッセージに情報送る
    private int DetailPositinon;
    public int receiveDetailPosition
    {
        get { return DetailPositinon; }
        set
        {
            DetailPositinon = value;
            Debug.Log("master" + DetailPositinon);
            //情報が変わったら現在地情報を送る
            messagePanel.receivePosition = DetailPositinon;
        }
    }
    private bool infoButtonFlag;
    public bool receiveInfoButtonFlag
    {
        get { return infoButtonFlag; }
        set
        {
            infoButtonFlag = value;//ActiveMessagePanelで始まりでfalse,Messageで終了でtrue
            messagePanel.receiveInfoButtonFlag = infoButtonFlag;
            Debug.Log("MS:infoFoag" + infoButtonFlag);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (receiveBackKeyFlag)
        {
            SceneManager.LoadScene("Main");
        }

    }
}
