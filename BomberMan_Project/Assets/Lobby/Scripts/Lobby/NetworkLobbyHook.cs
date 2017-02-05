using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook 
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		ControlPlayer player = gamePlayer.GetComponent<ControlPlayer>();

		player.m_playerName = lobby.playerName;
		player.m_playerColor = lobby.playerColor;
    }
}
