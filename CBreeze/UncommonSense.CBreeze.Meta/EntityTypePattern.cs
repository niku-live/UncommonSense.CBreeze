﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;

namespace UncommonSense.CBreeze.Meta    
{
    public abstract class EntityTypePattern : Pattern
    {
        // FIXME: Consider making these classes partial, and creating separate
        // .cs files for interface and implementation. Perhaps even for "input"
        // properties and "output" properties?

        public EntityTypePattern(Application application, IEnumerable<int> range, string name)
        {
            Application = application;
            Range = range;
            Name = name;
        }

        protected override void VerifyRequirements()
        {
            if (Application == null)
                throw new ArgumentNullException("Application");

            if (Range == null)
                throw new ArgumentNullException("Range");

            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Name");
        }

        // FIXME: Override in as few patterns as possible. Try and make
        // all patterns follow the same basic process
        protected override void MakeChanges()
        {
            CreateObjects();
            LinkObjects();
            CreateFields();
            CreateControls();
        }

        protected virtual void CreateObjects()
        {
        }

        protected virtual void LinkObjects()
        {
        }

        protected virtual void CreateFields()
        {
        }

        protected virtual void CreateControls()
        {
        }

        public Application Application
        {
            get;
            protected set;
        }

        public IEnumerable<int> Range
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }
    }
}