using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private GameObject enableObject;
    [SerializeField] private bool setEnable;
    [SerializeField] private string questToComplete;
    [SerializeField] private bool canTriggerAgain;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enableObject.SetActive(setEnable);

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
