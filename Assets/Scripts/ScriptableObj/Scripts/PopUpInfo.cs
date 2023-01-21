using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/PopUpInfo")]
public class PopUpInfo : ScriptableObject
{
    public string Description;
    public string ConfirmText;
    public string CancelText;
    
}
