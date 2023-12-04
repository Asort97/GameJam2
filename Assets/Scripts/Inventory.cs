using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public List<GameObject> ItemsInHand = new List<GameObject>();

    [SerializeField] private GameObject keyObject;
    [SerializeField] private GameObject realKeyObject;
    [SerializeField] private GameObject maniakObject;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        ItemObject.OnTakeItem += TakeItem;
    }
    private void OnDisable()
    {
        ItemObject.OnTakeItem -= TakeItem;
    }

    private void TakeItem(int id)
    {
        switch (id)
        {
            case 0:
                keyObject.SetActive(true);
                break;
            case 1:
                realKeyObject.SetActive(true);
                break;
            case 2:
                maniakObject.SetActive(true);
                break;
        }
    }

}
