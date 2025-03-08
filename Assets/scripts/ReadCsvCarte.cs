using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEditor;
using System.IO;
using SFB;
using UnityEngine.Networking;

public class ReadCsvCarte : MonoBehaviour
{
    public CarteScript carteScrpt;
    public string textFromFile;
    public string[] separatedData;

    public int totalCompo;

    public List<string> valeurRead;

    public string csvPath;
    public FileBrowser fileBrowser;

    public float tpsPause = 2f;
#if UNITY_WEBGL && !UNITY_EDITOR
    // WebGL
    [DllImport("__Internal")]
    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

    public void OnClickOpen(){
        UploadFile(gameObject.name, "OnFileUpload", ".obj", false);
    }

    //Called from browser
    public void OnFileUpload(string url){
        StartCoroutine(OutputRoutineOpen(url));
    }
#else
    public void Awake()
    {
        valeurRead = new List<string>();
    }
    public void OnclickOpen()
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "csv", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutineOpen(new System.Uri(paths[0]).AbsoluteUri));
        }
    }
    public void SepareData()
    {
        if (textFromFile != "")
        {
            separatedData = textFromFile.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        }
    }

    public void ReadCSVFile()
    {
        if(textFromFile != "")
        {
            carteScrpt.compoToAdd.Clear();
            foreach (string s in separatedData)
            {
                if (s != "")
                {
                    string[] splitData = s.Split(',');

                    carteScrpt.compoToAdd.Add(splitData[0] + "," + splitData[1]);
                }
            }
            string[] splitDatas = csvPath.Split('/', '.');
            carteScrpt.carteName = splitDatas[splitDatas.Length - 2];
            carteScrpt.addCard();
        }

       
    }
#endif

    private IEnumerator OutputRoutineOpen(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else
        {
            csvPath = url;
            textFromFile = www.downloadHandler.text;
            SepareData();
            ReadCSVFile();
        }
    }
}
