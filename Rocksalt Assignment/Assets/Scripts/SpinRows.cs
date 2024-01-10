using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

using Button = UnityEngine.UI.Button;

public class SpinRows : MonoBehaviour
{

    [SerializeField] GameObject firstRow;
    [SerializeField] GameObject secondRow;
    [SerializeField] GameObject thirdRow;

    SlotSpin spinFirstSlot;
    SlotSpin spinSecondSlot;
    SlotSpin spinThirdSlot;
    public Button spinButton;
    public Button goToRoomButton;
    PrizeDistributor distributor;

    // Start is called before the first frame update
    void Start()
    {
        spinFirstSlot = firstRow.GetComponent<SlotSpin>();
        spinSecondSlot = secondRow.GetComponent<SlotSpin>();
        spinThirdSlot = thirdRow.GetComponent<SlotSpin>();
        spinButton = GetComponent<Button>();
        distributor = FindObjectOfType<PrizeDistributor>();
    }

    public void SpinAllRows ()
    {
        distributor.iconsCounted = 0;
        spinFirstSlot.FastSpin();
        spinSecondSlot.FastSpin();
        spinThirdSlot.FastSpin();
    }

    private void Update()
    {
        if(spinFirstSlot.isSpinning || spinSecondSlot.isSpinning || spinThirdSlot.isSpinning)
        {
            spinButton.interactable = false;
            goToRoomButton.interactable = false;
        }
        else
        {
            spinButton.interactable = true;
            goToRoomButton.interactable= true;
        }
    }

}
