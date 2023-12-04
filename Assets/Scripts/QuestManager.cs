using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [Serializable]
    public class Quests
    {
        public string questName;
        public bool isCompleted;
    }

    public Quests[] questsList;

    private void Awake()
    {
        instance = this;        
    }

    public bool CheckQuestComplete(string quest)
    {
        foreach (Quests item in questsList)
        {
            if (item.questName == quest)
            {
                return item.isCompleted;
            }
        }

        return false;
    }
    
    public void SetCompleteQuest(string quest)
    {
        Debug.Log(quest);
        foreach (Quests item in questsList)
        {
            if (item.questName == quest)
            {
                item.isCompleted = true;
            }
        }
    }
}
