using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_AA : ActionSet_AA
{
    [SerializeField]
    private float _Speed = 1.0f;

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
        transform.Translate(direction * _Speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.0f,7.0f), 0, Mathf.Clamp(transform.position.z, -1.0f, 12));
    }
}
