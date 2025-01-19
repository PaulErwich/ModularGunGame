using UnityEngine;
using System.Collections.Generic;

public class GunPartList : MonoBehaviour 
{
    GunParts gp = new GunParts();

    private void Awake()
    {
        gp.Awake();
    }
}

public enum partType
{ 
    BODY,
    MAG,
    BARREL,
    SCOPE,
    EXTRA
}

public enum ammoType
{
    PISTOL,
    SHOTGUN,
    RIFLE,
    SNIPER,
    SMG
}

public class gun
{
    public Dictionary<partType, part> parts = new Dictionary<partType, part>
    {
        { partType.BODY, new part() },
        { partType.MAG, new part() },
        { partType.BARREL, new part() },
        { partType.SCOPE, new part() },
        { partType.EXTRA, new part() }
    };

    public float damage;
    public float fire_rate;
    public float recoil;
    public float accuracy;
    public float move_speed;

    public ammoType ammo_type;
    public float bullet_count;
}

public class part
{
    //public Mesh mesh;

    public Dictionary<partType, Vector3> connection_points;         // Attachment points for the parts on the body
    public Vector3 shooting_point;                                  // Location on the barrel where the bullets will be instantiated

    public float damage;            // Damage
    public float fire_rate;         // Shots per second
    public float recoil;            // Degrees per shot
    public float accuracy;          // +/- Degrees off target
    public float move_speed;        // Speed

    public ammoType ammo_type;
    public float bullet_count;
}

class GunParts
{
    public List<gun> gunList = new List<gun>();

