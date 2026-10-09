using UnityEngine;

public class TrashTypeButton : MonoBehaviour
{
    [SerializeField] private PlayerBinController playerBinController;
    [SerializeField] private TrashType type;

    public void SelectType()
    {
        playerBinController.SetTrashType(type);
    }
}
