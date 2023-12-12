using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel playerModel;
    private PlayerView playerView;


    private void Start()
    {
        playerModel = GetComponent<PlayerModel>();
        playerView = GetComponent<PlayerView>();

        playerModel.OnHealthChange += playerView.UpdateHealthText;
        playerModel.OnPlayerDeath += playerView.ShowPlayerDeath;
    }
    public void Initialize(PlayerModel model)
    {
        playerModel = model;
        playerView = GetComponent<PlayerView>();

        playerModel.OnHealthChange += playerView.UpdateHealthText;
        playerModel.OnPlayerDeath += playerView.ShowPlayerDeath;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerModel.ChangeHealth(-20); 
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerModel.ChangeHealth(-10);
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        playerModel.Move(movement);
    }
}