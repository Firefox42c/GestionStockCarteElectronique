using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public GameObject[] composant;
    public int totalElements;
    public GameObject content;
    public List<string> data;

    public int instatiated;
    public GameObject compoAddprefa;
    public GameObject card;
    public RestScript resetScr;

    public int EditElement;

    private void Start()
    {
        data = new List<string>();   
    }
    private void Update()
    {
        if(resetScr.reseting == false)
        {
            totalElements = content.transform.childCount;


            composant = new GameObject[totalElements];

            for (int i = 0; i < totalElements; i++)
            {
                composant[i] = content.transform.GetChild(i).gameObject;
            }

            if (data.Count < totalElements)
            {
                data.Add(composant[totalElements - 1].gameObject.GetComponent<compoInit>().codeArticle + "," + composant[totalElements - 1].gameObject.GetComponent<compoInit>().descriptif
                    + "," + composant[totalElements - 1].gameObject.GetComponent<compoInit>().quantité);
            }

            if (instatiated < totalElements)
            {
                card.SetActive(true);
                Instantiate(compoAddprefa, new Vector3(0, 0, 0), Quaternion.identity);
                instatiated += 1;
            }
        }
    }


}
