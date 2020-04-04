using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private DebugConsole instance;

    public void AddText(string msg)
    {
        _text.text = "\n"+msg;
    }

    void Start()    
    {
        instance = this;
    }
}
