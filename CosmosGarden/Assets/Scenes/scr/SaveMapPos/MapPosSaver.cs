using System.Collections.Generic;
using UnityEngine;

public class MapPosSaver : MonoBehaviour
{
    private EditTile _EditTile;
    public GameData_t1 _MapSaveData;

    public List<Vector3Int> LandPosToSave;
    public List<Vector3Int> ObjPosToSave;

    public void SaveMapData()
    {
        _EditTile = GameObject.Find("SetObjManager").GetComponent<EditTile>();
        LandPosToSave = _EditTile.LandPos;
        ObjPosToSave = _EditTile.ObjPos;

        _MapSaveData = new GameData_t1();

        _MapSaveData.LandPosX = new int[LandPosToSave.Count];
        _MapSaveData.LandPosY = new int[LandPosToSave.Count];

        _MapSaveData.ObjPosX = new int[ObjPosToSave.Count];
        _MapSaveData.ObjPosY = new int[ObjPosToSave.Count];

        int i = 0;
        foreach (Vector3Int pos in LandPosToSave)
        {
            _MapSaveData.LandPosX[i] = pos.x;
            _MapSaveData.LandPosY[i] = pos.y;
            i++;
        }

        i = 0;
        foreach(Vector3Int pos in ObjPosToSave)
        {
            _MapSaveData.ObjPosX[i] = pos.x;
            _MapSaveData.ObjPosY[i] = pos.y;
            i++;
        }
    }
}