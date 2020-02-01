using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private FieldOfView fov;
	private int health;

	// Start is called before the first frame update
	void Start()
	{
		health = 2;
	}

	// Update is called once per frame
	void Update()
	{
		fov.SetOrigin(transform.position);
	}


}
