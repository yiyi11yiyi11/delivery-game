using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene("Map");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
