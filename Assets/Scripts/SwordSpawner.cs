using UnityEngine;
using Random = UnityEngine.Random;

public class SwordSpawner : MonoBehaviour
{
	public Sprite[] swords;
	public GameObject swordPrefab;
	private int n_swords = 10;
	
	public GameObject area1;
	private BoxCollider2D area1_collider;

	private void Awake()
	{
		area1_collider = area1.GetComponent<BoxCollider2D>();
	}

	void Start()
	{
		CreateSwords(n_swords, area1_collider);
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