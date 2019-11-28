using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ActionManager_AA : MonoBehaviour {
    

    public int CurrentActionHash;
    [SerializeField]
    private Animator _Animator;


    public int Lever { get; private set ; }
    //public int Button { get; private set; }
    private IntReactiveProperty _ButtonProperty = new IntReactiveProperty(0);
    public IReadOnlyReactiveProperty<int> ButtonProperty => _ButtonProperty;
    public int Command { get; private set; }
    public int Frame { get; private set; }
    public float Hight { get; private set; }
    public Vector2 Speed { get; private set; }

    [SerializeField]
    private bool _UseCommandSystem;
    private Vector2 _Position;
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Animator>() != null)
        {
            _Animator = GetComponent<Animator>();
        }
        else
        {
            _Animator = GetComponentInChildren<Animator>();
        }
        if (_UseCommandSystem)
        {
            StartReadingCommand();
        }
    }

    private void Update()
    {
        if (!_UseCommandSystem)
        {
            int vertical = 4, horizontal = 2;
            if (Input.GetKey(Up))
            {
                vertical = 7;
            }
            else if (Input.GetKey(Down))
            {
                vertical = 1;
            }
            if (Input.GetKey(Right))
            {
                if (Input.GetKey(Left))
                {
                }
                else
                {
                    horizontal = 3;
                }
            }
            else
            {
                if (Input.GetKey(Left))
                {
                    horizontal = 1;
                }
            }

            Lever = vertical + horizontal - 1;
            int button = 0;
            //fire
            if (Input.GetKey(Abutton))
            {
                button = 1;
            }
            if (Input.GetKey(Bbutton))
            {
                button = 2;
            }
            if (Input.GetKey(Cbutton))
            {
                button = 3;
            }
            if (Input.GetKey(Dbutton))
            {
                button = 4;
            }
            if (Input.GetKey(Ebutton))
            {
                button = 5;
            }
            _ButtonProperty.Value = button;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Hight = transform.position.y;
        Speed = new Vector2(transform.position.x, transform.position.y) - _Position;
        _Position = new Vector2(transform.position.x, transform.position.y);

        if (!_UseCommandSystem)
        {
            _Animator.SetInteger("lever", Lever);
            _Animator.SetInteger("button", _ButtonProperty.Value);
        }
        _Animator.SetFloat("Xspeed", Speed.x);
        _Animator.SetFloat("Yspeed", Speed.y);
        _Animator.SetFloat("hight", Hight);
        _Animator.SetInteger("frame", Frame);
        LateFixedUpdate();
    }

    private void LateFixedUpdate()
    {
        if (_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash != CurrentActionHash)
        {
            CurrentActionHash = _Animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
            Frame = 0;
        }
        Frame++;
    }
    
    public string inputCommands = "";
    bool commandEnable = true;

    public int recCommandLength = 100;

    [SerializeField]
    public string Up, Down, Left, Right;
    public string Abutton, Bbutton, Cbutton, Dbutton, Ebutton;
    // Use this for initialization
    private void StartReadingCommand()
    {
        inputCommands = inputCommands.PadLeft(100);
        StartCoroutine("commandInputControl");
    }

    IEnumerator commandInputControl()
    {

        while (true)
        {
            //Axis
            if (commandEnable)
            {
                getBaseMove();
                getBaseAttack();

                _Animator.SetInteger("lever", Lever);
                _Animator.SetInteger("button", _ButtonProperty.Value);
                _Animator.SetInteger("command", GetCommand());
              //  Debug.Log(GetCommand());
            }
            else
            {
                inputCommands += " ";
            }


            yield return null;
        }//end While
    }

    void getBaseMove()
    {
        int vertical = 4, horizontal = 2;
        if (Input.GetKey(Up))
        {
            vertical = 7;
        }
        else if (Input.GetKey(Down))
        {
            vertical = 1;
        }
        if (Input.GetKey(Right))
        {
            if (Input.GetKey(Left))
            {
            }
            else
            {
                horizontal = 3;
            }
        }
        else
        {
            if (Input.GetKey(Left))
            {
                horizontal = 1;
            }
        }

        Lever = vertical + horizontal - 1;
        inputCommands += Lever.ToString();

        if (inputCommands.Length > recCommandLength)
        {
            inputCommands = inputCommands.Remove(0, 1);
        }

    }
    void getBaseAttack()
    {
        //fire
        if (Input.GetKeyDown(Abutton) || Input.GetKeyUp(Abutton))
        {
            inputCommands += "A";
        }
        if (Input.GetKeyDown(Bbutton) || Input.GetKeyUp(Bbutton))
        {
            inputCommands += "B";
        }
        if (Input.GetKeyDown(Cbutton) || Input.GetKeyUp(Cbutton))
        {
            inputCommands += "C";
        }
        if (Input.GetKeyDown(Dbutton) || Input.GetKeyUp(Dbutton))
        {
            inputCommands += "D";
        }
        if (Input.GetKeyDown(Ebutton)||Input.GetKeyUp(Ebutton))
        {
            inputCommands += "E";
        }
        int button = 0;
        //fire
        if (Input.GetKey(Abutton))
        {
            inputCommands += "a";
            button = 1;
        }
        if (Input.GetKey(Bbutton))
        {
            inputCommands += "b";
            button = 2;
        }
        if (Input.GetKey(Cbutton))
        {
            inputCommands += "c";
            button = 3;
        }
        if (Input.GetKey(Dbutton))
        {
            inputCommands += "d";
            button = 4;
        }
        if (Input.GetKey(Ebutton))
        {
            inputCommands += "e";
            button = 5;
        }
        _ButtonProperty.Value = button;

        if (inputCommands.Length > recCommandLength)
        {
            inputCommands = inputCommands.Remove(0, 1);
        }
    }

    public int GetCommand()
    {
        int commandID = 0;
        string checkframe;
        int newpriority = 0;
        if (inputCommands.Length <= 10)
        {
            return 0;
        }

      
        for (int i = 0; i < _Commands.Length; i++)
        {
            if (newpriority<_Commands[i]._Priority)
            {
                checkframe = inputCommands.Remove(0, recCommandLength - _Commands[i]._InputLength);
                if (Regex.IsMatch(checkframe, _Commands[i]._LeftCommand))
                {
                    commandID = _Commands[i]._LeftCommandID;
                    newpriority = _Commands[i]._Priority;
                }
                if (Regex.IsMatch(checkframe, _Commands[i]._RightCommand))
                {
                    commandID = _Commands[i]._RightCommandID;
                    newpriority = _Commands[i]._Priority;
                }
            }
        }
        
        return commandID;
    }

    public CommandData[] _Commands;
    [Serializable]
    public class CommandData
    {
        [SerializeField]
        public string _Name;// { get; private set; }
        [SerializeField]
        public int _LeftCommandID;// { get; private set; }
        [SerializeField]
        public string _LeftCommand;// { get; private set; }
        [SerializeField]
        public int _RightCommandID;// { get; private set; }
        [SerializeField]
        public string _RightCommand;// { get; private set; }
        [SerializeField]
        public int _InputLength;// { get; private set; }
        [SerializeField]
        public int _Priority;// { get; private set; }
    }
}
