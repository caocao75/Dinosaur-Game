using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    private void Start()
    {

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainGame");
    }
}
