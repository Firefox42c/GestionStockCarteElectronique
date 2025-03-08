using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class negCompoInit : MonoBehaviour
{
    public TextMeshProUGUI codeArtText;
    public TextMeshProUGUI qteText;
    public SimuScript simuScript;
    public GameObject content;
    public int compoNegId;
    public void Awake()
    {
        simuScript = GameObject.FindGameObjectWithTag("simuScript").GetComponent<SimuScript>();
        content = GameObject.FindGameObjectWithTag("Compo-Content");

        compoNegId = simuScript.NegCompoValue.Count - 1;
    }
    private void Start()
    {
        this.transform.SetParent(content.transform, false);
        string[] splitDatas = simuScript.NegCompoValue[compoNegId].Split(',');
        codeArtText.text = splitDatas[0];
        qteText.text = splitDatas[1];
    }
}
