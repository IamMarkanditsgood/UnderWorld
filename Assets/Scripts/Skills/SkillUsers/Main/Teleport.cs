using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, ISkillUsable
{
    public void UseSkill()
    {
        Debug.Log("Teleport");
    }
}
