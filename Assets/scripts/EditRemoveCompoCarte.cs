using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditRemoveCompoCarte : MonoBehaviour
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


    private void Awake()
    {
        compoData = GameObject.FindGameObjectWithTag("Database").GetComponent<DataBase>();
    }

    public void Update()
    {
        totalCard = carteInit.composants.Count;

        if (compoAdded < compoData.data.Count)
        {
            compoAdded = 0;
            dropdown.options.Clear();
            for (int i = 0; i < totalCard; i++)
            {
                string[] splitData = carteInit.composants[i].Split(',');
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = splitData[0] + "," + splitData[1]});
                compoAdded += 1;
            }
        }
        else if (compoAdded > carteInit.composants.Count)
        {
            compoAdded = 0;
            dropdown.options.Clear();
            for (int i = 0; i < carteInit.composants.Count; i++)
            {
                string[] splitData = carteInit.composants[i].Split(',');
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = splitData[0] + "," + splitData[1] });
                compoAdded += 1;
            }
        }
          
        dropdown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dropdown.options[dropdown.value].text;
    }

    public void RefreshOption()
    {
        compoAdded = 0;
        dropdown.options.Clear();
        for (int i = 0; i < carteInit.composants.Count; i++)
        {
            string[] splitData = carteInit.composants[i].Split(',');
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = splitData[0] + "," + splitData[1] });
            compoAdded += 1;
        }
    }
    
    public void RemoveCompo()
    {
       if(dropdown.options[dropdown.value].text != "" && inputFieldQte.text != "")
        {
            for(int i = 0; i < carteInit.composants.Count; i++)
            {
                string[] splitDatas = dropdown.options[dropdown.value].text.Split(',');
                string[] splitData = carteInit.composants[i].Split(',');
                if (splitData[0] == splitDatas[0] && int.Parse(inputFieldQte.text) >= int.Parse(splitData[1]))
                {
                    carteInit.composants.RemoveAt(i);
                }
                else if (splitData[0] == splitDatas[0] && int.Parse(inputFieldQte.text) < int.Parse(splitData[1]))
                {
                    carteInit.composants[i] = splitDatas[0] + "," + (int.Parse(splitData[1]) - int.Parse(inputFieldQte.text));
                }
            }
            carteInit.RefreshCompo();
        }
        
    }
}
