using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    private EditTile _EditTile;

    public Tilemap _OrignMap;
    public Tilemap _ChangedDisplayMap;
    public Grid _Grid;

    public UIController UIController;

    public TileBase _Tile;
    public List<Vector3Int> OriginTilePos;
    public List<Vector3Int> ChangedTilePos;

    public bool isEdits = false;

    Vector3Int ClickPos;

    public void _Start()
    {
        _EditTile = GetComponent<EditTile>();
        _Grid = _OrignMap.layoutGrid;
        _ChangedDisplayMap = _Grid.transform.GetChild(0).GetComponent<Tilemap>();
        foreach(Vector3Int pos in OriginTilePos)
        {
            Debug.Log(pos);
            _OrignMap.SetTile(pos, _Tile);
        }
    }
    public void StartEdit()
    {
        isEdits = true;
        StartCoroutine(Edits());
    }
    
    public IEnumerator Edits()
    {
        while (isEdits)
        {
            yield return new WaitForFixedUpdate();
            if (Input.GetMouseButtonDown(0))
            {
                ClickPos = _Grid.WorldToCell(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y)));
                ChangedTilePos = _EditTile.TileExistPos(_ChangedDisplayMap);

                if (_EditTile.isEditLand) PlaceTile(_Tile);
                else CheckPlaceObj();
            }
        }
        UIController.UIOn(5);
    }

    public void CheckPlaceObj()
    {
        List<Vector3Int> LandExistPos = _EditTile.LandPos;
        Debug.Log(LandExistPos);
        foreach(Vector3Int pos in LandExistPos)
        {
            Debug.Log($"{pos} / {ClickPos}");
            if (pos.x*7 +5 < ClickPos.x && ClickPos.x < pos.x*7 +11
                && pos.y*7 +5 < ClickPos.y && ClickPos.y < pos.y*7 +11)
            {
                PlaceTile(_Tile);
                return;
            }
        }
        Debug.Log("Out of range");
    }

    public void PlaceTile(TileBase tile)
    {

        if (!isSamePos(OriginTilePos, ClickPos)) 
        {
            if (!isSamePos(ChangedTilePos, ClickPos)) 
            {
                _ChangedDisplayMap.SetTile(ClickPos, tile);
            }
            else 
            {
                OriginTilePos.Add(ClickPos); 
                _OrignMap.SetTile(ClickPos, tile);
                isEdits = false;

            }
            foreach (Vector3Int pos in ChangedTilePos)
                _ChangedDisplayMap.SetTile(pos, null);
        }
        else Debug.Log("is already exist");
    }

    private bool isSamePos(List<Vector3Int> T, Vector3Int tPos)
    {
        foreach(Vector3Int pos in T)
        {
            if (pos.Equals(tPos))
            {
                return true;
            }
        }
        return false;
    }
}
