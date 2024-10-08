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

namespace agsXMPP.protocol.iq.@private;

using client;

/// <summary>
/// Summary description for PrivateIq.
/// </summary>
public class PrivateIq : IQ
	{
		public PrivateIq()
		{
			this.GenerateId();
		}

    public PrivateIq(IQ iq)
        : base(iq)
    {
    }

    public new Private Query
    {
        get
        {
            return SelectSingleElement<Private>();
        }
        set
        {
            RemoveTag(typeof(Private));
            if (value != null)
            {
                AddChild(value);
            }
        }
    }
	}
