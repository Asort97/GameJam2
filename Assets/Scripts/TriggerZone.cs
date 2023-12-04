using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [Serializable]
    public class objToEnable
    {
        public GameObject obj;
        public bool toEnable;
    }

    public objToEnable[] objectsToEnable;
    [SerializeField] private string questToComplete;
    [SerializeField] private bool canTriggerAgain;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach (var item in objectsToEnable)
            {
                item.obj.SetActive(item.toEnable);
            }

            if(questToComplete != "")
            {
                QuestManager.instance.SetCompleteQuest(questToComplete);
            }

            if(!canTriggerAgain)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
