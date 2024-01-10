using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheSceneManager : MonoBehaviour
{
    GameSession gameSession;
    SceneTransition transition;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        transition = FindObjectOfType<SceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom()
    {
        transition.EndTransition();
        gameSession.EnableRoomStuff();
        SceneManager.LoadSceneAsync(0);
        transition.StartTransition();
        Debug.Log("ENABLING");
    }

    public void GoToSlots()
    {
        transition.EndTransition();
        gameSession.DisableRoomStuff();
        SceneManager.LoadSceneAsync(1);
        transition.StartTransition();
        Debug.Log("ENABLING");
    }
}
