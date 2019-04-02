using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    Camera camera;
    // 回転速度
    public float rotSpeed = 0.1f;
    public float pinchZoomSpeed = 0.1f;
    //GameObject camera;
    public float perspectiveZoomSpeed = 0.5f;        // 透視投影モードでの有効視野の変化の速さ
    public float a = -90f;
    public float b = 40f;
    // マウス座標を格納する変数
    private Vector2 lastMousePosition;

    float rotX = 0.0f, rotY = 0.0f;
    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        // 左クリックした時
        if (Input.GetMouseButtonDown(0))
        {
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
        }
        // 左ドラッグしている間
        else if (Input.GetMouseButton(0))
        {
            rotX += (Input.mousePosition.y - lastMousePosition.y) * rotSpeed;
            rotY -= (Input.mousePosition.x - lastMousePosition.x) * rotSpeed;

            rotX = Mathf.Clamp(rotX, a, b); //最大値と最小値の間で納める
            while (rotY < 0.0f) { rotY += 360.0f; }
            while (rotY > 360.0f) { rotY -= 360.0f; }

            this.transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);
           // lastMousePosition = Input.mousePosition;
        }

    }
}

