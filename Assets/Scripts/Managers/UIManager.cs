using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_healthBars;
    [SerializeField]
    private TMP_Text m_moneyText;
    [SerializeField]
    private PopUpScreen m_popUpScreen;

    public static UIManager Instance;

    private void OnEnable()
    {
        EventController.onHealthChanged += UpdateHealthHUD;
        EventController.onMoneyChanged += UpdateMoneyHUD;
    }

    private void OnDisable()
    {
        EventController.onHealthChanged -= UpdateHealthHUD;
        EventController.onMoneyChanged -= UpdateMoneyHUD;
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthHUD();
        UpdateMoneyHUD();
    }

    private void UpdateHealthHUD()
    {
        for(int i = 0; i < GameManager.Instance.PlayerHealth; i++)
        {
            m_healthBars[i].SetActive(true);
        }
    }
    private void UpdateMoneyHUD()
    {
        m_moneyText.text = GameManager.Instance.PlayerMoney.ToString();
    }

    public void ShowPopUp(PopUpInfo info, Action onConfirm, Action onCancel)
    {
        m_popUpScreen.ShowPopUp(info,onConfirm,onCancel);
    }
}
