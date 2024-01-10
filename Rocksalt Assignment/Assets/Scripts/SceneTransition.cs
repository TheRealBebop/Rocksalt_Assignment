using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject transitionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transitionCanvas.SetActive(true);
    }

    public void StartTransition()
    {
        StartCoroutine(PlayStartTransition());
    }

    IEnumerator PlayStartTransition()
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(1f);
    }
    public void EndTransition()
    {
        StartCoroutine(PlayEndTransition());
    }

    IEnumerator PlayEndTransition()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
