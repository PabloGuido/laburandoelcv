using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSInputManager : MonoBehaviour
{
    public static GSInputManager Instance;
    public bool playerInputAllowed = true;

    private void Awake()
    {
        // Ver de chequear que haya uno solo. creo que no haría falta porque este script no persiste entre escenas.
        Instance = this;
    }

}
