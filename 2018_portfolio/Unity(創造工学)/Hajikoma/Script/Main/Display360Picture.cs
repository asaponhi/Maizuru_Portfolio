using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display360Picture : MonoBehaviour
{
    public GameObject sphere;
    //script

    //textureVER
    Texture[] textures = new Texture[100];
    Texture texture;
    Material material;

    float count = 0;
    //commonKey

    // Use this for initialization
    void Awake()
    {
        material = sphere.GetComponent<Renderer>().material;
        for (int i = 1; i <= 98; i++)
        {
            textures[i] = Resources.Load<Texture>("Image/Display360Picture/" + i);
        }
    }
    private int direction;
    public int receiveDirection
    {
        get { return direction; }
        set
        {
            direction = value;
            //Debug.Log("display" + direction);
            //ChagePicture();
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

    // Update is called once per frame
    void Update()
    {
        if (receiveCameraEffectFinshFlag)
        {
            ChagePicture();
            receiveCameraEffectFinshFlag = false;
        }
    }
    void ChagePicture()
    {
        //Debug.Log("change" + direction);
        material.SetTexture("_MainTex", textures[receiveDirection]);
    }

}