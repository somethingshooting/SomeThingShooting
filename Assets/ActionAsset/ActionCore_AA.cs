using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCore_AA : MonoBehaviour {
    [SerializeField]
    protected string _ActionName;
    protected int _ActionHash;

    protected ActionManager_AA _Manager;
    // Use this for initialization
    public virtual void Start()
    {
        _ActionHash = Animator.StringToHash(_ActionName);
        _Manager = GetComponent<ActionManager_AA>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (_Manager.CurrentActionHash == _ActionHash)
        {

        }
    }
}
