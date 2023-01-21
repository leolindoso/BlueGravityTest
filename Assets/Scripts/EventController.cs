using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{

    public static EventController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public delegate void OnHealthChanged();
    public static OnHealthChanged onHealthChanged;

    public delegate void OnMoneyChanged();
    public static OnMoneyChanged onMoneyChanged;

}
