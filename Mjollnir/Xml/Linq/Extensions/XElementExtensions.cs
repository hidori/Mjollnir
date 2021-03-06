﻿using System;
using System.Xml.Linq;

namespace Mjollnir.Xml.Linq.Extensions
{
    public static partial class XElementExtensions
    {
        public static void Walk(this XElement element, Action<XElement> action)
        {
            Throw.ArgumentNullException.IfNull(element, nameof(element));
            Throw.ArgumentNullException.IfNull(action, nameof(action));

            action(element);

            foreach (var childElement in element.Elements())
            {
                childElement.Walk(action);
            }
        }
    }
}
