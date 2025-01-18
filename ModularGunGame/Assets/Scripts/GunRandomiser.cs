using NUnit.Framework;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class GunRandomiser : MonoBehaviour
{
    GunParts gunParts;

    public gun RequestGun()
    {
        gun generatedGun = new gun();
        return generatedGun;
    }

    private void RandomiseGun(gun generatedGun)
    {
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, 5);
            generatedGun.parts[(partType)i] = gunParts.gunList[random].parts[(partType)i];
        }
    }

    private void TotalStats(gun generatedGun)
    {
        foreach (part part in generatedGun.parts.Values)
        {
            generatedGun.damage += part.damage;
            generatedGun.fire_rate += part.fire_rate;
            generatedGun.recoil += part.recoil;
            generatedGun.accuracy += part.accuracy;
            generatedGun.move_speed += part.move_speed;
            generatedGun.bullet_count += part.bullet_count;
        }
        
        if (generatedGun.damage < 0)
        {
            generatedGun.damage = 1;
        }
        if (generatedGun.fire_rate < 0.5f)
        {
            generatedGun.fire_rate = 0.5f;
        }
        if (generatedGun.accuracy < 0)
        {
            generatedGun.accuracy = 0;
        }
    }

    private void CreatePrefab(gun generatedGun)
    {

    }
}
