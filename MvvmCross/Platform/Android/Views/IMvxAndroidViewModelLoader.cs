// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System;
using Android.Content;
using MvvmCross.Core.ViewModels;

namespace MvvmCross.Droid.Views
{
    public interface IMvxAndroidViewModelLoader
    {
        IMvxViewModel Load(Intent intent, IMvxBundle savedState);

        IMvxViewModel Load(Intent intent, IMvxBundle savedState, Type viewModelTypeHint);
    }
}