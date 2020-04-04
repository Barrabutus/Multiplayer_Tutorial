using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomNameInput : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
 

    public void OnEnterInput()
    {
        
        inputField.text = inputField.text.ToUpper();
    }

    private void Awake() {
        inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) { return SetToUpper(addedChar); };
    }

    public char SetToUpper(char c) {
        string str = c.ToString().ToUpper();
        char[] chars = str.ToCharArray();
        return chars[0];
    }


}
