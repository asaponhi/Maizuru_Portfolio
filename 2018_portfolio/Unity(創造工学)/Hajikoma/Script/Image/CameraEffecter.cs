using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class CameraEffecter : MonoBehaviour
{
    //Script
    MasterStreetView master;

    public PostProcessingProfile ppProfile;
    DepthOfFieldModel.Settings depthSettings;
    GameObject gameObject;
    Camera camera;
    //const
    public float regularDepthFocusMax = 7.0f;
    public float regularDepthFocusMin = 0.1f;
    public float regularFieldOfViewMax = 90f;
    public float regularFieldOfViewMin = 50f;

    // Use this for initialization
    void Start()
    {
        gameObject = GameObject.Find("GameObject");
        master = gameObject.GetComponent<MasterStreetView>();
        camera = GetComponent<Camera>();
    }

    private bool locationChageFlag = false;
    public bool receiveLocationChageFlag
    {
        get { return locationChageFlag; }
        set
        {
            locationChageFlag = value;
            //Debug.Log("receiveLocationChageFlag" + receiveLocationChageFlag);
        }
    }
    //ぼかし調整
    //コルーチン１
    private IEnumerator chageDepthOfFieldFadeIn()
    {
        float time = 0;
        //Debug.Log("depthSettings.focusDistance:" + depthSettings.focusDistance);
        while (time < 0.6)
        {
            //Debug.Log("time" + time);
            setDepthOfField(Mathf.Lerp(regularDepthFocusMax, regularDepthFocusMin,time*3));
            setFieldOfView(Mathf.Lerp(regularFieldOfViewMax,regularFieldOfViewMin,time*3));
             
            //sin使う
            time += Time.deltaTime;

            yield return 0;
        }
        master.receiveCameraEffectFinshFlag = true;
        StartCoroutine(chageDepthOfFieldFadeOut());
    }
    //コルーチン２
    private IEnumerator chageDepthOfFieldFadeOut()
    {
        float time = 0;
        //Debug.Log("depthSettings.focusDistance:" + depthSettings.focusDistance);
        while (time < 0.6)
        {
            setDepthOfField(Mathf.Lerp(regularDepthFocusMin, 7.0f, time*3));
            //setFieldOfView(regularFieldOfViewMax);
            setFieldOfView(Mathf.Lerp(regularFieldOfViewMin, regularFieldOfViewMax, time*3));
            time += Time.deltaTime;

            yield return 0;
        }
    }

    void setDepthOfField(float focusDistance)
    {
        //focusDistance = 5.4f;
        depthSettings.focusDistance = focusDistance;
        depthSettings.aperture = 32f;
        depthSettings.focalLength = 110f;
        ppProfile.depthOfField.settings = depthSettings;
        Debug.Log("depthSettings.focusDistance:" + depthSettings.focusDistance);

    }
    void setFieldOfView(float fieldOfView)
    {
        camera.fieldOfView = fieldOfView;
        //Debug.Log("fieldOfView:" + camera.fieldOfView);

    }
    void changeBloomAtRuntime()
    {
        //copy current bloom settings from the profile into a temporary variable
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;

        //change the intensity in the temporary settings variable
        bloomSettings.bloom.intensity = 2;

        //set the bloom settings in the actual profile to the temp settings with the changed value
        ppProfile.bloom.settings = bloomSettings;
    }
    // Update is called once per frame
    void Update()
    {
        if (receiveLocationChageFlag)
        {
            Debug.Log("Startコルーチン1chageDepthOfField");
            StartCoroutine(chageDepthOfFieldFadeIn());
            locationChageFlag = false;
            
        }
    }
}
