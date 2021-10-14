using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private AudioManager audioManager;
    private Rigidbody2D playerBody;
    public Animator anim;
    private PlayerWeapon playerSwordScript;
    public GameObject textPopUpPrefab;
    private AudioSource audioSrc;
    

    [SerializeField] private float playerMoveSpeed = 10f;
    //[SerializeField] private float dashForce = 5000f;
    //private float damageKnockBack = 5000f;

    private Vector2 mousePosition;
    private float inputHorizontal;
    private float inputVertical;
    private bool inputAttack;
    private bool inputDash;
    
    // private GameObject scoreObj;
    // private Score s;

    public bool isWalking;
    
    // To Roll
    private bool isRolling;
    private KeyCode lastKeyPushed;

    private string text;
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        cam = Camera.main;
        audioManager =  GameObject.Find("AudioManager").GetComponent<AudioManager>();
        playerBody = GetComponent<Rigidbody2D>();
        playerSwordScript = GetComponent<PlayerWeapon>();
        // scoreObj = GameObject.Find("ScoreObject");
        // s = scoreObj.GetComponent<Score>();
        // s.PlayerScore += 0;
    }
    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        inputAttack = Input.GetButtonDown("Fire1");
        inputDash = Input.GetKeyDown("space");
        
        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width/2;
        mousePosition.y -= Screen.height/2;
        
        if (inputHorizontal!= 0 || inputVertical !=0)
        {
            isWalking = true;
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
        {
            isWalking = false;
            audioSrc.Stop();
        }

        if (isWalking)
        {
        }
        
        
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("xInput", inputHorizontal);
        anim.SetFloat("yInput", inputVertical);
        anim.SetFloat("mouseXInput", mousePosition.x);
        anim.SetFloat("mouseYInput", mousePosition.y);
        
        if (inputAttack)
        {
            Vector2 attackTarget = mousePosition;
            
            if (playerSwordScript.Attack())
            {
                anim.SetTrigger("isAttacking");
                audioManager.Play("PlayerSwing");
            }
        }
        if (inputDash)
        {
        }

        if (textPopUpPrefab)
        {
            ShowTextPopUp(text);
        }
        
    }

    private void FixedUpdate()
    {
       Move();
    }
    
    private void Move()
    {
        
        playerBody.velocity = new Vector2(inputHorizontal * playerMoveSpeed, inputVertical * playerMoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Drop"))
        {
            ShowTextPopUp("10");
            audioManager.Play("DingNote");
            Score.PlayerScore += 100;
            Destroy(other.gameObject);
        }
    }
    
    public void ShowTextPopUp(string text)
    {
        var go = Instantiate(textPopUpPrefab, transform);
        go.GetComponent<TextMesh>().text = text;

    }
    
}
