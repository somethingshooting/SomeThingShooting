using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSet_AA : MonoBehaviour {
    [SerializeField]
    protected string[] _ActionNames;
    protected int[] _ActionHashs;

    protected ActionManager_AA _Manager;
    // Use this for initialization
    public virtual void Start()
    {
        _ActionHashs = new int[_ActionNames.Length];
        for (int i = 0; i < _ActionNames.Length; i++)
        {
            _ActionHashs[i]= Animator.StringToHash(_ActionNames[i]);
        }
        _Manager = GetComponent<ActionManager_AA>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        for (int i = 0; i < _ActionNames.Length; i++)
        {
            if (_Manager.CurrentActionHash == _ActionHashs[i])
            {

            }
        }
  
    }
}
