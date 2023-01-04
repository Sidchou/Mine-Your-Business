using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface ITargetable 
{
    public float lifeTime { get; set; }

    public float spawnTime { get; set; }
    public void OnClick();
    public void OnTimeOut();
}
