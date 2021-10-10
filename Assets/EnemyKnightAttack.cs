using System;
using System.Collections;
using UnityEngine;

public class EnemyKnightAttack : MonoBehaviour
{
    public GameObject enemySword;
    private float timer; 
    [SerializeField] private float interval = 2f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            enemySword.SetActive(false);
        }
        else
        {
            enemySword.SetActive(true);
        }
        timer = 0;
    }
}