using Unity.Netcode;
using UnityEngine;
using Unity.Cinemachine;

public class CameraFollowAssigner : NetworkBehaviour
{

    [SerializeField] private Transform cameraFollowTarget;   // O personagem (transform root)
    [SerializeField] private Transform cameraLookAtTarget;   // O filho na altura da cabeça

    private CinemachineCamera cineCam;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            SetupCamera();
        }
    }

    private void SetupCamera()
    {
        var camObj = GameObject.FindGameObjectWithTag("CinemachineCamera");
        if (camObj == null)
        {
            Debug.LogWarning("Objeto com tag 'CinemachineCamera' não encontrado.");
            return;
        }

        cineCam = camObj.GetComponent<CinemachineCamera>();

        if (cineCam == null)
        {
            Debug.LogWarning("Componente CinemachineVirtualCamera não encontrado no objeto com tag 'CinemachineCamera'.");
            return;
        }

        cineCam.Follow = cameraFollowTarget;
        cineCam.LookAt = cameraLookAtTarget;
    }
}
