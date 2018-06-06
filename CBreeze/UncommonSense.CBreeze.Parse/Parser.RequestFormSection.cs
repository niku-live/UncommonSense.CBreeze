using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
		internal void ParseRequestFormSection(Lines lines, ObjectType objectType)
		{
		    Listener.OnBeginRequestForm();

		    foreach (var chunk in lines.Chunks(Patterns.SectionSignature))
		    {
		        ParseSection(chunk, objectType);
		    }

		    Listener.OnEndRequestForm();
		}
    }
}
