using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteMissingCompoList : MonoBehaviour
{
    public string valuesToWrite = "";
    public SimuScript simuScript;
    public string cardName;

    public void WriteMissingCompoListe()
    {
        cardName = simuScript.cardToProdData.NomCarte;
        valuesToWrite = "";
        for (int i = 0;i < simuScript.NegCompoValue.Count; i++)
        {
            valuesToWrite = valuesToWrite + simuScript.NegCompoValue[i] + System.Environment.NewLine;
        }

        if (!Application.isEditor)
        {
            File.WriteAllText(cardName + " " + "ListCompoMissing" + ".txt", valuesToWrite);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + cardName + " " + "ListCompoMissing" + ".txt", valuesToWrite);
        }


        Debug.Log(valuesToWrite);
    }
}
