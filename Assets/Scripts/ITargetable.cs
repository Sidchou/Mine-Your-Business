using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface ITargetable 
{
    public float lifeTime { get; }

    public float spawnTime { get; }
    public void OnClick();
    public void OnTimeOut();
}
