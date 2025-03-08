using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestScript : MonoBehaviour
{
    public GameObject resetPanel;
    public DataBase database;
    public GameObject content;
    public GameObject content2;
    public bool reseting = false;

    public void ActiveResetPanel()
    {
        if (true == resetPanel.activeInHierarchy)
        {
            resetPanel.SetActive(false);
        }
        else if (false == resetPanel.activeInHierarchy)
        {
            resetPanel.SetActive(true);
        }
    }

    public void ResetData()
    {
        reseting = true;
        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
            Destroy(content2.transform.GetChild(i).gameObject);
        }
        database.data.Clear();
        database.instatiated = 0;
        //setResetFalse();
    }

    void Update()
    {
        if(content.transform.childCount == 0 && content2.transform.childCount == 0 && database.data.Count == 0)
        {
            reseting = false;
        }
    }
}
