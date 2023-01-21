using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    private Interactable m_interactableObj;

    private void Update()
    {
        if (m_interactableObj != null && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.GameState != GameState.ON_POP_UP){
            m_interactableObj.Use();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Interactable"))
        {
            m_interactableObj = collision.collider.GetComponent<Interactable>();
            m_interactableObj.ActivateCanvas(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Interactable"))
        {
            m_interactableObj.ActivateCanvas(false);
        }
    }


}
