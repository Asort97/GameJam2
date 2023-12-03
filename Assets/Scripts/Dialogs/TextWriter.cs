using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    [SerializeField] private TMP_Text monologLineText;
    private int characterIndex;
    private string textToWrite;
    private float timer;
    private float timerPerCharacter;

    public void AddWriter(string text, float timePerCharacter)
    {
        characterIndex = 0;
        textToWrite = text;
        this.timerPerCharacter = timePerCharacter;
    }

    private void Update()
    {
        if (characterIndex < textToWrite.Length)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                timer += timerPerCharacter;
                characterIndex++;
                monologLineText.text = textToWrite.Substring(0, characterIndex);
            }
        }
    }
}
