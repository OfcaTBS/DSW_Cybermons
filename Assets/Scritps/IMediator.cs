using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMediator
{
    void Notify(GameObject _sender, string _event, string[] _args);
}
