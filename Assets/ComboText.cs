using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour
{
    Text combo;

    // Start is called before the first frame update
    void Start()
    {
        combo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        combo.text = "x" + GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().combo.ToString();        
    }
}
