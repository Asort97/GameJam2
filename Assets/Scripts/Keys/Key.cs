using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Key : MonoBehaviour
{

    [SerializeField] protected GameObject key;
    [SerializeField] protected GameObject DialogueBox;
    public abstract void Interaction();
    
        
    
}
