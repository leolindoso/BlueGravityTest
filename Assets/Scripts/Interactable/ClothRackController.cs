using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClothRackController : Interactable
{
    [SerializeField]
    private ItemInfo m_item;
    [SerializeField]
    private TMP_Text m_priceText;
    [SerializeField]
    private PopUpInfo m_noMoneyPopUpInfo;


    private void Start()
    {
        m_priceText.text = m_item.Price.ToString();
    }
    public override void Use()
    {
        base.Use();
        if(GameManager.Instance.PlayerMoney >= m_item.Price)
        {
            GameManager.Instance.AddMoney(-m_item.Price);
            GameManager.Instance.AddPurchasedCloth(m_item.Index);
        }
        else{
            UIManager.Instance.ShowPopUp(m_noMoneyPopUpInfo, null, null);
        }
    }

}
