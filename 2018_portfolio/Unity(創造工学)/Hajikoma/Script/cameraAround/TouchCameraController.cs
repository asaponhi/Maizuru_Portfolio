using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Linq;

public class TouchCameraController : MonoBehaviour
{
    Camera camera;
    // 回転速度
    public float rotSpeed = 0.1f;
    public float pinchZoomSpeed = 0.1f;
    //GameObject camera;
    public float perspectiveZoomSpeed = 0.5f;        // 透視投影モードでの有効視野の変化の速さ
    public float a = -90f;
    public float b = 40f;
    public float c = 25f;
    public float d = 60f;

    float rotX = 0.0f, rotY = 0.0f;
    private void Start()
    {
        camera = GetComponent<Camera>();
        camera.fieldOfView = d;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (EventSystem.current != null)
            {
                // UIを最初に触った場合はタッチでの操作をさせない
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    return;
                }
            }

            // タッチ数で処理を変える
            if (Input.touchCount == 1)
            {
                // タッチ数が1つの場合の処理

                // タッチを取得
                Touch touch = Input.GetTouch(0);

                rotX += touch.deltaPosition.y * rotSpeed;
                rotY -= touch.deltaPosition.x * rotSpeed;

                rotX = Mathf.Clamp(rotX, a, b); //最大値と最小値の間で納める
                while (rotY < 0.0f) { rotY += 360.0f; }
                while (rotY > 360.0f) { rotY -= 360.0f; }

                this.transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);




                //// 画面を横にスワイプしたら親オブジェクトをY軸で回転させる
                //this.transform.Rotate(0, touch.deltaPosition.x * rotateSpeed, 0);

                //// 画面を縦にスワイプしたらカメラをY軸で移動させる
                //this.transform.position += new Vector3(0, -touch.deltaPosition.y * moveSpeed / 10, 0);

                //this.transform.eulerAngles = new Vector3(touch.deltaPosition.y * rotateSpeed, touch.deltaPosition.x * rotateSpeed, 0.0f);
            }
            // 端末に 2 つのタッチがあるならば...　
            if (Input.touchCount == 2)
            {
                // 両方のタッチを格納します
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // 各タッチの前フレームでの位置をもとめます
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // 各フレームのタッチ間のベクター (距離) の大きさをもとめます
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // 各フレーム間の距離の差をもとめます
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                
                    // そうでない場合は、タッチ間の距離の変化に基づいて有効視野を変更します
                    camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                    // 有効視野(zoom度)を 0 から 180 の間に固定するように気を付けてください
                    camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, c,d);//0.1f, 179.9f
                
            }

            
        }
    }
}


//else if (Input.touchCount == 2)
//{
//    // タッチ数が2つの場合の処理

//    // タッチを取得
//    Touch touchZero = Input.GetTouch(0);
//    Touch touchOne = Input.GetTouch(1);

//    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
//    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

//    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
//    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

//    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

//    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

//    Vector3 ido = deltaMagnitudeDiff * cameraForward * pinchZoomSpeed;
//    // ピンチ操作時はカメラの距離を変える
//    //this.transform.localPosition += new Vector3(0, 0, deltaMagnitudeDiff * moveSpeed / 1000);

//    //this.transform.position = new Vector3(transform.position.x + ido.x, 0, transform.position.z + ido.z);
//    this.transform.localPosition += new Vector3(ido.x, 0, ido.z);
//}