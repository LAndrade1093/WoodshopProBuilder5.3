using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// A data container for the animation used in the tutorials
/// </summary>
[System.Serializable]
public class GestureController : MonoBehaviour
{
    public string AnimationName;

    private Animator _controller;
    private int _animHash;

    public Animator Controller
    {
        get { return _controller; }
        private set { _controller = value; }
    }

    public int AnimationHash
    {
        get { return _animHash; }
        private set { _animHash = value; }
    }

    void Awake()
    {
        AnimationHash = Animator.StringToHash(AnimationName);
        Controller = GetComponent<Animator>();
    }
}
