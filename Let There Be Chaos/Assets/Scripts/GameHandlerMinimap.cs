using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Minimap;

public class GameHandlerMinimap : MonoBehaviour
{
    [SerializeField] private MinimapIcon playerMinimapIcon;
    // Start is called before the first frame update
    private void Start()
    {
        MinimapClass.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            MinimapClass.ZoomIn();
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            MinimapClass.ZoomOut();
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            MinimapWindow.Show();
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            MinimapWindow.Hide();
        }
    }
}
