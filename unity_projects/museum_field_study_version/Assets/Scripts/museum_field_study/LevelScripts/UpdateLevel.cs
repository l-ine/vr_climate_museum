using UnityEngine;

public class UpdateLevel : MonoBehaviour
{
    public int level;

    void Start()
    {
        LevelHandler.currentLevel = 0;
    }

    void OnTriggerEnter()
    {
        if (this.level == 1)
        {
            LevelHandler.currentLevel = 1;
            Debug.Log("UpdateLevel: Level updated to " + LevelHandler.currentLevel);
        }
        else if (this.level == 2)
        {
            LevelHandler.currentLevel = 2;
            Debug.Log("UpdateLevel: Level updated to " + LevelHandler.currentLevel);
        }
        else if (this.level == 3)
        {
            LevelHandler.currentLevel = 3;
            Debug.Log("UpdateLevel: Level updated to " + LevelHandler.currentLevel);
        }
    }
}
