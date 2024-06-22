using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniTwitchClient.Chat;
using UniTwitchClient.Chat.Models;

public class TwitchInput : MonoBehaviour
{
    public string AccessToken;
    public string UserName;
    public string ChannelName;

    private TwitchChatClient client;
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Start()
    {
        if (string.IsNullOrEmpty(AccessToken) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(ChannelName)) { return; }

        client = new TwitchChatClient(new TwitchIrcCredentials(AccessToken, UserName));
        client.TwitchChatMessageAsObservable.Subscribe(HandleTwitchChatMessage).AddTo(this);
        client.Connect(ChannelName);
    }

    private void OnDestroy()
    {
        client?.Close();
        client?.Dispose();
    }

    private void HandleTwitchChatMessage(TwitchChatMessage twitchChatMessage) 
    {
        var command = twitchChatMessage.BotCommand;
        if (command == "login") 
        {
            Login(twitchChatMessage.UserId, twitchChatMessage.DisplayName);
        }
    }

    private void Login(string id, string playerName) 
    {
        playerManager.SpawnPlayer(id, playerName);
    }

    public void Logout(string id)
    {
        playerManager.DeletePlayer(id);
    }

    public void ChangeColor(string id)
    {
        playerManager.ChangePlayerColor(id);
    }
}
