using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchRAY : MonoBehaviour
{
    //Script
    MasterStreetView master;

    //commonKey
    private int direction = 0;
    //const
    const int layerMask_arrow = 8;

    // Use this for initialization
    void Start()
    {
        master = GetComponent<MasterStreetView>();
    }

    //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
    void Touch_Down()
    {
        // タッチされているとき
        if (0 < Input.touchCount)
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount; i++)
            {
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if (t.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit, layerMask_arrow))
                    {
                        if (hit.collider.name == "infoButton")
                        {
                            master.receiveInfoButtonFlag = true;
                        }
                        else
                        {
                            direction = int.Parse(hit.collider.gameObject.name);
                            master.receivePosition = direction;
                            master.receiveMessageFlag = true;
                        }
                    }
                }
            }
        }
    }
    void Mouse_Down()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, layerMask_arrow))
            {
                if (hit.collider.name == "infoButton")
                {
                    master.receiveInfoButtonFlag = true;
                }
                else
                {
                    Debug.Log("hit");
                    Debug.Log("hitname" + hit.collider.name);
                    direction = int.Parse(hit.collider.gameObject.name);
                    master.receivePosition = direction;
                    master.receiveMessageFlag = true;
                }
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //direction = 0;
        if (Application.platform == RuntimePlatform.Android) { Touch_Down(); }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Mouse_Down(); //Debug.Log("win");
        }
    }
}