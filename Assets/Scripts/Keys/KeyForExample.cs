using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForExample : Key
{
    public override void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DialogueBox.gameObject.SetActive(true);
        }
    }
}
