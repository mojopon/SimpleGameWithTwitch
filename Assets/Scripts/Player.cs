using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMesh NameTextMesh;

    private MeshRenderer meshRenderer;
    private List<Color> colorList = new List<Color>()
    {
        Color.white,
        Color.red,
        Color.yellow,
        Color.green,
        Color.blue,
        Color.cyan,
        Color.magenta,
    };
    private int currentColor = 0;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetPlayerName(string playerName) 
    {
        NameTextMesh.text = playerName;
    }

    [ContextMenu("Change Player Color")]
    public void ChangePlayerColor() 
    {
        currentColor++;
        if (currentColor >= colorList.Count) 
        {
            currentColor = 0;
        }

        meshRenderer.material.color = colorList[currentColor];
    }
}
