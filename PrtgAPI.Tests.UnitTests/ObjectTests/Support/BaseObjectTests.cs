﻿using System;
using System.Collections.Generic;
using System.Linq;
using PrtgAPI.Tests.UnitTests.InfrastructureTests.Support;

namespace PrtgAPI.Tests.UnitTests.ObjectTests.Support
{
    public abstract class BaseObjectTests<TObject, TItem, TResponse> where TResponse : IWebResponse
    {
        private PrtgClient Initialize_Client(IWebResponse response)
        {
            var webClient = new MockWebClient(response);

            var client = new PrtgClient("prtg.example.com", "username", "12345678", AuthMode.PassHash, webClient);

            return client;
        }

        protected PrtgClient Initialize_Client_WithItems(params TItem[] items)
        {
            if (items.Length == 0)
                throw new ArgumentException("Length of items cannot be 0", nameof(items));

            var response = GetResponse(items);

            var client = Initialize_Client(response);

            return client;
        }

        protected abstract List<TObject> GetObjects(PrtgClient client);

        protected TObject GetSingleItem()
        {
            var item = GetItem();
            var obj = GetItemsInternal(new[] {item}).FirstOrDefault();

            return obj;
        }

        protected List<TObject> GetMultipleItems()
        {
            var items = GetItems();

            return GetItemsInternal(items);
        }

        private List<TObject> GetItemsInternal(TItem[] items)
        {
            var client = Initialize_Client_WithItems(items);

            var obj = GetObjects(client);

            return obj;
        }

        protected abstract TItem GetItem();

        protected virtual TItem[] GetItems()
        {
            throw new NotSupportedException();
        }

        protected abstract TResponse GetResponse(TItem[] items);
    }
}
