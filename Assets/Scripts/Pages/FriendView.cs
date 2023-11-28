using UnityEngine;
using UnityEngine.UI;

namespace AIExhibition.UIManagement.Base.Pages
{
    public class FriendView:View
    {
        [SerializeField] private Button backbutton;
        [SerializeField] private View mainView;
        public override void Initialize()
        {
            backbutton.onClick.AddListener(GoBack);
            Show();
        }

        private void OnDestroy()
        {
            backbutton.onClick.RemoveAllListeners();
        }

        void GoBack()
        {
            mainView.Initialize();
            Hide();
        }
    }
}