using System.Collections.Generic;
using UnityEngine;

public enum TrashType
{
    Paper,
    Plastic,
    Glass,
    Metal,
    Organic,
}

[System.Serializable]
public struct TrashData
{
    public TrashType trashType;
    public Color color;
    public Sprite binSprite;
}

[CreateAssetMenu(fileName = "TrashConfig", menuName = "Game/Trash Config")]
public class TrashConfig : ScriptableObject
{
    [SerializeField] private List<TrashData> trashColors;

    public Sprite GetBinSpriteForType(TrashType type)
    {
        foreach (var data in trashColors)
        {
            if (data.trashType == type)
                return data.binSprite;
        }

        return null;
    }

    public Color GetColorForType(TrashType type)
    {
        foreach (var data in trashColors)
        {
            if (data.trashType == type)
                return data.color;
        }

        return Color.white;
    }
}
