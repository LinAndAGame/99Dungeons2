﻿using System.Collections.Generic;
using NewRole;
using UnityEngine;

namespace Player {
    [CreateAssetMenu(fileName = "玩家数据", menuName = "纯数据资源/Player")]
    public class AssetData_Player : ScriptableObject {
        public List<AssetData_Role>      AllTeamRoles;
    }
}