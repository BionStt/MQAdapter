﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContextLifetimeManager.cs" company="">
//    Copyright (c) 2010-2012 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The http context lifetime manager of Unity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Messag.Utility.EntLib.IoC
{
    using System;
    using System.Web;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The http context lifetime manager of Unity
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        #region Public Methods

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The get value.
        /// </returns>
        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }

        /// <summary>
        /// The remove value.
        /// </summary>
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = newValue;
        }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.RemoveValue();
        }

        #endregion

        #endregion
    }
}