using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScr : MonoBehaviour
{
    public GameObject stockMenu;
    public GameObject simuMenu;
    public GameObject FakeBg;
    void Update()
    {
        if (true == stockMenu.activeInHierarchy || true == simuMenu.activeInHierarchy)
        {
            FakeBg.SetActive(true);
        }
        else
        {
            FakeBg.SetActive(false);
        }
    }
}
