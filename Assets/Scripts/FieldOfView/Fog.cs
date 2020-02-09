using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private GameObject fog;

    private SpriteRenderer fogsp;

    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        fogsp = fog.GetComponent<SpriteRenderer>();
        alpha = 0.9f;
        fogsp.color = new Color(fogsp.color.r, fogsp.color.g, fogsp.color.b, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        FlipFog();
    }

    public void FlipFog()
    {
        if (Input.GetKeyUp(KeyCode.F)) {
            SetColor();
        }
    }

    public void SetColor()
    {
        alpha = (alpha == 0f) ? 0.9f : 0f;
        fogsp.color = new Color(fogsp.color.r, fogsp.color.g, fogsp.color.b, alpha);
    }
}
