using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), 2f, Random.Range(minZ, maxZ));
        playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
    }


}
