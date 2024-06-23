using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

    private Dictionary<string, Player> playerDictionary = new Dictionary<string, Player>();
    private Area area;

    private void Awake()
    {
        area = FindObjectOfType<Area>();
    }

    public void SpawnPlayer(string id, string playerName)
    {
        if (string.IsNullOrEmpty(id)) { return; }
        if (IsPlayerExist(id)) { return; }

        var position = area.GetRandomPosition();
        var playerObj = Instantiate(PlayerPrefab, position, Quaternion.identity);
        var player = playerObj.GetComponent<Player>();
        player.SetPlayerName(playerName);

        playerDictionary.Add(id, player);
    }

    public void DeletePlayer(string id)
    {
        if (!IsPlayerExist(id)) { return; }

        var player = playerDictionary[id];
        Destroy(player.gameObject);

        playerDictionary.Remove(id);
    }

    public void ChangePlayerColor(string id)
    {
        if (!IsPlayerExist(id)) { return; }

        var player = playerDictionary[id];
        player.ChangePlayerColor();
    }

    private bool IsPlayerExist(string id)
    {
        return playerDictionary.ContainsKey(id);
    }
}
