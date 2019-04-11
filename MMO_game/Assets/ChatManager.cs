using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public string username;
    public int maxMessage = 30;

    public GameObject chatPanel, textObject, scrollView, inputField;
    public InputField chatBox;
    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    void Start()
    {
        inputField.SetActive(false);
        Debug.Log("set chat panel unseen");
        scrollView.SetActive(false);
        chatPanel.SetActive(false);
        textObject.SetActive(false);
    }

    public void TriggerChat()
    {
        inputField.SetActive(!inputField.activeSelf);
        scrollView.SetActive(!scrollView.activeSelf);
        chatPanel.SetActive(!chatPanel.activeSelf);
        textObject.SetActive(!textObject.activeSelf);
    }

    void Update()
    {
        if (chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the space bar!", Message.MessageType.info);
                Debug.Log("Space");
            }
        }

    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessage)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);
        messageList.Add(newMessage);

    }

    Color MessageTypeColor(Message.MessageType messagetype)
    {
        Color color = info;
        switch(messagetype)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }
}
