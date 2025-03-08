using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Composant", menuName = "My Game/Composant")]
public class Composant : ScriptableObject
{
    public string codeArticle;
    public string designation;
    public int Qte;
}
