using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    static List<Selectable> selectables = new List<Selectable>();
    public string nickname;

    [HideInInspector]
    public string displayName;
    void Start()
    {
        displayName = RegisterSelectable(this);
    }

    string RegisterSelectable(Selectable newSelectable)
    {
        selectables.Add(newSelectable);
        return newSelectable.nickname + " " + selectables.FindAll(selectable => selectable.nickname == newSelectable.nickname).Count.ToString();
    }

}
