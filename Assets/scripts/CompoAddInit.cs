using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompoAddInit : MonoBehaviour
{
    public string codeArticle;
    public int numArt;
    public TextMeshProUGUI codeArtText;
    public GameObject Qteinput;
    public Transform contente;
    public DataBase database;
    public CarteScript carteScript;
    public RestScript resetScr;

    public GameObject stockcompoContent;

    public int compoId;

    public ReadCSV csvReader;

    private void Awake()
    {
        resetScr = GameObject.FindGameObjectWithTag("StockScr").GetComponent<RestScript>();
        stockcompoContent = GameObject.FindGameObjectWithTag("Content");
        csvReader = GameObject.FindGameObjectWithTag("StockScr").GetComponent<ReadCSV>();
        contente = GameObject.FindGameObjectWithTag("Cart+Content").GetComponent<Transform>();
        carteScript = GameObject.FindGameObjectWithTag("CarteScript").GetComponent<CarteScript>();
        database = GameObject.FindGameObjectWithTag("Database").GetComponent<DataBase>();


    }
  
    void Start()
    {
        this.transform.SetParent(contente.transform, false);
        if(contente.childCount > 0)
        {
            string[] splitData = database.data[contente.childCount - 1].Split(',');
            codeArticle = splitData[0];
        }
        else
        {
            string[] splitData = database.data[0].Split(',');
            codeArticle = splitData[0];
        }
        numArt = contente.childCount - 1;
        csvReader.isInit = true;
        compoId = database.data.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(resetScr.reseting == false)
        {
            string[] splitData = database.data[numArt].Split(',');
            codeArticle = splitData[0];
        }
        codeArtText.text = codeArticle;
    }

    public void addcompoToCard()
    {
        carteScript.codeAddArt = codeArticle;
        carteScript.qteAddArt = Qteinput.GetComponent<TMP_InputField>().text;
        if(carteScript.qteAddArt != "")
        {
            carteScript.addIt();
        }
    }
}
