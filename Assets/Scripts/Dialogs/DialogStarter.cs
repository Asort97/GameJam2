using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogStarter : MonoBehaviour
{
    public static Action<string, string[]> OnOpenMonolog;
    [SerializeField] private string nameItem;
    [SerializeField] private string[] monologLines;
    [SerializeField] private bool canStartAgain = true;
    private bool alreadyOpen;

    private void Update()
    {
        if(InputManager.Instance.PlayerAction() && !DialogManager.instance.isOpen)
        {
            OpenMonolog();
        }
    }
    
    public void OpenMonolog()
    {
        Debug.Log($"Вызывать при взаимодействии с итемом");

        if(!alreadyOpen)
        {
            OnOpenMonolog?.Invoke(nameItem, monologLines);
            
            if(!canStartAgain)
            {
                alreadyOpen = true;
            }
        }
    }

}
