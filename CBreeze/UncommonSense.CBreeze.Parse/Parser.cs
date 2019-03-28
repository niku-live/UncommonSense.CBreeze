using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using UncommonSense.CBreeze.Core.Common;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        private static NullListener nullListener = new NullListener();
        private IListener listener;
        private Encoding fileEncoding;

        public void ParseFiles(IEnumerable<string> fileNames, Action<string> reportProgress = null)
        {
            Listener.OnBeginApplication();

            foreach (var fileName in fileNames ?? new string[] { })
            {
                if (reportProgress != null)
                    reportProgress.Invoke(fileName);
                Listener.OnBeginFile(fileName);
                ParseApplication(new Lines(File.ReadLines(fileName, FileEncoding)));
                Listener.OnEndFile();
            }

            Listener.OnEndApplication();
        }

        //public void ParseFiles(params string[] fileNames)
        //{
        //    ParseFiles(fileNames);
        //}

        public void ParseLines(IEnumerable<string> source)
        {
            Listener.OnBeginApplication();
            ParseApplication(new Lines(source ?? new string[] { }));
            Listener.OnEndApplication();
        }

        public IListener Listener
        {
            get
            {
                return listener ?? nullListener;
            }
            set
            {
                listener = value;
            }
        }

        public Localization Localization => CodeStyle?.Localization ?? Localization.Default;

        public Encoding FileEncoding => Localization?.TextEncoding ?? Encoding.GetEncoding("ibm850");

        public ApplicationCodeStyle CodeStyle { get; set; } = ApplicationCodeStyle.CreateNav2013CodeStyle();
    }
}

