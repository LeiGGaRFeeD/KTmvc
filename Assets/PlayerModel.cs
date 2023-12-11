using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModel : MonoBehaviour
{
    public event Action<int> OnHealthChange;
    public event Action OnPlayerDeath;

    public void Start()
    {
        Debug.Log("Script Started");
    }

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public float speed = 5f; // �������� ����������� ������

    private void Awake()
    {
        MaxHealth = 100; // ��������� ������������� ��
        CurrentHealth = MaxHealth;
    }

    public void ChangeHealth(int amount)
    {
        CurrentHealth += amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnPlayerDeath?.Invoke();
        }

        OnHealthChange?.Invoke(CurrentHealth);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() == true)
        {
            Debug.Log("Ouch!");
            ChangeHealth(-20); // ������: ���������� �� �� 20 ��� ������������ � ������
        }
        Debug.Log("Collision Worked!");
    }

    public void Move(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * speed;
    }
}