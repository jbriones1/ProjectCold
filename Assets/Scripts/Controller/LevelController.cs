using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int currSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.anyKey && currSceneIndex == 0)
        {
            SceneManager.LoadScene(currSceneIndex + 1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
