using UnityEngine;

public class RandomLevelFish
{
    public int GetRandomLevel()
    {
        while (true)
        {
            int level = Random.Range(0, 65);
            
            if(level == 1 || level == 2 || level == 4 || level == 8 || level == 16 || level == 32 || level == 64) 
                return level;
        }
    }
}
