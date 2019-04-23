using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour
{
    ChatSystem chat = new ChatSystem();
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            CmdSendChat();
            return;
        }
        if (!isServer)
        {
            Debug.Log("sending name");
            CmdSendName();
            RpcUpdateChat();
        }
    }


    public void DestroyOnServer(GameObject spawnedObj)
    {
        if (isServer)
        {
            NetworkServer.Destroy(spawnedObj);
        }
        else {
            Debug.Log("asking server to destroy obj");
            CmdDestroyObject(spawnedObj);
        }


    }
    public void NodeMakeProgressForAll(int nodeID)
    {
        if (isServer)
        {
            Debug.Log("Make Node Progress for all");
            Node node = Map.instance.nodeList[nodeID];
            node.MakeProgress();
            RpcUpdateNode(nodeID, node.GetProgress());

        }
        else
        {
            Debug.Log("asking server to notify all clients to update node progress");
            CmdNodeMakeProgress(nodeID);
        }


    }


    [Command]
    void CmdDestroyObject(GameObject obj)
    {
        Debug.Log("sending command");
        NetworkServer.Destroy(obj);

    }



    [Command]
    void CmdSendName()
    {
        transform.name = "ClientPlayer";
    }




    [Command]
    void CmdNodeMakeProgress(int nodeID)
    {
        Node node = Map.instance.nodeList[nodeID];
        node.MakeProgress();
        RpcUpdateNode(nodeID,node.GetProgress());
    }



    [ClientRpc]
    void RpcUpdateNode(int nodeID, float progress) {
        Map.instance.nodeList[nodeID].SetProgress(progress);
    }
    
    [Command]
    void CmdSendChat()
    {
        chat.sendMessageToChat(chat.username + ": " + chat.chatBox.text, Message.MessageType.playerMessage);
    }

    [ClientRpc]
    void RpcUpdateChat()
    {
        chat.sendMessageToChat(chat.username + ": " + chat.chatBox.text, Message.MessageType.playerMessage);
    }


}

