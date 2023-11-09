using System;
using UnityEngine;

namespace MyGameUtility {
    [Serializable]
    public class SaveData_OverrideImage {
        public byte[]     ImgData;
        public Vector2Int Size;
        
        public Sprite GetSprite {
            get {
                Texture2D texture2D = new Texture2D(Size.x, Size.y);
                texture2D.LoadImage(ImgData);
                return Sprite.Create(texture2D, new Rect(0,0,Size.x, Size.y), new Vector2(0.5f, 0.5f));
            }
        }

        public SaveData_OverrideImage() { }

        public SaveData_OverrideImage(byte[] imgData, Vector2Int size) {
            ImgData = imgData;
            Size    = size;
        }
    }
}