    public static GunParts instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        init();
    }

    public void init()
    {
        pistol();
        shotgun();
        rifle();
        sniper();
        smg();
    }

    void pistol()
    {
        gunList.Add(new gun());

        //gunList[0].parts[partType.BODY].mesh = ;
        gunList[0].parts[partType.BODY].connection_points = new Dictionary<partType, Vector3> { { partType.MAG, new Vector3(0, 0, 0) }, { partType.BARREL, new Vector3(0, 0, 0) }, { partType.SCOPE, new Vector3(0, 0, 0) } };
        gunList[0].parts[partType.BODY].damage = 5;
        gunList[0].parts[partType.BODY].fire_rate = 1;
        gunList[0].parts[partType.BODY].recoil = 2;
        gunList[0].parts[partType.BODY].accuracy = 3;
        gunList[0].parts[partType.BODY].move_speed = 3;

        gunList[0].parts[partType.MAG].damage = 0;
        gunList[0].parts[partType.MAG].fire_rate = 0.5f;
        gunList[0].parts[partType.MAG].recoil = -3;
        gunList[0].parts[partType.MAG].accuracy = -1;
        gunList[0].parts[partType.MAG].move_speed = 0;
        gunList[0].parts[partType.MAG].ammo_type = ammoType.PISTOL;
        gunList[0].parts[partType.MAG].bullet_count = 24;

        gunList[0].parts[partType.BARREL].shooting_point = new Vector3(0,0,0);
        gunList[0].parts[partType.BARREL].damage = 6;
        gunList[0].parts[partType.BARREL].fire_rate = 0.2f;
        gunList[0].parts[partType.BARREL].recoil = 5;
        gunList[0].parts[partType.BARREL].accuracy = 2;
        gunList[0].parts[partType.BARREL].move_speed = 0;

        gunList[0].parts[partType.SCOPE].damage = 2;
        gunList[0].parts[partType.SCOPE].fire_rate = 0;
        gunList[0].parts[partType.SCOPE].recoil = -3;
        gunList[0].parts[partType.SCOPE].accuracy = -3;
        gunList[0].parts[partType.SCOPE].move_speed = 2;

        gunList[0].parts[partType.EXTRA].damage = 2;
        gunList[0].parts[partType.EXTRA].fire_rate = -0.5f;
        gunList[0].parts[partType.EXTRA].recoil = 2;
        gunList[0].parts[partType.EXTRA].accuracy = 1;
        gunList[0].parts[partType.EXTRA].move_speed = 2;
        gunList[0].parts[partType.EXTRA].bullet_count = 10;
    }

    void shotgun()
    {
        gunList.Add(new gun());

        //gunList[1].parts[partType.BODY].mesh = ;
        gunList[1].parts[partType.BODY].connection_points = new Dictionary<partType, Vector3> { { partType.MAG, new Vector3(0, 0, 0) }, { partType.BARREL, new Vector3(0, 0, 0) }, { partType.SCOPE, new Vector3(0, 0, 0) } };
        gunList[1].parts[partType.BODY].damage = 5;
        gunList[1].parts[partType.BODY].fire_rate = 0.4f;
        gunList[1].parts[partType.BODY].recoil = 12;
        gunList[1].parts[partType.BODY].accuracy = 6;
        gunList[1].parts[partType.BODY].move_speed = -2;

        gunList[1].parts[partType.MAG].damage = -3;
        gunList[1].parts[partType.MAG].fire_rate = -0.3f;
        gunList[1].parts[partType.MAG].recoil = 6;
        gunList[1].parts[partType.MAG].accuracy = 12;
        gunList[1].parts[partType.MAG].move_speed = 1;
        gunList[1].parts[partType.MAG].ammo_type = ammoType.SHOTGUN;
        gunList[1].parts[partType.MAG].bullet_count = 20;

        gunList[1].parts[partType.BARREL].shooting_point = new Vector3(0, 0, 0);
        gunList[1].parts[partType.BARREL].damage = 1;
        gunList[1].parts[partType.BARREL].fire_rate = 0.2f;
        gunList[1].parts[partType.BARREL].recoil = 6;
        gunList[1].parts[partType.BARREL].accuracy = 8;
        gunList[1].parts[partType.BARREL].move_speed = 2;

        gunList[1].parts[partType.SCOPE].damage = 0;
        gunList[1].parts[partType.SCOPE].fire_rate = 0;
        gunList[1].parts[partType.SCOPE].recoil = -4;
        gunList[1].parts[partType.SCOPE].accuracy = -2;
        gunList[1].parts[partType.SCOPE].move_speed = 0;

        gunList[1].parts[partType.EXTRA].damage = -1;
        gunList[1].parts[partType.EXTRA].fire_rate = 0.3f;
        gunList[1].parts[partType.EXTRA].recoil = -2;
        gunList[1].parts[partType.EXTRA].accuracy = 0;
        gunList[1].parts[partType.EXTRA].move_speed = 2;
        gunList[1].parts[partType.EXTRA].bullet_count = 0;
    }

    void rifle()
    {
        gunList.Add(new gun());

        //gunList[2].parts[partType.BODY].mesh = ;
        gunList[2].parts[partType.BODY].connection_points = new Dictionary<partType, Vector3> { { partType.MAG, new Vector3(0, 0, 0) }, { partType.BARREL, new Vector3(0, 0, 0) }, { partType.SCOPE, new Vector3(0, 0, 0) } };
        gunList[2].parts[partType.BODY].damage = 6;
        gunList[2].parts[partType.BODY].fire_rate = 1.2f;
        gunList[2].parts[partType.BODY].recoil = 3;
        gunList[2].parts[partType.BODY].accuracy = -2;
        gunList[2].parts[partType.BODY].move_speed = -1;

        gunList[2].parts[partType.MAG].damage = 4;
        gunList[2].parts[partType.MAG].fire_rate = 0.3f;
        gunList[2].parts[partType.MAG].recoil = 1;
        gunList[2].parts[partType.MAG].accuracy = 1;
        gunList[2].parts[partType.MAG].move_speed = 0;
        gunList[2].parts[partType.MAG].ammo_type = ammoType.RIFLE;
        gunList[2].parts[partType.MAG].bullet_count = 45;

        gunList[2].parts[partType.BARREL].shooting_point = new Vector3(0, 0, 0);
        gunList[2].parts[partType.BARREL].damage = 2;
        gunList[2].parts[partType.BARREL].fire_rate = 2;
        gunList[2].parts[partType.BARREL].recoil = -1;
        gunList[2].parts[partType.BARREL].accuracy = 1;
        gunList[2].parts[partType.BARREL].move_speed = 0;

        gunList[2].parts[partType.SCOPE].damage = 0;
        gunList[2].parts[partType.SCOPE].fire_rate = 0;
        gunList[2].parts[partType.SCOPE].recoil = -2;
        gunList[2].parts[partType.SCOPE].accuracy = -2;
        gunList[2].parts[partType.SCOPE].move_speed = 2;

        gunList[2].parts[partType.EXTRA].damage = 0;
        gunList[2].parts[partType.EXTRA].fire_rate = 0;
        gunList[2].parts[partType.EXTRA].recoil = 1;
        gunList[2].parts[partType.EXTRA].accuracy = 3;
        gunList[2].parts[partType.EXTRA].move_speed = 1;
        gunList[2].parts[partType.EXTRA].bullet_count = 30;
    }

    void sniper()
    {
        gunList.Add(new gun());

        //gunList[3].parts[partType.BODY].mesh = ;
        gunList[3].parts[partType.BODY].connection_points = new Dictionary<partType, Vector3> { { partType.MAG, new Vector3(0, 0, 0) }, { partType.BARREL, new Vector3(0, 0, 0) }, { partType.SCOPE, new Vector3(0, 0, 0) } };
        gunList[3].parts[partType.BODY].damage = 50;
        gunList[3].parts[partType.BODY].fire_rate = 0.6f;
        gunList[3].parts[partType.BODY].recoil = 15;
        gunList[3].parts[partType.BODY].accuracy = -6;
        gunList[3].parts[partType.BODY].move_speed = -2;

        gunList[3].parts[partType.MAG].damage = 25;
        gunList[3].parts[partType.MAG].fire_rate = -0.3f;
        gunList[3].parts[partType.MAG].recoil = 10;
        gunList[3].parts[partType.MAG].accuracy = 6;
        gunList[3].parts[partType.MAG].move_speed = 0;
        gunList[3].parts[partType.MAG].ammo_type = ammoType.SNIPER;
        gunList[3].parts[partType.MAG].bullet_count = 15;

        gunList[3].parts[partType.BARREL].shooting_point = new Vector3(0, 0, 0);
        gunList[3].parts[partType.BARREL].damage = 0;
        gunList[3].parts[partType.BARREL].fire_rate = 0.1f;
        gunList[3].parts[partType.BARREL].recoil = 6;
        gunList[3].parts[partType.BARREL].accuracy = 8;
        gunList[3].parts[partType.BARREL].move_speed = 0;

        gunList[3].parts[partType.SCOPE].damage = 0;
        gunList[3].parts[partType.SCOPE].fire_rate = 0;
        gunList[3].parts[partType.SCOPE].recoil = -6;
        gunList[3].parts[partType.SCOPE].accuracy = -8;
        gunList[3].parts[partType.SCOPE].move_speed = 0;

        gunList[3].parts[partType.EXTRA].damage = 0;
        gunList[3].parts[partType.EXTRA].fire_rate = 0.3f;
        gunList[3].parts[partType.EXTRA].recoil = -3;
        gunList[3].parts[partType.EXTRA].accuracy = 0;
        gunList[3].parts[partType.EXTRA].move_speed = 3;
        gunList[3].parts[partType.EXTRA].bullet_count = 6;
    }

    void smg()
    {
        gunList.Add(new gun());

        //gunList[4].parts[partType.BODY].mesh = ;
        gunList[4].parts[partType.BODY].connection_points = new Dictionary<partType, Vector3> { { partType.MAG, new Vector3(0, 0, 0) }, { partType.BARREL, new Vector3(0, 0, 0) }, { partType.SCOPE, new Vector3(0, 0, 0) } };
        gunList[4].parts[partType.BODY].damage = 5;
        gunList[4].parts[partType.BODY].fire_rate = 5;
        gunList[4].parts[partType.BODY].recoil = 0;
        gunList[4].parts[partType.BODY].accuracy = 3;
        gunList[4].parts[partType.BODY].move_speed = 1;

        gunList[4].parts[partType.MAG].damage = 4;
        gunList[4].parts[partType.MAG].fire_rate = 3;
        gunList[4].parts[partType.MAG].recoil = 0;
        gunList[4].parts[partType.MAG].accuracy = 2;
        gunList[4].parts[partType.MAG].move_speed = 0;
        gunList[4].parts[partType.MAG].ammo_type = ammoType.SMG;
        gunList[4].parts[partType.MAG].bullet_count = 60;

        gunList[4].parts[partType.BARREL].shooting_point = new Vector3(0, 0, 0);
        gunList[4].parts[partType.BARREL].damage = -1;
        gunList[4].parts[partType.BARREL].fire_rate = 2;
        gunList[4].parts[partType.BARREL].recoil = 3;
        gunList[4].parts[partType.BARREL].accuracy = 2;
        gunList[4].parts[partType.BARREL].move_speed = 0;

        gunList[4].parts[partType.SCOPE].damage = 0;
        gunList[4].parts[partType.SCOPE].fire_rate = 0;
        gunList[4].parts[partType.SCOPE].recoil = -1;
        gunList[4].parts[partType.SCOPE].accuracy = -2;
        gunList[4].parts[partType.SCOPE].move_speed = 0;

        gunList[4].parts[partType.EXTRA].damage = 1;
        gunList[4].parts[partType.EXTRA].fire_rate = 0;
        gunList[4].parts[partType.EXTRA].recoil = 0;
        gunList[4].parts[partType.EXTRA].accuracy = 0;
        gunList[4].parts[partType.EXTRA].move_speed = 4;
        gunList[4].parts[partType.EXTRA].bullet_count = 60;
    }
}