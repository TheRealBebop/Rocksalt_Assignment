using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    //[SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject room;
    [SerializeField] GameObject shop;
    [SerializeField] TextMeshProUGUI playerScoreText;
    public int playerScore = 0;

    // Start is called before the first frame update
    //Transform room;
    void Start()
    {
        playerScore = 0;
    }

    private void Awake()
    {
        int num = Object.FindObjectsOfType<GameSession>().Length;
        if (num > 1)
        {
            Object.Destroy(base.gameObject);
        }
        else
        {
            Object.DontDestroyOnLoad(base.gameObject);
        }
    }

    
    public void DisableRoomStuff()
    {
        /*
        room = transform.Find("Room");
        room.gameObject.SetActive(false);
        */
        room.SetActive(false);
        shop.SetActive(false);
    }

    public void EnableRoomStuff()
    {
        /*
        room = transform.Find("Room");
        room.gameObject.SetActive(true);
        */
        room.SetActive(true);
        shop.SetActive(true);
    }

    public void DisplayScore(int currentPrize)
    {
        playerScore += currentPrize;
        playerScoreText.text = "$" + playerScore.ToString();
    }

    public void DisplayBalance(int itemValue)
    {
        playerScore -= itemValue;
        playerScoreText.text = "$" + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
