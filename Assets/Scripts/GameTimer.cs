using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float ElapsedTime { get; private set; }

    private void Update()
    {
        ElapsedTime += Time.deltaTime;
    }
}