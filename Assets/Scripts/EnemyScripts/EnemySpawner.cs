using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] monsters;
	private int n_monsters_per_area = 3;
	private float time;

	[SerializeField]
	private float timeToSpawn = 30f;

	public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public GameObject area4;
    public GameObject area5;
    public GameObject area6;
    public GameObject area7;
    public GameObject area8;

    private BoxCollider2D area1_collider;
    private BoxCollider2D area2_collider;
    private BoxCollider2D area3_collider;
    private BoxCollider2D area4_collider;
    private BoxCollider2D area5_collider;
    private BoxCollider2D area6_collider;
    private BoxCollider2D area7_collider;
    private BoxCollider2D area8_collider;
    
    private void Awake()
    {
	    area1_collider = area1.GetComponent<BoxCollider2D>();
	    area2_collider = area2.GetComponent<BoxCollider2D>();
	    area3_collider = area3.GetComponent<BoxCollider2D>();
	    area4_collider = area4.GetComponent<BoxCollider2D>();
	    area5_collider = area5.GetComponent<BoxCollider2D>();
	    area6_collider = area6.GetComponent<BoxCollider2D>();
	    area7_collider = area7.GetComponent<BoxCollider2D>();
	    area8_collider = area8.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
	    time = 0;
	    
	    CreateMonsters(n_monsters_per_area, area1_collider);
	    CreateMonsters(n_monsters_per_area, area2_collider);
	    CreateMonsters(n_monsters_per_area, area3_collider);
	    CreateMonsters(n_monsters_per_area, area4_collider);
	    CreateMonsters(n_monsters_per_area, area5_collider);
	    CreateMonsters(n_monsters_per_area, area6_collider);
	    CreateMonsters(n_monsters_per_area, area7_collider);
	    CreateMonsters(n_monsters_per_area, area8_collider);
    }

    private void Update()
    {
	    time += Time.deltaTime;

	    if (time >= timeToSpawn)
	    {
		    CreateMonsters(n_monsters_per_area, area1_collider);
		    CreateMonsters(n_monsters_per_area, area2_collider);
		    CreateMonsters(n_monsters_per_area, area3_collider);
		    CreateMonsters(n_monsters_per_area, area4_collider);
		    CreateMonsters(n_monsters_per_area, area5_collider);
		    CreateMonsters(n_monsters_per_area, area6_collider);
		    CreateMonsters(n_monsters_per_area, area7_collider);
		    CreateMonsters(n_monsters_per_area, area8_collider);
		    time = 0;
	    }
	    
    }
    
    
    private void CreateMonsters(int n, BoxCollider2D area)
    {
	    for (int i = 0; i < n; i++)
	    {
		    int monsterType = Random.Range(0, monsters.Length);
		    GameObject newMonster = Instantiate(monsters[monsterType]);
		    newMonster.transform.parent = this.transform; // Make it child of the thing this script is attached to
		    newMonster.transform.position = RandomizePosition(area); // Set new position
	    }
    }
    
    private Vector2 RandomizePosition(BoxCollider2D area)
    {
	    Vector2 minBounds = area.bounds.min;
		Vector2 maxBounds = area.bounds.max;
		
	    float x = Random.Range(minBounds.x, maxBounds.x);
	    float y = Random.Range(minBounds.y, maxBounds.y);

	    return new Vector2(x, y);
    }



}
