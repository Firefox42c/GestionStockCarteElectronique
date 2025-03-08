using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimuScript : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject panelNoCompoMissing;
    public GameObject missingCompoPanel;
    public GameObject negContent;
    public GameObject negCompoPrefab;
    public GameObject missingsCompoPaneeel;
    public GameObject missingCompoListPanel;
    public GameObject objPrefab;
    public GameObject missingObjContent;

    [Header("Script")]
    public DataBase dataBase;
    public CardDataBase cardData;
    public CarteInit cardToProdData;

    [Header("TMP")]
    public TMP_Dropdown dropdown;
    public TMP_InputField qteInputField;

    [Header("Liste")]
    public List<string> values;
    public List<string> compoNoMissing;
    public List<string> compoMissing;
    public List<string> NegCompoValue;
    public List<int> restCompoQte;

    [Header("Int")]
    public int nbCardToProd;
    public int valueToAdd;
    
    public int totalCompo;
    public int totalCard;
    public int cardAdded;
    public int totalmissingobj;

    [Header("Strings")]
    public string tempName;

    [Header("boolean")]
    public bool isMissing;
    public bool IsNegValue = false;


    private void Update()
    {
        totalCard = cardData.card.Length;

        if(cardAdded < cardData.card.Length)
        {
            cardAdded = 0;
            dropdown.options.Clear();
            for (int i = 0; i < totalCard; i++)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = cardData.card[i].GetComponent<CarteInit>().NomCarte });
                cardAdded += 1;
            }
        } 
        else if(cardAdded > cardData.card.Length)
        {
            cardAdded = 0;
            dropdown.options.Clear();
            for (int i = 0; i < totalCard; i++)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = cardData.card[i].GetComponent<CarteInit>().NomCarte });
                cardAdded += 1;
            }
        }

        dropdown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dropdown.options[dropdown.value].text;
    }
    public void RefreshOption()
    {
        cardAdded = 0;
        dropdown.options.Clear();
        for (int i = 0; i < totalCard; i++)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = cardData.card[i].GetComponent<CarteInit>().NomCarte });
            cardAdded += 1;
        }
    }


    public void Simulation()
    {
        NegCompoValue.Clear();
        IsNegValue = false;
        totalCompo = 0;
        restCompoQte.Clear();
        values.Clear();
        values = new List<string>();
        int valuese;
        if (qteInputField.text != "" && int.TryParse(qteInputField.text, out valuese) && dropdown.options[dropdown.value].text != "Option A" && dropdown.options[dropdown.value].text != "Option B" && dropdown.options[dropdown.value].text != "Option C")
        {
            nbCardToProd = valuese;
            for (int c = 0; c < cardData.card.Length; c++)
            {
                if (cardData.card[c].gameObject.GetComponent<CarteInit>().NomCarte == dropdown.options[dropdown.value].text)
                {
                    cardToProdData = cardData.card[c].GetComponent<CarteInit>();
                }
            }

            for (int d = 0; d < cardToProdData.composants.Count; d++)
            {
                string[] splitDatas = cardToProdData.composants[d].Split(',');
                values.Add(splitDatas[0] + "," + splitDatas[1]);
            }
            totalCompo = values.Count;
            for(int g = 0; g < values.Count; g++)
            {
                calcule(values[g]);
            }
            if (restCompoQte.Count < values.Count)
            {
                ActivePanel();
                Debug.Log("Composant non pr�sent dans le stock");
            }
            else
            {
                for(int s = 0; s < restCompoQte.Count; s++)
                {
                    if(restCompoQte[s] < 0)
                    {
                        IsNegValue = true;
                    }
                }
                if(IsNegValue == true)
                {
                    ActiveNegCompoPanel();
                    NegCompoLister();
                }
                else
                {
                    ActiveInfoPanel();
                }
            }
        }
        else
        {
            Debug.Log("IncorrectValue");
        }
    }

    public void calcule(string s)
    {
        for (int e = 0; e < dataBase.totalElements; e++)
        {
            string[] splitDatas = s.Split(',');
            string[] splitDatass = dataBase.data[e].Split(',');
            if (splitDatas[0] == splitDatass[0])
            {
                restCompoQte.Add(int.Parse(splitDatass[2]) - (int.Parse(splitDatas[1]) * nbCardToProd));
            }

        }
    }

    public void ActivePanel()
    {
        if (true == missingCompoPanel.activeInHierarchy)
        {
            missingCompoPanel.SetActive(false);
        }
        else if (false == missingCompoPanel.activeInHierarchy)
        {
            missingCompoPanel.SetActive(true);
        }
    }

    public void ActiveInfoPanel()
    {
        if (true == panelNoCompoMissing.activeInHierarchy)
        {
            panelNoCompoMissing.SetActive(false);
        }
        else if (false == missingCompoPanel.activeInHierarchy)
        {
            panelNoCompoMissing.SetActive(true);
        }
    }

    public void ActiveNegCompoPanel()
    {
        if (true == missingsCompoPaneeel.activeInHierarchy)
        {
            missingsCompoPaneeel.SetActive(false);
        }
        else if (false == missingsCompoPaneeel.activeInHierarchy)
        {
            missingsCompoPaneeel.SetActive(true);
        }
    }

    public void ActiveList()
    {
        if (true == missingCompoListPanel.activeInHierarchy)
        {
            missingCompoListPanel.SetActive(false);
        }
        else if (false == missingCompoListPanel.activeInHierarchy)
        {
            missingCompoListPanel.SetActive(true);
        }
    }

    public void findMissingCompo()
    {
        compoMissing.Clear();
        compoNoMissing.Clear();
        for(int u = 0; u < dataBase.totalElements; u++)
        {
            string[] splitDatas = values[u].Split(',');
            string[] splitDatass = dataBase.data[u].Split(',');
            if (splitDatas[0] == splitDatass[0])
            {
                compoNoMissing.Add(splitDatas[0]);
            }
        }
        if(compoNoMissing.Count > 0)
        {
            ActivePanel();
            ActiveList();
            foreach (string c in values)
            {
                string[] splitDatas = c.Split(',');
                for (int r = 0; r < compoNoMissing.Count; r++)
                {
                    if (splitDatas[0] == compoNoMissing[r] && isMissing == true)
                    {
                        isMissing = false;
                    }
                }
                if (isMissing == true)
                {
                    compoMissing.Add(splitDatas[0]);
                    tempName = splitDatas[0];
                    Instantiate(objPrefab, new Vector3(0, 0, 0), Quaternion.identity);

                }

                isMissing = true;
            }
        }
        else
        {
            missingCompoPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Il manque tout les composant de la Carte";
            Debug.Log("Il manque tout les composant");
        }

        totalmissingobj = missingObjContent.transform.childCount;

    }

    public void NegCompoLister()
    {
        ClearNegObj();
        for (int j =0;j < values.Count; j++)
        {
            string[] splitDatas = values[j].Split(',');
            if (restCompoQte[j] < 0 && restCompoQte[j] != 0)
            {
                NegCompoValue.Add(splitDatas[0] + "," + restCompoQte[j]);
                Instantiate(negCompoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }

    public void ClearNegObj()
    {
        for(int o = 0; o < negContent.transform.childCount; o++)
        {
            Destroy(negContent.transform.GetChild(o).gameObject);
        }
    }

    public void appliedSimulation()
    {
        for (int y = 0; y < values.Count; y++)
        {
            string[] splitDatas = values[y].Split(',');
            for(int u = 0;u < dataBase.data.Count; u++)
            {

                string[] splitDatass = dataBase.data[u].Split(',');
                if (splitDatas[0] == splitDatass[0])
                {
                    dataBase.data[u] = splitDatas[0] + "," + splitDatass[1] + "," + restCompoQte[y];
                }
            }

        }
    }
}
