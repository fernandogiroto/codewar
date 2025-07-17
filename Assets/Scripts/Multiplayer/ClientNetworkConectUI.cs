using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class NetworkConnectUI : MonoBehaviour
{
    public string hostIP = "192.168.1.132";
    public ushort port = 7777;
    

    public void StartClient()
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData(hostIP, port);
        NetworkManager.Singleton.StartClient();
        Debug.Log($"Connecting to server at {hostIP}:{port}");
    }
    public void StartHost()
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData(hostIP, port);
        NetworkManager.Singleton.StartHost();

        var arcadeMenu = GameObject.FindGameObjectWithTag("ArcadeMenu");
        arcadeMenu.SetActive(false);
    }
}
