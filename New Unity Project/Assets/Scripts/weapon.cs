﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weapon
{
    public GameObject player;
    public playerWeapon pw;

    public abstract void Init();
    public abstract void Fire();
}
