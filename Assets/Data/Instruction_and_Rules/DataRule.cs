using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTextData", menuName = "Create TextData")]
public class DataRule : ScriptableObject
{
    public int id;
    public string title;
    public string[] titlesSmall;
    public string[] paragraphs;
    public bool pass;
    public string tag;

    public int Id { get => id; }
    public string Title { get => title; }
    public string[] TitlesSmall { get => titlesSmall; }
    public string[] Paragraphs { get => paragraphs; }
    public bool Pass { get => pass; }
    public string Tag { get => tag; }
}
