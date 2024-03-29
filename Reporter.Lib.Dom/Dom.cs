﻿using System.Collections.Generic;

namespace Reporter.Lib.Dom
{
    public class Dom
    {
        private readonly List<Element> _dom;

        public Dom()
        {
            _dom = new List<Element>();
        }

        public void Add(string key, string value)
        {
            _dom.Add(new Element
            {
                Key = key,
                Value = value
            });
        }

        public List<Element> GetDom() => _dom;
    }
}