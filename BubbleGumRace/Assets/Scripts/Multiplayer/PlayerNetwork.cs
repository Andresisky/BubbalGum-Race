using UnityEngine;
using Photon.Pun;


public class PlayerNetwork : MonoBehaviourPun
{
    public GameObject localCam;

    private void Start()
    {
        if (!photonView.IsMine)
        {
            localCam.SetActive(false);

            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is PlayerNetwork) continue;
                else if (scripts[i] is PhotonView) continue;
                else if (scripts[i] is PhotonTransformView) continue;
                else if (scripts[i] is PhotonRigidbodyView) continue;

                scripts[i].enabled = false;
            }

        }
    }

}
