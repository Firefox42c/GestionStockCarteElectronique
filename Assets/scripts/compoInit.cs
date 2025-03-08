using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class compoInit : MonoBehaviour
{

    [Header("compoData")]
    public gestionStockCompo data;
    public string codeArticle;
    public string descriptif;
    public int quantité;
    public string qte;

    [Header("compoObj")]
    public TextMeshProUGUI texteCode;
    public GameObject txtqteObj;
    public TextMeshProUGUI texteqte;
    public TextMeshProUGUI texteDescr;
    public Transform content;

    [Header("editingQte")]
    public GameObject qteEditMenu;
    public GameObject qteEditBtn;
    public TMP_InputField qteInputField;
    public string qteEditValue;

    [Header("editingData")]
    public GameObject dataEditMenu;
    public GameObject dataEditBtn;
    public TMP_InputField descrInputField;
    public TMP_InputField codeArtInputField;
    public string descrEditValue;
    public string codeArtEditValue;

    public DataBase dataBase;

    public int compoID;

    //Init Compo
    private void Awake()
    {
        dataBase = GameObject.FindGameObjectWithTag("Database").GetComponent<DataBase>();
        content = GameObject.FindGameObjectWithTag("Content").GetComponent<Transform>();
        data = GameObject.FindGameObjectWithTag("StockScr").GetComponent<gestionStockCompo>();
    }
    void Start()
    { 

        txtqteObj.tag = "Player";
        this.transform.SetParent(content.transform, false);
        codeArticle = data.nomComposant;
        descriptif = data.descriptif;
        quantité = data.qte;
        compoID = dataBase.instatiated;
    }


    //Refresh Compo values
    void Update()
    {
        string[] splitData = dataBase.data[compoID].Split(',');
        codeArticle = splitData[0];
        descriptif = splitData[1];
        qte = splitData[2];
        quantité = int.Parse(qte);
        texteCode.text = (codeArticle + ",");
        texteDescr.text = (descriptif + ",");
        texteqte.text = ("" + quantité);
    }


    //Editing Qte
    public void ActiveQteEditMenue()
    {
        if (true == qteEditMenu.activeInHierarchy)
        {
            qteEditMenu.SetActive(false);
            qteEditBtn.SetActive(true);
        }
        else if (false == qteEditMenu.activeInHierarchy)
        {
            qteEditMenu.SetActive(true);
            qteEditBtn.SetActive(false);
        }

    }

    //Editing OtherValues

    public void ActiveDataEditMenue()
    {
        if (true == dataEditMenu.activeInHierarchy)
        {
            dataEditMenu.SetActive(false);
            dataEditBtn.SetActive(true);
        }
        else if (false == dataEditMenu.activeInHierarchy)
        {
            dataEditMenu.SetActive(true);
            dataEditBtn.SetActive(false);
        }
    }

    public void setDataEditValue()
    {
        qteEditValue = qteInputField.GetComponent<TMP_InputField>().text;
        descrEditValue = descrInputField.GetComponent<TMP_InputField>().text;
        codeArtEditValue = codeArtInputField.GetComponent<TMP_InputField>().text;
    }

    public void applieDataEditValue()
    {
        if (descrEditValue != "" && codeArtEditValue != "" && qteEditValue != "")
        {
            dataBase.data[compoID] = (codeArtEditValue + "," + descrEditValue + "," + int.Parse(qteEditValue));
        }
        if (descrEditValue != "" && codeArtEditValue != "" && qteEditValue == "")
        {
            dataBase.data[compoID] = (codeArtEditValue + "," + descrEditValue + "," + quantité);
        }
        if (descrEditValue != "" && codeArtEditValue == "" && qteEditValue == "")
        {
            dataBase.data[compoID] = (codeArticle + "," + descrEditValue + "," + quantité);
        }
        if (descrEditValue == "" && codeArtEditValue == "" && qteEditValue != "")
        {
            dataBase.data[compoID] = (codeArticle + "," + descriptif + "," + int.Parse(qteEditValue));
        }
        if (descrEditValue == "" && codeArtEditValue != "" && qteEditValue == "")
        {
            dataBase.data[compoID] = (codeArtEditValue + "," + descriptif + "," + quantité);
        }
        codeArtInputField.text = "";
        descrInputField.text = "";
        qteInputField.text = "";
    }

}
