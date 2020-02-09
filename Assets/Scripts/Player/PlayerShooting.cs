using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] Rigidbody2D playerBullet;
    [SerializeField] float projFirePeriod = 0.1f;

    Player player;
    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.Health > 50)
        {
            firingCoroutine = StartCoroutine(FireNormal());
        }
        if (Input.GetKeyUp(KeyCode.Space) || player.Health <= 50)
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireNormal()
    {
        while (player.Health > 50)
        {
            Rigidbody2D pBullet = Instantiate(
            playerBullet,
            transform.position,
            Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
            Debug.Log(transform.forward * projectileSpeed);
            player.Health -= 20;
            yield return new WaitForSeconds(projFirePeriod);
        }
    }
}
