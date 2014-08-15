﻿using ArtOfTest.WebAii.Core;
using Feather.Widgets.TestUI.Framework.Framework.ElementMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feather.Widgets.TestUI.Framework.Framework.Wrappers
{
    public class BaseWrapper
    {
        /// <summary>
        /// Provides unified access to the ActiveBrowser object
        /// </summary>
        public Browser ActiveBrowser
        {
            get
            {
                return Manager.Current.ActiveBrowser;
            }
        }

        /// <summary>
        /// Provides unified access to the ActiveBrowser object
        /// </summary>
        public virtual FeatherElementMap EM
        {
            get
            {
                return new FeatherElementMap(ActiveBrowser.Find);
            }
        }

        /// <summary>
        /// Provides unified access to the Log object
        /// </summary>
        public Log Log
        {
            get
            {
                return Manager.Current.Log;
            }
        }
    }
}