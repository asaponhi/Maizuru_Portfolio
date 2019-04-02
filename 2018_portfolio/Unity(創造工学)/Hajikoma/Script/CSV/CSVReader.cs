using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{

    public List<string[]> csvDatas = new List<string[]>();
    private TextAsset csvFile; // CSVファイル


    public void CsvRead(string csvName)
    {
        // csvをロード
        TextAsset csvFile = Resources.Load("csv/" + csvName) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //while (reader.Peek() > -1)
        int i = 0;
        while (i<98)
        {
            // ','ごとに区切って配列へ格納
            string line = reader.ReadLine();
            
            csvDatas.Add(line.Split(','));
            i++;
        }
    }
}