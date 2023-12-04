using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public static Action<int> OnTakeItem;
    [SerializeField] private bool canTake;
    [SerializeField] private bool isKey;
    [SerializeField] private bool isRealKey;
    [SerializeField] private bool isManiak;
    private DialogStarter dialogStarter;

    private void Start()
    {
        dialogStarter = GetComponent<DialogStarter>();
    }

    public void Interaction()
    {
        
        
            dialogStarter.OpenMonolog();
        
        
    }

    public void TakeItem()
    {
        if(canTake)
        {
            if(isKey)
            {
                OnTakeItem?.Invoke(0);
            }
            if(isRealKey)
            {
                OnTakeItem?.Invoke(1);
            }
            if(isManiak)
            {
                OnTakeItem?.Invoke(2);
            } 


            gameObject.SetActive(false);
        }
    }
}
