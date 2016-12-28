﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrtgAPI.Tests.UnitTests.ObjectTests.Support;

namespace PrtgAPI.Tests.UnitTests.ObjectTests
{
    [TestClass]
    public class NotificationActionTests : ObjectTests<NotificationAction, NotificationActionItem, NotificationActionResponse>
    {
        [TestMethod]
        public void NotificationAction_CanDeserialize() => Object_CanDeserialize();

        [TestMethod]
        public void NotificationAction_AllFields_HaveValues() => Object_AllFields_HaveValues();

        protected override List<NotificationAction> GetObjects(PrtgClient client) => client.GetNotificationActions();

        protected override NotificationActionItem GetItem() => new NotificationActionItem();

        protected override NotificationActionResponse GetResponse(NotificationActionItem[] items) => new NotificationActionResponse(items);
    }
}
