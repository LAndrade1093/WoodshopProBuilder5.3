using UnityEngine;
using System.Collections;

/*NOTES:
 * Just messing around with the Animator class, ignore this or delete
 */

public class TestRotate : MonoBehaviour
{
    private Animator AnimationController;

    private int Anim = Animator.StringToHash("Base Layer.TestTrigger");

    void Start()
    {
        AnimationController = GetComponent<Animator>();
    }

    public void Play()
    {
        Debug.Log("Play");
        AnimationController.Play("TestTrigger", -1, 0f);
    }
}
