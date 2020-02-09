using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private FieldOfView fov;
	[SerializeField] private Sprite[] sprite;
	[SerializeField] public float Health { get; set; }

	private SpriteRenderer sr;

	// Start is called before the first frame update
	void Start()
	{
		Health = 100f;
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		fov.SetOrigin(transform.position);
		Rot();
		ChangeSprite();
		//CheckDeath();
	}

	public void Rot()
	{
		Health -= 3f * Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			this.Health -= 30f;
		}

		if (collision.gameObject.tag == "Stick")
		{
			Destroy(collision.gameObject);
			this.Health += 30f;
		}
	}

	private void ChangeSprite()
	{
		if (Health < 50)
		{
			sr.sprite = sprite[1];
		} else
		{
			sr.sprite = sprite[0];
		}
	}

	private void CheckDeath()
	{
		if (Health <= 0)
		{
			FindObjectOfType<LevelController>().RestartGame();
		}
	}

}
