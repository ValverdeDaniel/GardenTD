using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    public void OnMouseDown()
    {

        SpawnDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //creating screen to world point so it clicks on the grid
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        //remove this to place them anywhere and remove SnapToGrid
        Vector2 gridPos = SnapToGrid(worldPos);
        //change this to worldPos to place them anywhere
        return gridPos;
    }

    //remove SnapToGrid if you wanna place them anywhere
    private Vector2 SnapToGrid(Vector2 roundedPos)
    {
        float newX = Mathf.RoundToInt(roundedPos.x);
        float newY = Mathf.RoundToInt(roundedPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
    }
}
