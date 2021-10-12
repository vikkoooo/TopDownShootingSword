using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] monsters;
	private int n_monsters = 10;
	
    public GameObject area1;
    private BoxCollider2D area1_collider;

    private void Awake()
    {
	    area1_collider = area1.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
	    CreateMonsters(n_monsters, area1_collider);
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
