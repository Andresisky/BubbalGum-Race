using UnityEngine;
using Photon.Pun;


public class PlayerNetwork : MonoBehaviourPun
{
    public GameObject localCam;
    public GameObject localCanvas;
    private void Start()
    {
        if (!photonView.IsMine)
        {
            localCam.SetActive(false);
            localCanvas.SetActive(false);

            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is PlayerNetwork) continue;
                else if (scripts[i] is PhotonView) continue;
                else if (scripts[i] is PhotonTransformView) continue;
                else if (scripts[i] is PhotonRigidbodyView) continue;
                else if (scripts[i] is Turbo) continue;

                scripts[i].enabled = false;
            }

        }
    }

}
