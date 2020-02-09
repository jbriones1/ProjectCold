using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    [SerializeField] private AIPath aiPath;
    [SerializeField] private GameObject player;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* To face the player */

        //angle = Mathf.Atan2(transform.position.y - player.transform.position.y
        //    ,transform.position.x - player.transform.position.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle - 180);
    }
}
