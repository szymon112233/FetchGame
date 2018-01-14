using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WWWManager : MonoBehaviour {

    public string url = "http://127.0.0.1:8000/get/data";

    public Text outputText = null;
    public Text itemListText = null;


    public EnemyListSerialized data = null;

    public void SetNewURL(string newUrl)
    {
        url = newUrl;
    }
	
	IEnumerator GetSite()
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.text);
        outputText.text = www.text;
        DeseralizeJson(www.text);
        www.Dispose();

    }

    public void Connect()
    {
        Debug.Log("Connect to: "+ url);
        StartCoroutine(GetSite());
    }


    private void DeseralizeJson(string json)
    {
        string newJson = json.Replace("[", "{ \"enemies\":[");
        newJson = newJson.Replace("]","]}");
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


}
