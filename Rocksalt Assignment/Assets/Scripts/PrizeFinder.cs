using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeFinder : MonoBehaviour
{
    [SerializeField] int iconCount = 0;
    [SerializeField] SlotSpin firstRow;
    [SerializeField] SlotSpin secondRow;
    [SerializeField] SlotSpin thirdRow;
    public float timer = 0f;
    PrizeDistributor distributor;

    string firstIcon;
    string secondIcon;
    string thirdIcon;

    //private List<string> icons = new List<string>();

    // Update is called once per frame
    public void Start()
    {
        distributor = FindObjectOfType<PrizeDistributor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (firstRow.iconIsSet && collision.gameObject.transform.parent.gameObject.CompareTag("First Row"))
        {
            firstIcon = collision.gameObject.tag;
            Debug.Log("<color=purple> The icon is: </color>" + firstIcon);
            distributor.IconCounter(firstIcon);
            iconCount++;
        }

        if (secondRow.iconIsSet && collision.gameObject.transform.parent.gameObject.CompareTag("Second Row"))
        {
            secondIcon = collision.gameObject.tag;
            Debug.Log("<color=purple> The icon is: </color>" + secondIcon);
            distributor.IconCounter(secondIcon);
            iconCount++;
        }

        if (thirdRow.iconIsSet && collision.gameObject.transform.parent.gameObject.CompareTag("Third Row"))
        {
            thirdIcon = collision.gameObject.tag;
            Debug.Log("<color=purple> The icon is: </color>" + thirdIcon);
            distributor.IconCounter(thirdIcon);
            iconCount++;
        }
        if(iconCount == 3)
        {
            //Score Calculator method
            iconCount = 0;
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        timer = 0f;
    }

    public void PrintList()
    {
        if (firstRow.iconIsSet && secondRow.iconIsSet && thirdRow.iconIsSet)
        {
            Debug.Log( "The icons are: " + icons[0] + " " + icons[1] + " " + icons[2]);
            int i = 0;
            while(i < icons.Count)
            {
                Debug.Log("<color = purple> ICON NAME: " + icons[i]);
            }
        }
    }
    */
}
