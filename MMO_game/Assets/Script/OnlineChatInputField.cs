using UnityEngine;
using UnityEngine.UI;

public class OnlineChatInputField : MonoBehaviour
{
    public OnlineChatManager chatManager;
    private InputField inputField;

    private void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void ValueChanged()
    {
        if (inputField.text.Contains("\n"))
            chatManager.WriteMessage(inputField);
    }

}
