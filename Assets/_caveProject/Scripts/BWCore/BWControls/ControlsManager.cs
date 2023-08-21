using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to manage the controls of the game. This is where the switch is done between the different Action Maps.
/// </summary>
public class ControlsManager : MonoBehaviour
{
    public static CaveControls CaveControls;
    // Start is called before the first frame update
    void Awake()
    {
        CaveControls = new CaveControls();
        CaveControls.InGame.Enable();
    }
}
