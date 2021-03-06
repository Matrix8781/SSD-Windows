﻿using Shadowsocks.Model;
using System;

namespace Shadowsocks.View {
    public partial class MenuViewController {
        private void PreloadMenu(object sender, EventArgs e) {
            UpdateServersMenu();
        }

        private void SubscriptionManagement(object sender, EventArgs e) {
            ConfigurationCurrent.StopRegularUpdate();
            Configuration.Save(ConfigurationCurrent);
            if(Form_subscriptionManagement == null) {
                Form_subscriptionManagement = new SubscriptionManagementForm(controller);
                Form_subscriptionManagement.Show();
                Form_subscriptionManagement.FormClosed += SubscriptionSettingsRecycled;
            }
            Form_subscriptionManagement.Activate();
        }

        private void SubscriptionSettingsRecycled(object sender, EventArgs e) {
            Form_subscriptionManagement.Dispose();
            Form_subscriptionManagement = null;
            Configuration.Save(ConfigurationCurrent);
            controller.SelectServerIndex(0);
            ConfigurationCurrent.ResetRegularUpdate();
        }

        private void UpdateSubscription(object sender, EventArgs e) {
            ConfigurationCurrent.UpdateAllSubscription(_notifyIcon, controller);
        }
    }
}
