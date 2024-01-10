using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrizeDistributor : MonoBehaviour
{
    int cherryCount, barCount, grapeCount, bellCount, sevenCount;
    public int[] iconCount = new int[5];
    public int[] prizeValues = new int[5];
    public int iconsCounted;

    GameSession gameSession;
    [SerializeField] TextMeshProUGUI currentPrize;

    [SerializeField] int currentScore;
    [SerializeField] int totalScore;

    [SerializeField] GameObject jackpotCanvas;

    // Start is called before the first frame update
    void Start()
    {
        currentPrize.enabled = false;
        jackpotCanvas.SetActive(false);
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreCalculator()
    {
        currentScore = 0;
        for (int i = 0; i < iconCount.Length; i++)
        {
            if (iconCount[i] == 1)
            {
                currentScore += prizeValues[i];
            }
            if (iconCount[i] == 2)
            {
                currentScore += 2 * (prizeValues[i] + prizeValues[i]);
            }
            if (iconCount[i] == 3)
            {
                currentScore += 3 * (prizeValues[i] + prizeValues[i] + prizeValues[i]);
                StartCoroutine(DisplayJackpot());
                //Call jackpot display function
            }
        }
        StartCoroutine("DisplayCurrentPrize");
        //Display current score canvas function
        gameSession.DisplayScore(currentScore);
        for (int i = 0; i < iconCount.Length; i++)
        {
            iconCount[i] = 0;
        }
    }

    IEnumerator DisplayJackpot()
    {
        jackpotCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        jackpotCanvas.SetActive(false);
    }

    IEnumerator DisplayCurrentPrize()
    {
        currentPrize.enabled = true;
        currentPrize.text = "+ $" + currentScore.ToString();
        yield return new WaitForSeconds(1.5f);
        currentPrize.enabled = false;
    }

    public void IconCounter(string x)
    {
        Debug.Log("Calculating...");
        switch (x)
        {
            case ("cherry"):
                cherryCount++;
                iconCount[0]++;
                break;
            case ("bar"):
                barCount++;
                iconCount[1]++;
                break;
            case ("grape"):
                grapeCount++;
                iconCount[2]++;
                break;
            case ("bell"):
                bellCount++;
                iconCount[3]++;
                break;
            case ("7"):
                sevenCount++;
                iconCount[4]++;
                break;
            default: break;
        }
        iconsCounted++;
        if(iconsCounted == 3)
        {
            Debug.Log("The score is: " + "\ncherry : " + cherryCount + " seven : " + sevenCount + " bar : " + barCount + " grape : " + grapeCount + " bell : " + bellCount);
            ScoreCalculator();
            //cherryCount = 0; barCount = 0; grapeCount = 0; bellCount = 0; sevenCount = 0;
        }
    }
}
