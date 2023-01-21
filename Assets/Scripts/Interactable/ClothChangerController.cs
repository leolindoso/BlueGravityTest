using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothChangerController : Interactable
{
    public override void Use()
    {
        base.Use();
        GameManager.Instance.ChangePlayerCloth();
    }
}
