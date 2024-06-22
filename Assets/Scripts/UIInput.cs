using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInput : MonoBehaviour
{
    public InputField IdInputField;
    public InputField PlayerNameInputField;

    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    public void Login() 
    {
        var id = IdInputField.text;
        var playerName = PlayerNameInputField.text;

        playerManager.SpawnPlayer(id, playerName);
    }

    public void Logout() 
    {
        var id = IdInputField.text;
        
        playerManager.DeletePlayer(id);
    }

    public void ChangeColor() 
    {
        var id = IdInputField.text;

        playerManager.ChangePlayerColor(id);
    }
}
