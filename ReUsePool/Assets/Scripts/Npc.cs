using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReUsePool;

public class Npc : IReUse
{
    public int _id;
    public Npc(int id)
    {
        _id = id;
    }

    public void ReUseOverflowRelease()
    {
        Debug.LogError("Npc Release:" + _id);
    }

    public void Spawn()
    {
        Debug.LogError("Npc Spawn:" + _id);
    }

    public void UnSpawn()
    {
        Debug.LogError("Npc UnSpawn:" + _id);
    }
}


public class Player : IReUse
{
    public int _id;
    public Player(int id)
    {
        _id = id;
    }

    public void ReUseOverflowRelease()
    {
        Debug.LogError("Player Release:" + _id);
    }

    public void Spawn()
    {
        Debug.LogError("Player Spawn:" + _id);
    }

    public void UnSpawn()
    {
        Debug.LogError("Player UnSpawn:" + _id);
    }
}