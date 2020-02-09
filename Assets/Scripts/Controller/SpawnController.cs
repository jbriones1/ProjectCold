using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] Spawner[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        StartCoroutine(Spawn());
        Debug.Log(spawners.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            Debug.Log("Spawn");
            yield return new WaitForSeconds(10.0f);
            foreach (Spawner s in spawners)
            {
                s.Spawn();
            }
        }
    }
}
