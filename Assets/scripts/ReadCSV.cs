using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEditor;
using System.IO;
using SFB;
using UnityEngine.Networking;

public class ReadCSV : MonoBehaviour
{
    public gestionStockCompo stockScrpt;
    public string qte;

    public string textFromFile;
    public string[] separatedData;

    public bool ecraser;
    public bool isInit = false;

    public int compoInited = 0;
    public int totalCompo;

    public List<string> valeurRead;

    public string csvPath = "";
    public FileBrowser fileBrowser;

    public float tpsPause = 2f;

    public int compteurVerified = 0;
    public bool replaced;
    public DataBase database;
    public GameObject content;

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
        if (File.Exists("compo.csv")){
            textFromFile = File.ReadAllText("compo.csv");
            SepareData();
            ReadCSVFile();
        }
        else
        {
            Debug.Log("compo.CSV Didn't exist");
        }

    }

    public void ecraserOn()
    {
        if (ecraser == true)
        {
            ecraser = false;
        }
        else
        {
            ecraser = true;
        }
    }

    public void OnclickOpen()
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "csv", false);
        if(paths.Length > 0)
        {
            StartCoroutine(OutputRoutineOpen(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    public void ReadCSVFile()
    {
        if(textFromFile != "")
        {
            foreach (string s in separatedData)
            {
                if (s != "")
                {
                    string[] splitData = s.Split(',');
                    if (ecraser == true)
                    {
                        compteurVerified = 0;
                        for (int i = 0; i < content.transform.childCount; i++)
                        {
                            if (content.transform.GetChild(i).GetComponent<compoInit>().codeArticle == splitData[0])
                            {
                                content.transform.GetChild(i).GetComponent<compoInit>().codeArtEditValue = splitData[0];
                                content.transform.GetChild(i).GetComponent<compoInit>().descrEditValue = splitData[1];
                                content.transform.GetChild(i).GetComponent<compoInit>().qteEditValue = splitData[2];

                            }
                            else
                            {
                                compteurVerified += 1;
                            }
                            if (compteurVerified == content.transform.childCount)
                            {
                                ecraser = false;
                            }
                        }
                    }
                    else
                    {
                        replaced = true;
                    }
                    if (ecraser == false && replaced != true)
                    {
                        valeurRead.Add(splitData[0] + "," + splitData[1] + "," + splitData[2]);
                        ecraser = true;
                    }
                    if (replaced == true)
                    {
                        valeurRead.Add(splitData[0] + "," + splitData[1] + "," + splitData[2]);
                    }
                }
                isInit = true;
                replaced = false;
                compteurVerified = 0;
                for (int f = 0; f < content.transform.childCount; f++)
                {
                    content.transform.GetChild(f).GetComponent<compoInit>().applieDataEditValue();
                }
            }
        }
        else
        {
            Debug.Log("fichier Vide");
        }
            
            
    }

    public void SepareData()
    {
        if(textFromFile != "")
        {
            separatedData = textFromFile.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        }
    }

    private void Update()
    {
        totalCompo = valeurRead.Count;
        if(compoInited < totalCompo & isInit == true)
        {
            string[] splitDatas = valeurRead[compoInited].Split(',');

            stockScrpt.codeArt = splitDatas[0];
            stockScrpt.descriptif = splitDatas[1];
            stockScrpt.qte = int.Parse(splitDatas[2]);
            stockScrpt.addComposantToStock();
            isInit = false;
            compoInited += 1;

        }


    }
#endif

    private IEnumerator OutputRoutineOpen(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else
        {
            csvPath = url;
            textFromFile = www.downloadHandler.text;
            SepareData();
        }
    }

}
