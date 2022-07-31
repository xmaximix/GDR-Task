using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    public static bool GetMouseButtonDown(int id)
    {
        if (Pause.paused)
        {
            return false;
        }

        return Input.GetMouseButtonDown(id);
    }
}
