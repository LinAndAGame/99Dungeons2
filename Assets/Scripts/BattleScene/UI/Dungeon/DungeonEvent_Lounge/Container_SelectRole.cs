using Player;
using Role;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_Lounge {
    public class Container_SelectRole : MonoBehaviour {
        public Button          BtnSelf;
        public Image           Img_Role;
        public TextMeshProUGUI TMP_RoleName;
        public Slider          Sld_Hp;
        public TextMeshProUGUI TMP_CurHp;
        public TextMeshProUGUI TMP_MaxHp;
        
        public void Init(Panel_Lounge panelLounge, SaveData_Role saveDataRole) {
            Img_Role.sprite   = saveDataRole.AssetData.GetSprite;
            TMP_RoleName.text = saveDataRole.RoleName;
            Sld_Hp.value      = saveDataRole.Hp.Ratio;
            TMP_CurHp.text    = saveDataRole.Hp.Current.ToString();
            TMP_MaxHp.text    = saveDataRole.Hp.Max.ToString();
            
            BtnSelf.onClick.AddListener(() => {
                saveDataRole.Hp.SetCurrentToMax();
                SaveData_Player.I.SaveAsync();
                panelLounge.PanelLoungeResult.PlayResultAnimation();
            });
        }
    }
}