using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] choices;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn()
    {
        int c = Random.Range(0, choices.Length + 1);

        if (c != choices.Length)
        {
            Instantiate(choices[c], transform.position, Quaternion.identity);
        }
    }
}
