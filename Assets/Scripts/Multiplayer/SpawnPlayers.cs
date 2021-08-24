using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] playerPrefab;
    //public CharacterSelection character;
    int selectedCharacter;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), 2f, Random.Range(minZ, maxZ));
        //selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        //playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        GameObject prefab = playerPrefab[selectedCharacter];
        PickPlayer(prefab);
        prefab = PhotonNetwork.Instantiate(prefab.name, randomPos, Quaternion.identity);

    }

    void PickPlayer(GameObject prefab)
    {
        if (selectedCharacter == 0)
        {
            prefab.name = "DeLorean";
        }

        if (selectedCharacter == 1)
        {
            prefab.name = "March5";
        }

        if (selectedCharacter == 2)
        {
            prefab.name = "RedKiller";
        }
    }

}