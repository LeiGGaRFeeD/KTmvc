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
            playerModel.ChangeHealth(-20); // Пример: уменьшение хп на 20 при столкновении с врагом
        }
    }

    private void Update()
    {
        // Логика для изменения хп игрока
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerModel.ChangeHealth(-10); // Пример: уменьшение хп на 10
        }

        // Логика для перемещения игрока
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        playerModel.Move(movement);
    }
}