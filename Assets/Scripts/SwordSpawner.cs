using UnityEngine;
using Random = UnityEngine.Random;

public class SwordSpawner : MonoBehaviour
{
	public Sprite[] swords;
	public GameObject swordPrefab;
	private int n_swordsPerArea = 2;
	
	// private float time;

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
		CreateSwords(n_swordsPerArea, area1_collider);
		CreateSwords(n_swordsPerArea, area2_collider);
		CreateSwords(n_swordsPerArea, area3_collider);
		CreateSwords(n_swordsPerArea, area4_collider);
		CreateSwords(n_swordsPerArea, area5_collider);
		CreateSwords(n_swordsPerArea, area6_collider);
		CreateSwords(n_swordsPerArea, area7_collider);
		CreateSwords(n_swordsPerArea, area8_collider);
	}
    
	private void CreateSwords(int n, BoxCollider2D area)
	{
		for (int i = 0; i < n; i++)
		{
			int swordType = Random.Range(0, swords.Length);
			GameObject newSword = Instantiate(swordPrefab);
			newSword.GetComponent<SpriteRenderer>().sprite = swords[swordType];
			
			newSword.transform.parent = this.transform; // Make it child of the thing this script is attached to
			newSword.transform.position = RandomizePosition(area); // Set new position
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