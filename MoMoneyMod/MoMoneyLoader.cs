using ColossalFramework;
using ColossalFramework.Math;
using ColossalFramework.UI;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MoMoneyMod
{
    public class MoMoneyLoader : LoadingExtensionBase
    {
        GameObject buildingWindowGameObject;
        GameObject buttonObject;
        GameObject buttonObject2;
        UIButton menuButton;

        private static TextWindow textWindow = null;

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
            {
                UIView uiViewParent = null;

                foreach (var uiView in GameObject.FindObjectsOfType<UIView>())
                {
                    if (uiView.name == "UIView")
                    {
                        uiViewParent = uiView;
                        break;
                    }
                }

                if (uiViewParent != null)
                {
                    buildingWindowGameObject = new GameObject("buildingWindowObject");
                    buildingWindowGameObject.transform.parent = uiViewParent.cachedTransform;
                    MoMoneyLoader.textWindow = buildingWindowGameObject.AddComponent<TextWindow>();

                    UITabstrip strip = null;
                    if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame)
                    {
                        strip = ToolsModifierControl.mainToolbar.component as UITabstrip;
                    }
                    else
                    {
                        strip = UIView.Find<UITabstrip>("MainToolstrip");
                    }

                    buttonObject = UITemplateManager.GetAsGameObject("MainToolbarButtonTemplate");
                    buttonObject2 = UITemplateManager.GetAsGameObject("ScrollablePanelTemplate");
                    menuButton = strip.AddTab("moMoneyMod", buttonObject, buttonObject2, new Type[] { }) as UIButton;
                    menuButton.eventClick += uiButton_eventClick;

                    MoMoneyLoader.textWindow.Hide();
                }
            }
        }

        public override void OnLevelUnloading()
        {
            if (MoMoneyLoader.textWindow != null)
            {
                GameObject.Destroy(MoMoneyLoader.textWindow.gameObject);
                MoMoneyLoader.textWindow = null;
            }

            base.OnLevelUnloading();
        }

        private void uiButton_eventClick(UIComponent component, UIMouseEventParameter eventParam)
        {
            if (!MoMoneyLoader.textWindow.isVisible)
            {
                MoMoneyLoader.textWindow.isVisible = true;
                MoMoneyLoader.textWindow.BringToFront();
                MoMoneyLoader.textWindow.Show();
            }
            else
            {
                MoMoneyLoader.textWindow.isVisible = false;
                MoMoneyLoader.textWindow.Hide();
            }
        }
    }
}
