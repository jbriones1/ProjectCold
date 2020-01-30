using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private FieldOfView fov;
	[SerializeField] GameObject wall;
	private float aimDir;
	private int health = 2;
	private int i;

	[SerializeField] private Sprite[] sprites;

	// Start is called before the first frame update
	void Start()
	{
		i = 0;
	}

	// Update is called once per frame
	void Update()
	{
		aimDir = Utilities.GetAngleFromVector(transform.rotation.eulerAngles);
		fov.SetAimDirection();
		fov.SetOrigin(transform.position);

		if (Input.GetMouseButtonDown(1))
		{
			i++;
			GetComponent<SpriteRenderer>().sprite = sprites[i]; }
	}

	private void CreateWall()
	{
		Instantiate(wall, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity);
	}

	private void ChangeSprite()
	{

	}

}
