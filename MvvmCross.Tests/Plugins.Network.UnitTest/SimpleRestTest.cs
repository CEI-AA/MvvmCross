﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Threading.Tasks;
using MvvmCross.Plugins.Json;
using MvvmCross.Plugins.Network.Rest;
using MvvmCross.Plugins.Network.Test.TestClasses.GoogleBooks;
using Xunit;

namespace MvvmCross.Plugins.Network.Test
{

    [Collection("Rest")]
    public class SimpleRestTest
    {
        [Fact]
        public async Task GetDataFromGoogleBooks()
        {
            // not a real test yet....
            var url = BooksService.GetSearchUrl("MonoTouch");

            var json = new MvxJsonConverter();
            var client = new MvxJsonRestClient
            {
                JsonConverterProvider = () => json
            };
            var request = new MvxRestRequest(url);
            MvxDecodedRestResponse<BookSearchResult> theResponse = null;
            Exception exception = null;
            theResponse = await client.MakeRequestForAsync<BookSearchResult>(request);

            Assert.NotNull(theResponse);
            Assert.Null(exception);
            Assert.NotNull(theResponse.Result);
            Assert.Equal(HttpStatusCode.OK, theResponse.StatusCode);
            Assert.True(theResponse.Result.items.Count == 10);
            Assert.True(theResponse.Result.items[0].ToString().Contains("MonoTouch"));
        }
    }
}
