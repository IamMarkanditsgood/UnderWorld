using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private PrefabContainer _prefabContainer;
    [SerializeField] private ObjectContainer _objectContainer;

    public PrefabContainer PrefabContainer { get; set; }
    public ObjectContainer ObjectContainer { get; set; }
}
