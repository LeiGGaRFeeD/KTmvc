using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start()
    {
        GameObject playerObject = Instantiate(playerPrefab);
        PlayerModel playerModel = playerObject.GetComponent<PlayerModel>();
        PlayerController playerController = playerObject.AddComponent<PlayerController>();

        playerController.Initialize(playerModel);
    }
}