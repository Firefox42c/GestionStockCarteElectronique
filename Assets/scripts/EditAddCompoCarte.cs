using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditAddCompoCarte : MonoBehaviour
{
    [Header("TMP")]
    public TMP_Dropdown dropdown;
    public TMP_InputField inputFieldQte;

    [Header("Script")]
    public CarteInit carteInit;
    public DataBase compoData;

    [Header("Values")]
    public int totalCard;
    public int compoAdded;
    public bool isAlreadyPresent;
    public int compoToAddOrder;
    private void Awake()
    {
        compoData = GameObject.FindGameObjectWithTag("Database").GetComponent<DataBase>();
    }

    public void Update()
    {
        totalCard = compoData.data.Count;

        if (compoAdded < compoData.data.Count)
        {
            compoAdded = 0;
            dropdown.options.Clear();
            for (int i = 0; i < totalCard; i++)
            {
                string[] splitData = compoData.data[i].Split(',');
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = splitData[0] });
                compoAdded += 1;
            }
        }
        else if (compoAdded > compoData.data.Count)
        {
            compoAdded = 0;
            dropdown.options.Clear();
            for (int i = 0; i < totalCard; i++)
            {
                string[] splitData = compoData.data[i].Split(',');
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = splitData[0] });
                compoAdded += 1;
            }
        }

        dropdown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dropdown.options[dropdown.value].text;
    }

    public void AddCompo()
    {
        isAlreadyPresent = false;
        if (dropdown.options[dropdown.value].text != "" && inputFieldQte.text != "")
        {
            for(int i = 0; i < carteInit.composants.Count; i ++)
            {
                string[] splitData = carteInit.composants[i].Split(',');
                if (splitData[0] == dropdown.options[dropdown.value].text)
                {
                    isAlreadyPresent = true;
                    AddIt(i);
                }
            }
            if(isAlreadyPresent == false)
            {
                AddIt(0);
            } 
        }
        carteInit.RefreshCompo();
    }

    void AddIt(int e)
    {
        if(isAlreadyPresent == true)
        {
            string[] splitData = carteInit.composants[e].Split(',');
            carteInit.composants[e] = splitData[0] + "," + (int.Parse(splitData[1]) + int.Parse(inputFieldQte.text));
        }
        if(isAlreadyPresent == false)
        {
            for(int d = 0; d < compoData.data.Count; d++)
            {
                string[] splitData = compoData.data[d].Split(',');
                if (dropdown.options[dropdown.value].text == splitData[0])
                {
                    compoToAddOrder = d;
                }
            }
            if(compoToAddOrder > carteInit.composants.Count)
            {
                carteInit.composants.Add(dropdown.options[dropdown.value].text + "," + inputFieldQte.text);
            }
            else
            {
                carteInit.composants.Insert(compoToAddOrder, dropdown.options[dropdown.value].text + "," + inputFieldQte.text);
            }
            
        }

    }
}
