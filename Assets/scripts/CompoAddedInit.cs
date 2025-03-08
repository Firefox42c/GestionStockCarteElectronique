using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompoAddedInit : MonoBehaviour
{
    public TextMeshProUGUI TextCodeArt;
    public TextMeshProUGUI textQte;

    public CarteScript carteScript;
    public Transform content;
    public string codeArt;

    public GameObject card;

    public string qte;

    void Awake()
    {
        card = GameObject.FindGameObjectWithTag("CarteMenu");
        content = GameObject.FindGameObjectWithTag("CntAddedCompo").GetComponent<Transform>();
        carteScript = GameObject.FindGameObjectWithTag("CarteScript").GetComponent<CarteScript>();
    }

    private void Start()
    {
        codeArt = carteScript.codeAddArt;
        qte = carteScript.qteAddArt;
        this.transform.SetParent(content.transform, false);
        //card.SetActive(false);   
    }

    void Update()
    {
        TextCodeArt.text = codeArt;
        textQte.text = qte;
    }

    public void RemoveIt()
    {
        Destroy(this);
    }
}
