using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    EXPLORING,
    ON_POP_UP
}

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int m_playerHealth;
    [SerializeField]
    private int m_playerMoney;
    [SerializeField]
    private int m_playerFruits;
    [SerializeField]
    private bool[] m_playerPurchasedClothes;
    [SerializeField]
    private List<RuntimeAnimatorController> m_animators;
    [SerializeField]
    private Animator m_playerAnimator;
    [SerializeField]
    private GameState m_gameState = GameState.EXPLORING;
    [SerializeField]
    private ItemInfo m_fruitInfo;

    private int m_currentCloth;

    public static GameManager Instance;
    public int PlayerHealth => m_playerHealth;
    public int PlayerMoney => m_playerMoney;
    public int PlayerFruits => m_playerFruits;
    public bool[] PlayerPurchasedClothes => m_playerPurchasedClothes;
    public GameState GameState => m_gameState;

    private void Awake()
    {
        Instance = this;
    }

    public void AddHealth(int amount)
    {
        m_playerHealth += amount;
        EventController.onHealthChanged?.Invoke();
    }

    public void AddMoney(int amount)
    {
        m_playerMoney += amount;
        EventController.onMoneyChanged?.Invoke();
    }
    public void AddPurchasedCloth(int index)
    {
        m_playerPurchasedClothes[index] = true;
    }

    public void AddFruits(int amount)
    {
        m_playerFruits += amount;
    }

    public void SetGameState(GameState newState)
    {
        m_gameState = newState;
    }
    public void SellFruits()
    {
        AddMoney(m_playerFruits * m_fruitInfo.Price);
        m_playerFruits = 0;
    }
    public void ChangePlayerCloth()
    {
        m_currentCloth++;

        for(int i = m_currentCloth; i < m_playerPurchasedClothes.Length; i++)
        {
            if (m_playerPurchasedClothes[i])
            {
                m_currentCloth = i;
                m_playerAnimator.runtimeAnimatorController = m_animators[m_currentCloth];
                return;
            }
        }
        m_currentCloth = 0;
        m_playerAnimator.runtimeAnimatorController = m_animators[m_currentCloth];

    }
}
