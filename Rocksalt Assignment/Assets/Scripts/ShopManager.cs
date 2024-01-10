using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public bool purchased = false;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] int itemCost;
    [SerializeField] GameObject item;
    [SerializeField] GameObject poorPanel;

    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        costText.text = "$" + itemCost.ToString();
        gameSession = FindObjectOfType<GameSession>();
        poorPanel.SetActive(false);
    }

    public void Purchase()
    {
        if(!purchased)
        {
            if(gameSession.playerScore < itemCost)
            {
                //display not enough money text
                StartCoroutine(DisplayPoorCanvas());
                item.SetActive(false);
            }
            else
            {
                item.SetActive(true);
                purchased = true;
                gameSession.DisplayBalance(itemCost);
            }
        }
    }

    IEnumerator DisplayPoorCanvas()
    {
        poorPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        poorPanel.SetActive(false);
    }
}
