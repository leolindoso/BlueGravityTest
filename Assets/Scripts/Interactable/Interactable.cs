using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject m_canvas;
    public void ActivateCanvas(bool flag)
    {
        if(m_canvas != null)
        {
            m_canvas.SetActive(flag);
        }
    }
    
    public virtual void Use()
    {
        Debug.Log($"Using {name}");
    }
}
