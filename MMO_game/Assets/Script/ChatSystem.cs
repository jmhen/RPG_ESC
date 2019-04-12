﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSystem : MonoBehaviour
{
    public string username;
    public int maxMessages = 15;
    public GameObject chatPanel, textObject, scrollView, inputField, sendButton;
    public InputField chatBox;
    public Color playerMessage, info;
    public Button sendMessageButton;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    // Start is called before the first frame update
    void Start()
    {
        scrollView.SetActive(false);
        chatPanel.SetActive(false);
        textObject.SetActive(false);
        inputField.SetActive(false);
        sendButton.SetActive(false);
        sendMessageButton.onClick.AddListener(delegate {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                sendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        //To activate the input field
        if (chatBox.text == "") 
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return)) {
                chatBox.ActivateInputField();
            }
        }


        //To check if chat box is active
        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                sendMessageToChat("You have pressed enter!", Message.MessageType.info);
                Debug.Log("Space");
            }
        }


    }

    public void ToggleChat()
    {
        scrollView.SetActive(!scrollView.activeSelf);
        chatPanel.SetActive(!chatPanel.activeSelf);
        textObject.SetActive(!textObject.activeSelf);
        inputField.SetActive(!inputField.activeSelf);
        sendButton.SetActive(!sendButton.activeSelf);
    }

    public void sendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
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

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;
        switch (messageType)
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
