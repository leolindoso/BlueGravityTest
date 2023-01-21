using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : Interactable
{
    [SerializeField]
    private PopUpInfo m_popUpInfo;
    public override void Use()
    {
        base.Use();
        UIManager.Instance.ShowPopUp(m_popUpInfo, onConfirmSellFruits,null);
    }

    private void onConfirmSellFruits()
    {
        GameManager.Instance.SellFruits();
    }
}
