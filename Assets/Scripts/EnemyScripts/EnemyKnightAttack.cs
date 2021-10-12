using System;
using System.Collections;
using UnityEngine;

    public class EnemyKnightAttack : MonoBehaviour
{
    public GameObject enemySword;
    private float timer; 
    [SerializeField] private float interval = 2f;
    [SerializeField] private float paus = 1f;
    private Animator anim;

    private void Start()
    { 
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (timer >= interval)
        {
            
            enemySword.SetActive(true);
            anim.SetBool("isAttacking", true);
            timer = 0;
            
            StartCoroutine(ToggleAttack(paus));
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    private IEnumerator ToggleAttack(float duration)
    {
        // Wait for the attack duration
        yield return new WaitForSeconds(duration);
        
        if (enemySword.activeSelf)
        {
            enemySword.SetActive(false);
            anim.SetBool("isAttacking", false);

        }
    }
}