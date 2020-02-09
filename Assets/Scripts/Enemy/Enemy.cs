using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    AIDestinationSetter aids;

    // Start is called before the first frame update
    void Start()
    {
        aids = GetComponent<AIDestinationSetter>();
        aids.target = FindObjectOfType<Player>().transform;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Fireball")
		{
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}

	}
}
