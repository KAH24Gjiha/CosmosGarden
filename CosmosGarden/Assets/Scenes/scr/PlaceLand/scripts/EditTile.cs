using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EditTile : MonoBehaviour
{

    [SerializeField] public Tilemap LandMap;
    [SerializeField] public Tilemap ObjMap;
    [SerializeField] public Tile NewTile;

    public bool isEditLand;

    public List<Vector3Int> LandPos;
    public List<Vector3Int> ObjPos;

    void Start()
    {
        TileController _TileController = new TileController();
        LandPos = TileExistPos(LandMap);
        ObjPos = TileExistPos(ObjMap);

        _TileController._Tile = NewTile;
        if (isEditLand)
        {
            _TileController._OrignMap = LandMap;
            _TileController.OriginTilePos = LandPos;
        }
        else
        {
            _TileController._OrignMap = ObjMap;
            _TileController.OriginTilePos = ObjPos;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public List<Vector3Int> TileExistPos(Tilemap tilemap)
    {
        List<Vector3Int> tileExist = new List<Vector3Int>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.GetTile(pos) != null)
            {
                tileExist.Add(pos);
            }
        }
        return tileExist;
    }
}
