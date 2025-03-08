using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEditCompoPanel : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject AddCompoPanel;
    public GameObject RemoveCompoPanel;

    public void ActivePanels()
    {
        if (true == AddCompoPanel.activeInHierarchy && true == RemoveCompoPanel.activeInHierarchy)
        {
            AddCompoPanel.SetActive(false);
            RemoveCompoPanel.SetActive(false);
        }
        else if (false == AddCompoPanel.activeInHierarchy && false == RemoveCompoPanel.activeInHierarchy)
        {
            AddCompoPanel.SetActive(true);
            RemoveCompoPanel.SetActive(true);
        }
    }
}
