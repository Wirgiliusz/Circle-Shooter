using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTextMesh : MonoBehaviour
{
    TextMesh tm;
    int combo;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        tm = GetComponent<TextMesh>();
        tm.text = "x" + (GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().combo).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, tm.color.a - 0.01f);
        if(tm.color.a<=0) {
            Destroy(gameObject);
        }
    }
}
