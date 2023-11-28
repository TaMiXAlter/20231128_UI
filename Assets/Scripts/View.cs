using UnityEngine;

namespace AIExhibition.UIManagement.Base
{
    public abstract class View : MonoBehaviour
    {
        public abstract void Initialize();
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}
