using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogStarter : MonoBehaviour
{
    [Serializable]
    public struct MonologsLines
    {
        public string[] lines;
        public string questToGetAccess;
        public string questToCompleteAfter;
    }
    public static Action<string, string[], DialogStarter> OnOpenMonolog;
    [SerializeField] private MonologsLines[] monologsLines;
    [SerializeField] private string nameItem;
    [SerializeField] private bool canStartAgain = true;
    [SerializeField] private GameObject objectOnStart;
    [SerializeField] private bool objectOnStartEnabled;
    [SerializeField] private GameObject objectOnEnd;
    [SerializeField] private bool objectOnEndEnabled;
    private ItemObject itemObject;
    private bool alreadyOpen;
    private int currentMonolog;
    private int prevMonolog;
    private void Start()
    {
        itemObject = GetComponent<ItemObject>();
    }

    public void OpenMonolog()
    {   
        Debug.Log($"Вызывать при взаимодействии с итемом");

        if(!DialogManager.instance.isOpen && currentMonolog != monologsLines.Length)
        {
            if (!alreadyOpen)
            {
                if(objectOnStart)
                {
                    objectOnStart.SetActive(objectOnStartEnabled);
                }

                if(monologsLines[currentMonolog].questToGetAccess == "")
                {
                    prevMonolog = currentMonolog;
                    OnOpenMonolog?.Invoke(nameItem, monologsLines[currentMonolog].lines, this);  
                    currentMonolog++;
                }
                else
                {
                    if(QuestManager.instance.CheckQuestComplete(monologsLines[currentMonolog].questToGetAccess))
                    {
                        OnOpenMonolog?.Invoke(nameItem, monologsLines[currentMonolog].lines, this);  
                        currentMonolog++;
                    }
                }
                if(currentMonolog == monologsLines.Length)
                {
                    currentMonolog = 0;
                    if (!canStartAgain)
                    {
                        alreadyOpen = true;
                    }                    
                }

            }
        }
    }

    public void EndDialog()
    {
        itemObject.TakeItem(); // Если надо взять возьмет
        
        if(monologsLines[prevMonolog].questToCompleteAfter != "")
        {
            QuestManager.instance.SetCompleteQuest(monologsLines[prevMonolog].questToCompleteAfter);
        }        
        if(objectOnEnd)
        {
            objectOnEnd.SetActive(objectOnEndEnabled);
        }
    }

}
