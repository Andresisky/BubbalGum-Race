using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviourPun
{
    public GameObject[] playerPrefab;
    int selectedCharacter;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), 2f, Random.Range(minZ, maxZ));
        //playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        PickPlayer();
        PhotonNetwork.Instantiate(playerPrefab[selectedCharacter].name, randomPos, Quaternion.identity);

    }

    void PickPlayer()
    {
        if (selectedCharacter == 0)
        {
            playerPrefab[selectedCharacter].name = "DeLorean";
        }

        if (selectedCharacter == 1)
        {
            playerPrefab[selectedCharacter].name = "Mach5";
        }

        if (selectedCharacter == 2)
        {
            playerPrefab[selectedCharacter].name = "RedKiller";
        }
    }
}