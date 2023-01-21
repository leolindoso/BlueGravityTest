using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemInfo")]
public class ItemInfo : ScriptableObject
{
    public string Name;
    public int Price;
    [Header("Index(if necessary)")]
    public int Index;
    [Header("Loot(if necessary)")]
    public int MinLootAmount;
    public int MaxLootAmount;
}
