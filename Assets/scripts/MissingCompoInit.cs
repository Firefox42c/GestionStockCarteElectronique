using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissingCompoInit : MonoBehaviour
{
    public SimuScript simuScript;
    public TextMeshProUGUI text;
    public GameObject content;
    public int compoMissingID;
    public string codeArt;
    private void Awake()
    {
        simuScript = GameObject.FindGameObjectWithTag("simuScript").GetComponent<SimuScript>();
        codeArt = simuScript.tempName;
    }
    void Start()
    {
        content = GameObject.FindGameObjectWithTag("MissingCompo");
        this.transform.SetParent(content.transform);
        text.text = codeArt;
    }
}
