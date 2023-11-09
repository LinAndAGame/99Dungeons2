using MyGameUtility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameMod.UI {
    public class Container_AnimationSprite : MonoBehaviour {
        public Image           ImgSprite;
        public Image           ImgError;
        public TextMeshProUGUI TMP_PngLimitWidth;
        public TextMeshProUGUI TMP_PngLimitHeight;
        public TextMeshProUGUI TMP_SpriteWidth;
        public TextMeshProUGUI TMP_SpriteHeight;
        public Color           ErrorTextColor = Color.red;
        public TextMeshProUGUI TMP_Index;

        public void RefreshUI(AssetData_PngLimit pngLimit, Sprite sprite, int index) {
            TMP_Index.text          = index.ToString();
            ImgSprite.sprite        = sprite;
            TMP_PngLimitWidth.text  = pngLimit.Size.x.ToString();
            TMP_PngLimitHeight.text = pngLimit.Size.y.ToString();
            TMP_SpriteWidth.text    = sprite.rect.width.ToString();
            TMP_SpriteHeight.text   = sprite.rect.height.ToString();

            bool widthError  = Mathf.Approximately(pngLimit.Size.x, sprite.rect.width) == false;
            bool heightError = Mathf.Approximately(pngLimit.Size.y, sprite.rect.height) == false;
            if (widthError || heightError) {
                SetAsErrorStyle(widthError, heightError);
            }
            else {
                SetAsNormalStyle();
            }
        }

        private void SetAsNormalStyle() {
            ImgError.gameObject.SetActive(false);
            TMP_SpriteWidth.color  = Color.white;
            TMP_SpriteHeight.color = Color.white;
        }

        private void SetAsErrorStyle(bool widthError, bool heightError) {
            ImgError.gameObject.SetActive(true);
            
            if (widthError) {
                TMP_SpriteWidth.color = ErrorTextColor;
            }
            else {
                TMP_SpriteWidth.color = Color.white;
            }

            if (heightError) {
                TMP_SpriteHeight.color = ErrorTextColor;
            }
            else {
                TMP_SpriteHeight.color = Color.white;
            }
        }
    }
}