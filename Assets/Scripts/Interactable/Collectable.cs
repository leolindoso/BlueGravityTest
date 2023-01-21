using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    [SerializeField]
    private ItemInfo m_item;
    public override void Use()
    {
        base.Use();

        int randomLoot = Random.Range(m_item.MinLootAmount, m_item.MaxLootAmount);
        GameManager.Instance.AddFruits(randomLoot);

        Destroy(gameObject);
    }
}
