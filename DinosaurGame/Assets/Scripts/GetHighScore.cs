using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = ("  High Score : " + PlayerPrefs.GetInt("HighScore"));
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }
}
