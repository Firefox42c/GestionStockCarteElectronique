using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public GameObject[] card;

    public GameObject cardContent;
    public SimuScript simuScript;

    public int totalElements;

    private void Update()
    {
        totalElements = cardContent.transform.childCount;
        card = new GameObject[totalElements];
        for (int i = 0; i < cardContent.transform.childCount; i++)
        {
            card[i] = cardContent.transform.GetChild(i).gameObject;
        }
    }
}
