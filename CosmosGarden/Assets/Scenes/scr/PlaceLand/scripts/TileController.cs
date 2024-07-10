using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    private EditTile _EditTile;

    public Tilemap _OrignMap;
    public Tilemap _ChangedDisplayMap;
    public Grid _Grid;

    public TileBase _Tile;
    public List<Vector3Int> OriginTilePos;
    public List<Vector3Int> ChangedTilePos;

    Vector3Int ClickPos;

    public void Start()
    {
        _EditTile = GetComponent<EditTile>();
        _Grid = _OrignMap.layoutGrid;
        _ChangedDisplayMap = _Grid.transform.GetChild(0).GetComponent<Tilemap>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickPos = _Grid.WorldToCell(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y)));
            ChangedTilePos = _EditTile.TileExistPos(_ChangedDisplayMap);
            Debug.Log(ClickPos);
        PlaceLand(_Tile);
            
        }
    }

    public void PlaceLand(TileBase tile)
    {

        if (!isSamePos(OriginTilePos, ClickPos)) //1ÀÌ¶û ¾È°ãÄ§ 
        {
            if (!isSamePos(ChangedTilePos, ClickPos)) //2 ¾È°ãÄ§
            {
                _ChangedDisplayMap.SetTile(ClickPos, tile);
            }
            else //2 °ãÄ§
            {
                OriginTilePos.Add(ClickPos); 
                _OrignMap.SetTile(ClickPos, tile);

            }
            foreach (Vector3Int pos in ChangedTilePos)
                _ChangedDisplayMap.SetTile(pos, null);
        }
        else Debug.Log("is already exist"); //°ãÄ§
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
