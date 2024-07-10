using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class TileController : MonoBehaviour
{
    //public Vector3Int dataOnTiles;
    [SerializeField] public Tilemap _TileMap;
    [SerializeField] public Tilemap _PlaceTileMap;
    [SerializeField] public Grid _Grid;
    //[SerializeField] public Grid _PlaceGrid;
    public TileBase _Tile;
    public List<Vector3Int> LandTile;
    public List<Vector3Int> LandPlaceTile;

    Vector3Int ClickPos;

    public void Start()
    {
        LandTile = isTileExist(_TileMap);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickPos = _Grid.WorldToCell(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y)));
            LandPlaceTile = isTileExist(_PlaceTileMap);
            PlaceLand(_Tile);
        }
    }

    public void PlaceLand(TileBase tile)
    {

        if (!isSamePos(LandTile, ClickPos)) //1ÀÌ¶û ¾È°ãÄ§ 
        {
            if (!isSamePos(LandPlaceTile, ClickPos)) //2 ¾È°ãÄ§
            {
                _PlaceTileMap.SetTile(ClickPos, tile);
            }
            else //2 °ãÄ§
            {
                LandTile.Add(ClickPos);
                SetTileM(tile);
            }
            foreach (Vector3Int pos in LandPlaceTile)
                _PlaceTileMap.SetTile(pos, null);
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

    public void SetTileM(TileBase tile)
    {
        //LandTile.Sort();
        foreach (Vector3Int pos in LandTile)
            _TileMap.SetTile(pos, tile);
    }

    public List<Vector3Int> isTileExist(Tilemap tilemap)
    {
        List<Vector3Int> tileExist = new List<Vector3Int>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if(tilemap.GetTile(pos) !=  null)
            {
                tileExist.Add(pos);
            }
        }
        return tileExist;
    }


}
