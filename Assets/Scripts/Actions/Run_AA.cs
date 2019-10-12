using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_AA : ActionSet_AA
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        Vector3 direction = Vector3.zero;

        for (int i = 0; i < _ActionNames.Length; i++)
        {
            if (_Manager.CurrentActionHash == _ActionHashs[i])
            {
                switch (_Manager.Lever)
                {
                    case 1:
                        direction = new Vector3(-1, 0, -1);
                        break;
                    case 2:
                        direction = new Vector3(0, 0, -1);
                        break;
                    case 3:
                        direction = new Vector3(1, 0, -1);
                        break;
                    case 4:
                        direction = new Vector3(-1, 0, 0);
                        break;
                    case 6:
                        direction = new Vector3(1, 0, 0);
                        break;
                    case 7:
                        direction = new Vector3(-1, 0, 1);
                        break;
                    case 8:
                        direction = new Vector3(0, 0, 1);
                        break;
                    case 9:
                        direction = new Vector3(1, 0, 1);
                        break;
                    default:
                        break;
                }
            }
        }

        direction.Normalize();
        transform.Translate(direction * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, 12.5f), 0, Mathf.Clamp(transform.position.z, -7, 7));
    }
}
