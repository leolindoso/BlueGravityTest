using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopUpScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_description;
    [SerializeField]
    private TMP_Text m_confirmText;
    [SerializeField]
    private TMP_Text m_cancelText;
    [SerializeField]
    private Button m_confirmBtn;
    [SerializeField]
    private Button m_cancelBtn;
    [SerializeField]
    private PopUpInfo m_popUpInfo;

    private Action m_onConfirmCallback;
    private Action m_onCancelCallback;


    private void OnEnable()
    {
        m_cancelBtn.onClick.AddListener(OnCancel);
        m_confirmBtn.onClick.AddListener(OnConfirm);
    }
    private void OnDisable()
    {
        m_cancelBtn.onClick.RemoveAllListeners();
        m_confirmBtn.onClick.RemoveAllListeners();
    }
    public void ShowPopUp(PopUpInfo info, Action onConfirm, Action onCancel)
    {
        if(info == null)
        {
            return;
        }
        ResetPopUp();

        m_popUpInfo = info;
        m_onConfirmCallback = onConfirm;
        m_onCancelCallback = onCancel;

        m_description.text = info.Description;

        if (!string.IsNullOrEmpty(info.ConfirmText))
        {
            m_confirmText.text = info.ConfirmText;
        }
        else
        {
            m_confirmBtn.transform.parent.gameObject.SetActive(false);
        }

        if (!string.IsNullOrEmpty(info.CancelText))
        {
            m_cancelText.text = info.CancelText;
        }
        else
        {
            m_cancelBtn.transform.parent.gameObject.SetActive(false);
        }

        gameObject.SetActive(true);
        GameManager.Instance.SetGameState(GameState.ON_POP_UP);
    }

    private void OnConfirm()
    {
        m_onConfirmCallback?.Invoke();
        GameManager.Instance.SetGameState(GameState.EXPLORING);
        gameObject.SetActive(false);
    }
    private void OnCancel()
    {
        m_onCancelCallback?.Invoke();
        GameManager.Instance.SetGameState(GameState.EXPLORING);
        gameObject.SetActive(false);
    }
    private void ResetPopUp()
    {
        m_confirmBtn.transform.parent.gameObject.SetActive(true);
        m_cancelBtn.transform.parent.gameObject.SetActive(true);
    }
}
