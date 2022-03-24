using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc/* : IReUseClass*/
{
    private int _id;
    public Npc(int id)
    {
        _id = id;
    }

    public void Recycle()
    {
        Debug.LogError("Recycle:" + _id);
    }

    public void Release()
    {
        Debug.LogError("Release:" + _id);
    }

    public void Spawn()
    {
        Debug.LogError("Spawn:" + _id);
    }
}
