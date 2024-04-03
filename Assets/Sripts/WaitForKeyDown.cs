using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForKeyDown : CustomYieldInstruction
{
    private KeyCode key;
    public override bool keepWaiting 
    {
        get
        {
            return !Input.GetKeyDown(key);
        }
    }

    public WaitForKeyDown(KeyCode key)
    {
        this.key = key;
    }

}
