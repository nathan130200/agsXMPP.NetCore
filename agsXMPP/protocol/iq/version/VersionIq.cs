/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright (c) 2003-2008 by AG-Software 											 *
 * All Rights Reserved.																 *
 * Contact information for AG-Software is available at http://www.ag-software.de	 *
 *																					 *
 * Licence:																			 *
 * The agsXMPP SDK is released under a dual licence									 *
 * agsXMPP can be used under either of two licences									 *
 * 																					 *
 * A commercial licence which is probably the most appropriate for commercial 		 *
 * corporate use and closed source projects. 										 *
 *																					 *
 * The GNU Public License (GPL) is probably most appropriate for inclusion in		 *
 * other open source projects.														 *
 *																					 *
 * See README.html for details.														 *
 *																					 *
 * For general enquiries visit our website at:										 *
 * http://www.ag-software.de														 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace agsXMPP.protocol.iq.version;

using client;

/// <summary>
/// Summary description for VersionIq.
/// </summary>
public class VersionIq : IQ
{
    public VersionIq()
    {
        this.GenerateId();
    }

    public VersionIq(IqType type)
        : this()
    {
        this.Type = type;
    }

    public VersionIq(IqType type, Jid to)
        : this(type)
    {
        this.To = to;
    }

    public VersionIq(IqType type, Jid to, Jid from)
        : this(type, to)
    {
        this.From = from;
    }

    public VersionIq(IQ iq)
        : base(iq)
    {
    }

    public new Version Query
    {
        get
        {
            return SelectSingleElement(typeof(Version)) as Version;
        }
        set
        {
            RemoveTag(typeof(Version));
            if (value != null)
            {
                AddChild(value);
            }
        }
    }
}