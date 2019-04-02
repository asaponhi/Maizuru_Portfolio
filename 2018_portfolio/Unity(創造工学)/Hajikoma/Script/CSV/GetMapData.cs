using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMapData : MonoBehaviour {

    InstantiateArrow instantiate_Arrow;
    //Message
    ActiveMessagePanel messagePanel;

    private double[,] Map_Data = new double[100, 100];
    private string[,] Map_Data_info = new string[100, 100];

    //csv
    string csvName = "map";
    CSVReader csvReader;
    void Awake()
    {
        //GetCompornent
        instantiate_Arrow = GetComponent<InstantiateArrow>();
        messagePanel = GetComponent<ActiveMessagePanel>();
        csvReader = GetComponent<CSVReader>();

        csvReader.CsvRead(csvName);
        for (int i = 0; i < csvReader.csvDatas.Count; i++)
        {
            for (int j = 0; j < csvReader.csvDatas[i].Length; j++)
            {
                //Debug.Log("csvDatas[" + i + "][" + j + "] = " + csvReader.csvDatas[i][j]);
                //i+1はcsvReaderでAddしてるため
                if (9 <= j && j <= 11)
                {
                    Map_Data_info[i + 1, j + 1] = csvReader.csvDatas[i][j];
                    Debug.Log("Map_Data_info[" + (i + 1) + "][" + (j + 1) + "] = " + Map_Data_info[i + 1, j + 1]);
                }
                else
                {
                    Map_Data[i + 1, j + 1] = double.Parse(csvReader.csvDatas[i][j]);
                    Debug.Log("Map_Data[" + (i + 1) + "][" + (j + 1) + "] = " + Map_Data[i + 1, j + 1]);//ここで,,だとエラー→0を格納する
                }
            }
        }
        //messege送信
        instantiate_Arrow.receiveMapData(Map_Data, Map_Data_info);
        messagePanel.receiveMapData(Map_Data, Map_Data_info);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
