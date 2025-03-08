using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class importCsvUi : MonoBehaviour
{
    public TextMeshProUGUI pathText;
    public GameObject importCsvPanel;
    public ReadCSV csvReader;

    private void Start()
    {
        pathText.text = "";
    }
    public void toggleImportUi()
    {
        if (true == importCsvPanel.activeInHierarchy)
        {
            importCsvPanel.SetActive(false);
        }
        else if (false == importCsvPanel.activeInHierarchy)
        {
            importCsvPanel.SetActive(true);
        }
    }
    private void Update()
    {
        pathText.text = csvReader.csvPath;
    }

}
