using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnds : MonoBehaviour
{
    public enum GAMEEND_REASON
    {
        HIT_PPL,
        HIT_CAR,
        NORMAL,
    }
    public GameObject GameEndUI;
    public GameObject fading;
    private bool isEnd;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd)
        {
            Color co = fading.GetComponent<Image>().color;
            co.a += Time.deltaTime/2;
            fading.GetComponent<Image>().color = co;
        }
    }

    IEnumerator restartGame(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Map");
    }

    public void HandleGameEnds(GAMEEND_REASON reason)
    {
        isEnd = true;
        switch (reason)
        {
            case GAMEEND_REASON.HIT_PPL:
                GameEndUI.SetActive(true);
                GameEndUI.GetComponent<Text>().text = "YOU HIT SOMEONE, BE CARE....";
                break;
            case GAMEEND_REASON.HIT_CAR:
                GameEndUI.SetActive(true);
                GameEndUI.GetComponent<Text>().text = "YOU GOT HIT BY CAR";
                break;
            default:
                GameEndUI.SetActive(true);
                GameEndUI.GetComponent<Text>().text = "YOU WIN";
                break;
        }
        StartCoroutine(restartGame(3));

    }
}
