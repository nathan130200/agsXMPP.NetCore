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

// Request Roster:
// <iq id='someid' to='myjabber.net' type='get'>
//		<query xmlns='jabber:iq:roster'/>
// </iq>
namespace agsXMPP.protocol.iq.roster;

using client;

/// <summary>
/// Build a new roster query, jabber:iq:roster
/// </summary>
public class RosterIq : IQ
{
    public RosterIq()
    {
        this.GenerateId();
    }

    public RosterIq(IQ iq)
        : base(iq)
    {
    }

    public new Roster Query
    {
        get
        {
            return SelectSingleElement<Roster>();
        }
        set
        {
            RemoveTag(typeof(Roster));
            if (value != null)
            {
                AddChild(value);
            }
        }
    }
}
