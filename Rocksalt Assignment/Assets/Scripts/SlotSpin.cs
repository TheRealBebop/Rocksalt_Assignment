using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSpin : MonoBehaviour
{
    [SerializeField] float rotations;
    public bool isSpinning = false;
    public bool spun = false;
    public bool iconIsSet = false;
    public float speed = 1f;
    public float[] iconPositions = { -0.3f, -1.3f, -2.3f, -3.3f, -4.3f };
    public float finalPos;

    Animation anim;
    [SerializeField] PrizeFinder prizeFinder;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void FastSpin()
    {
        StartCoroutine("Spin");
    }

    public IEnumerator Spin()
    {
        iconIsSet = false;
        anim.Play();
        isSpinning = true;
        //Debug.Log("<color=yellow> SPINNING </color>");
        yield return new WaitForSeconds(2 * rotations);
        anim.Stop();
        //Debug.Log("<color=orange> DONE SPINNING </color>");
        isSpinning = false;
        spun = true;
        SetValue();
    }

    public void SetValue()
    {
        finalPos = iconPositions[Random.Range(0, iconPositions.Length)];
        Vector2 newPos = new Vector2 (transform.position.x, finalPos);

        if (!isSpinning && spun)
        {
            //transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime * speed);
            transform.position = newPos * speed;
            spun = false;
            iconIsSet = true;
        }
        //prizeFinder.PrintList();
    }
}
