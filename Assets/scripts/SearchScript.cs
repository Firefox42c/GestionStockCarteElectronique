using UnityEngine;
using TMPro;

public class SearchScript : MonoBehaviour
{
    public GameObject content;

    public GameObject[] Element;

    public GameObject SearchBar;

    public int totalElements;


    void Update()
    {
        totalElements = content.transform.childCount;


        Element = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++)
        {
            Element[i] = content.transform.GetChild(i).gameObject;
        }
    }

    public void Search()
    {
        string SearchText = SearchBar.GetComponent<TMP_InputField>().text;
        int searchTxtLength = SearchText.Length;

        int searchedElements = 0;

        foreach(GameObject ele in Element)
        {
            searchedElements += 1;

            if (ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length >= searchTxtLength)
            {
                if(SearchText.ToLower() == ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0, searchTxtLength).ToLower())
                {
                    ele.SetActive(true);
                }
                else
                {
                    ele.SetActive(false);
                }
            }
        }
    }
}
