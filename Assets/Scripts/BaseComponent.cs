using MyGameUtility;
using UnityEngine;

public class BaseComponent<T> : MonoBehaviour {
    protected CacheCollection CC = new CacheCollection();
        
    protected T ComOwner { get; private set; }

    public virtual void Init(T comOwner) {
        ComOwner = comOwner;
    }

    public virtual void DestroySelf() {
        CC.Clear();
    }
}