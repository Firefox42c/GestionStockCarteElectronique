using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Create_Card_Csv : MonoBehaviour
{
    public CarteInit cartInit;
    private string qte;

    public string csvToPrint;

    public List<string> Values;

    public void genCSV()
    {
        Values.Clear();
        csvToPrint = "";
        for (int s = 0; s < cartInit.composants.Count; s++)
        {
            Values.Add(cartInit.composants[s]);
        }
        for (int c = 0; c < Values.Count; c++)
        {
            csvToPrint = csvToPrint + Values[c] + System.Environment.NewLine;
        }
        if (!Application.isEditor)
        {
            File.WriteAllText(cartInit.NomCarte + ".csv", csvToPrint);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + cartInit.NomCarte + ".csv", csvToPrint);
        }
            
        Debug.Log(Values);
    }
}
