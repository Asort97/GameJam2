using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private GameObject dialogMenu;
    [SerializeField] private TextWriter textWriter;
    [SerializeField] private TMP_Text monologLineText;
    [SerializeField] private TMP_Text nameText;
    
    private string currentName;
    private string[] currentMonolog;
    public bool isOpen;

    private int currentLineMonolog;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        DialogStarter.OnOpenMonolog += Init;
    }

    private void OnDisable()
    {
        DialogStarter.OnOpenMonolog -= Init;
    }

    private void Update()
    {
        if(isOpen)
        {
            NextLine();
        }
    }

    private void Init(string name, string[] monolog)
    {
        currentName = name;
        currentMonolog = monolog;

        StartDialog();
    }

    private void StartDialog()
    {
        isOpen = true;
        dialogMenu.SetActive(true);

        nameText.text = currentName;
        textWriter.AddWriter(currentMonolog[currentLineMonolog], 0.05f);
        // monologLineText.text = currentMonolog[currentLineMonolog];
    }

    private void NextLine()
    {
        if(InputManager.Instance.PlayerLeftMouse() && currentLineMonolog < currentMonolog.Length)
        {
            currentLineMonolog++;
            textWriter.AddWriter(currentMonolog[currentLineMonolog], 0.1f);
            // monologLineText.text = currentMonolog[currentLineMonolog];
        }
        else if(currentLineMonolog >= currentMonolog.Length)
        {
            EndDialog();
        }
    }

    private void EndDialog()
    {
        isOpen = false;
        dialogMenu.SetActive(false);

        currentLineMonolog = 0;
    }
}
