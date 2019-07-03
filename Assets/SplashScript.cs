using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScript : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite splash1;
    public Sprite splash2;
    public Sprite splash3;

    int spriteChoice = 0;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        spriteChoice = Random.Range(1,4);
        switch(spriteChoice) {
            case 1:
            sr.sprite = splash1;
            break;

            case 2:
            sr.sprite = splash2;
            break;

            case 3:
            sr.sprite = splash3;
            break;
        }

        size = Random.Range(4,6);
        transform.localScale = new Vector3(size, size, 1);
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        transform.eulerAngles = euler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
