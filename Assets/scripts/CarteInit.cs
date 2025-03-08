using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarteInit : MonoBehaviour
{
    [Header("Obj")]
    public GameObject compoAdded;
    public CarteScript carteScripte;
    public GameObject content;
    public TextMeshProUGUI Text;
    public TMP_InputField EditInputField;
    public TMP_Dropdown dropdown;
    public GameObject editPanel;
    public GameObject editBtn;

    public SimuScript simucript;

    [Header("Values")]
    public List<string> composants;
    public int composantTotal;
    public string NomCarte;


    private void Awake()
    {
        simucript = GameObject.FindGameObjectWithTag("simuScript").GetComponent<SimuScript>();
        content = GameObject.FindGameObjectWithTag("CarteContent");
        carteScripte = GameObject.FindGameObjectWithTag("CarteScript").GetComponent<CarteScript>();
    }


    void Start()
    {
        this.transform.SetParent(content.transform, false);
        for (int i = 0; i < carteScripte.compoToAdd.Count; i++)
        {
            composants.Add(carteScripte.compoToAdd[i]);
        }
        NomCarte = carteScripte.carteName;
        composantTotal = 0;
        dropdown.ClearOptions();
        for (int c = 0; c < composants.Count; c++)
        {
            string[] splitDatas = composants[c].Split(',');
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = "compo" +" "+ (c + 1) + " " + splitDatas[0] + "     " + splitDatas[1]});
        }
    }


    void Update()
    {
        Text.text = NomCarte;

    }

    public void RefreshCompo()
    {
        dropdown.ClearOptions();
        for (int c = 0; c < composants.Count; c++)
        {
            string[] splitDatas = composants[c].Split(',');
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = "compo" + " " + (c + 1) + " " + splitDatas[0] + "     " + splitDatas[1] });
        }
        dropdown.transform.GetChild(dropdown.value).GetComponent<TextMeshProUGUI>().text = dropdown.options[dropdown.value].text;
    }

    public void ActiveEdit()
    {
        if (true == editPanel.activeInHierarchy)
        {
            editBtn.SetActive(true);
            editPanel.SetActive(false);
        }
        else if (false == editPanel.activeInHierarchy)
        {
            editBtn.SetActive(false);
            editPanel.SetActive(true);
        }
    }


    void ReadEditInputField()
    {
        NomCarte = EditInputField.GetComponent<TMP_InputField>().text;
        Debug.Log(NomCarte);
        simucript.RefreshOption();
    }

    public void EditValues()
    {
        ReadEditInputField();
    }
}
