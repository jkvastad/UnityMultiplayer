using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;


public class NetworkUtilities : MonoBehaviour
{
    private NetworkManager networkManager;
    private UnityTransport networkTransport;
    [SerializeField] private TMP_InputField hostIPInputField;
    private GameObject lobbyUI;

    // Start is called before the first frame update
    void Start()
    {
        networkManager = GetComponentInParent<NetworkManager>();
        networkTransport = GetComponentInParent<UnityTransport>();
        lobbyUI = GameObject.Find("LobbyUI");

        networkManager.OnClientConnectedCallback += ClientConnected;
    }

    public void ConnectToGame()
    {
        Debug.Log($"Connecting to {hostIPInputField.text}");
        networkTransport.ConnectionData.Address = hostIPInputField.text;
        networkManager.StartClient();               
    }

    public void HostGame()
    {
        Debug.Log($"Hosting Game");
        networkManager.StartHost();
        DestroyLobbyUI();
    }

    private void DestroyLobbyUI()
    {
        Destroy(lobbyUI);
    }

    private void ClientConnected(ulong clientId)
    {
        Debug.Log($"Connected as client {clientId}");
        DestroyLobbyUI();
    }    

}
