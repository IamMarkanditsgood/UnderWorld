using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.Colors.Models;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SkillsScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject _skillSound;
}
