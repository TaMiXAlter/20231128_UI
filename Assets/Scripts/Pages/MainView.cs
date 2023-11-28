
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AIExhibition.UIManagement.Base.Pages
{
    public class MainView: View
    {
        [SerializeField] private Button shopButton, friendButton;
        [SerializeField] private View shopView, friendView;
        public override void Initialize()
        {
            Show();
            shopButton.onClick.AddListener(GoShop);
            friendButton.onClick.AddListener(GoFriend);
        }

        private void OnDestroy()
        {
            shopButton.onClick.RemoveAllListeners();
            friendButton.onClick.RemoveAllListeners();
        }

        void GoShop()
        {
            shopView.Initialize();
            Hide();
        }

        void GoFriend()
        {
            friendView.Initialize();
            Hide();
        }
    }
}