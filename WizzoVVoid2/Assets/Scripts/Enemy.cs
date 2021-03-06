﻿using UnityEngine;
using UnityEngine.Events;


[System.Serializable]

public class EnemySpawnedEvent : UnityEvent<Transform> { }
public class Enemy : MonoBehaviour
{
    public EnemySpawnedEvent onSpawn;

    private void Start()
    {
        GameObject WizzoPlayer = GameObject.FindWithTag("Player");
        onSpawn.Invoke(WizzoPlayer.transform);
    }
}
