using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class createCSV : MonoBehaviour
{
    public GameObject content;
    public List<GameObject> childe;
    public compoInit compo;
    private string qte;

    public string csvToPrint;

    public List<string> Values;

    public void genCSV()
    {
        Values.Clear();
        csvToPrint = "";
        childe = new List<GameObject>();
        if (childe.Count > 0)
        {
            for (int x = 0; x < childe.Count; x++)
            {
                childe.Remove(childe[x]);
            }
        }
        if (Values.Count > 0)
        {
            for (int y = 0; y < Values.Count; y++)
            {
                Values.Remove(Values[y]);
            }
        }


        for (int i = 0; i < content.transform.childCount; i++)
        {
            childe.Add(GameObject.FindGameObjectWithTag("compo"));
            childe[i].gameObject.tag = ("Player");
        }
        for (int s = 0; s < childe.Count; s++)
        {
            compo = childe[s].GetComponent<compoInit>();
            qte = compo.quantité.ToString();
            Values.Add(compo.codeArticle + "," + compo.descriptif + "," + qte);
        }
        for (int c = 0; c < Values.Count; c++)
        {
            csvToPrint = csvToPrint + Values[c] + System.Environment.NewLine;
        }
        if (!Application.isEditor)
        {
            File.WriteAllText("compo.csv", csvToPrint);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + "compo.csv", csvToPrint);
        }

        
        Debug.Log(Values);


        for (int i = 0; i < content.transform.childCount; i++)
        {
            childe[i].gameObject.tag = ("compo");
        }
    }
}
