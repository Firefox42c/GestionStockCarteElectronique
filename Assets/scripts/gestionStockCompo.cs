using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gestionStockCompo : MonoBehaviour
{
    public GameObject pageAdd;
    public GameObject card;

    [Header("ErrorPopUp")]
    public GameObject missingValuesPanel;

    [Header("TextInput")]
    public GameObject codeArtInput;
    public GameObject descriptifInput;
    public GameObject qteInput;

    [Header("Value")]
    public string codeArt;
    public string descriptif;
    public int qte;

    
    public GameObject parent;
    public GameObject textPrefab;
    public GameObject CarteCompoAddPrefab;
    public string nomComposant;

    [Header("Search Bar")]

    public TMP_InputField SearchBar;
    public GameObject content;


    //GetValues from inputFields
    public void ReadStringCodeArt()
    {
        codeArt = codeArtInput.GetComponent<TMP_InputField>().text;
        Debug.Log(codeArt);
    }
    public void ReadStringDescriptif()
    {
        descriptif = descriptifInput.GetComponent<TMP_InputField>().text;
        Debug.Log(descriptif);
    }
    public void Readintqte()
    {
        int value;
        if(int.TryParse(qteInput.GetComponent<TMP_InputField>().text, out value))
        {
            qte = value;
            Debug.Log(qte);
        }
        else
        {
            qteInput.GetComponent<TMP_InputField>().text = "";
            Debug.Log("valeurs Invalide");
        }

        
    }


    //Create new Composant
    public void addComposantToStock()
    {
        if(qte != null && descriptif != ""  && codeArt != "")
        {
            nomComposant = codeArt;
            Instantiate(textPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            descriptifInput.GetComponent<TMP_InputField>().text = "";
            qteInput.GetComponent<TMP_InputField>().text = "";
            codeArt = codeArtInput.GetComponent<TMP_InputField>().text = "";
        }
        else
        {
            Debug.Log("Missing Values");
            missingValuesPanel.SetActive(true);
        }

    }


    //active la page d'ajout de composant
    public void ActivePageAdd()
    {
        if (true == pageAdd.activeInHierarchy)
        {
            pageAdd.SetActive(false);
        }
        else if (false == pageAdd.activeInHierarchy)
        {
            pageAdd.SetActive(true);
        }
    }

    public  void ActivePopUp()
    {
        if (true == missingValuesPanel.activeInHierarchy)
        {
            missingValuesPanel.SetActive(false);
        }
        else if (false == pageAdd.activeInHierarchy)
        {
            missingValuesPanel.SetActive(true);
        }
    }

    public void SearchCompo()
    {

    }

}
