using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUI : MonoBehaviour {
    
    MasterStreetView master;
    private void Start()
    {
        master = GetComponent<MasterStreetView>();    
    }
    // Use this for initialization
    void Update()
    {
       // if (Application.platform == RuntimePlatform.Android)
        {
            // エスケープキー取得
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //ダイアログ開く
                dialogOpen();
            }
        }
    }


    void dialogOpen()
    {
        //ラベルをセット
        DialogManager.Instance.SetLabel("Yes", "No", "Close");

        // YES NO ダイアログ
        DialogManager.Instance.ShowSelectDialog(
            "校内viewを終了しますか？",
            (bool result) => {
                Debug.Log("result:" + result.ToString());
                //Yesを押したら終了
                if (result) master.receiveBackKeyFlag = true;
                    //Application.Quit();
            }
        );
    }
}
