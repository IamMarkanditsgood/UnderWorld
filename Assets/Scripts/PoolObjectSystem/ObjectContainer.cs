using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemiesInUse = new List<GameObject>();
    [SerializeField] private List<GameObject> _freeEnemies = new List<GameObject>();

    public List<GameObject> EnemiesInUse { get; set; }
    public List<GameObject> FreeEnemies { get; set; }
}
