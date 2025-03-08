using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarteScript : MonoBehaviour
{
    [Header("Input")]
    public GameObject carteNameInput;

    [Header("Values")]
    public string carteName;

    [Header("getcompo")]
    public GameObject[] compoObj;
    public int totalElements;
    public GameObject compoContent;

    [Header("AdingValue")]
    public string codeAddArt;
    public string qteAddArt;

    public GameObject panelAddCarte;
    public GameObject contentAddedCompo;
    public GameObject compoAdded;
    public GameObject cartePrefab;

    public List<string> compoToAdd;
    void Start()
    {

    }

    void Update()
    {
        totalElements = compoContent.transform.childCount;


        compoObj = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++)
        {
            compoObj[i] = compoContent.transform.GetChild(i).gameObject;
        }

        

    }

    public void ReadStringCarteName()
    {
        carteName = carteNameInput.GetComponent<TMP_InputField>().text;
        Debug.Log(carteName);
    }

    public void addIt()
    {

        Instantiate(compoAdded, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void addCard()
    {
        Instantiate(cartePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }


    public void activeAddCartePanel()
    {
        if (true == panelAddCarte.activeInHierarchy)
        {
            panelAddCarte.SetActive(false);
        }
        else if (false == panelAddCarte.activeInHierarchy)
        {
            panelAddCarte.SetActive(true);
        }
    }

    public void addCarte()
    {
        compoToAdd.Clear();
        ReadStringCarteName();
        if(contentAddedCompo.transform.childCount != 0)
        {
            if (compoToAdd.Count > 0)
            {
                for (int s = 0; s < compoToAdd.Count; s++)
                {

                }
            }
            for (int c = 0; c < contentAddedCompo.transform.childCount; c++)
            {
                compoToAdd.Add(contentAddedCompo.transform.GetChild(c).GetComponent<CompoAddedInit>().codeArt + "," + contentAddedCompo.transform.GetChild(c).GetComponent<CompoAddedInit>().qte);
            }
            for (int s = 0; s < contentAddedCompo.transform.childCount; s++)
            {
                Destroy(contentAddedCompo.transform.GetChild(s).gameObject);
            }
            addCard();
        }
    }
}
