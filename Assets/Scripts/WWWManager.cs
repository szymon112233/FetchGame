using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WWWManager : MonoBehaviour {

    public static UnityEvent OnDataLoaded = new UnityEvent();

    public string url = "http://127.0.0.1:8000/get/data";
    private string urlHidden = "http://127.0.0.1:8000/get/data";

    public Text outputText = null;
    public Text itemListText = null;


    public EnemyListSerialized data = null;

    public void SetNewURL(string newUrl)
    {
        url = newUrl;
    }
	
	IEnumerator GetSite(string siteURL)
    {
        WWW www = new WWW(siteURL);
        yield return www;
        Debug.Log(www.text);
        outputText.text = www.text;
        DeseralizeJson(www.text);
        www.Dispose();
        GenerateEnemies();
        OnDataLoaded.Invoke();
    }

    public void Connect()
    {
        Debug.Log("Connect to: "+ url);
        StartCoroutine(GetSite(url));
    }


    private void DeseralizeJson(string json)
    {
        string newJson = json.Replace("[", "{ \"enemies\":[");
        newJson = newJson.Replace("]","]}");
        //SaveCachedJson(json);
        Debug.Log(newJson);
        data = JsonUtility.FromJson<EnemyListSerialized>(newJson);
        Debug.Log(data.enemies.Count);
        string text = "Deseralized Items:\n";
        foreach (EnemySerialized tes in data.enemies)
        {
            text += ("- " + tes.name + ".\n");
        }
        itemListText.text = text;
    }

    static void SaveCachedJson(string json)
    {
        string path = "Assets/Resources/Enemies.json";

        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(json);
        writer.Close();

    }

    public void GenerateEnemies()
    {
        foreach (EnemySerialized enemy in data.enemies)
        {
            EnemyManager.instance.CreateFromData(enemy);
        }
    }

    public void LoadDataFromServer()
    {
        StartCoroutine(GetSite(urlHidden));
    }


}
