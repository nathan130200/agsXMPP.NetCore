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

// Request Agents:
// <iq id='someid' to='myjabber.net' type='get'>
//		<query xmlns='jabber:iq:agents'/>
// </iq>

namespace agsXMPP.protocol.iq.agent;

using client;

/// <summary>
/// Summary description for AgentsIq.
/// </summary>
public class AgentsIq : IQ
	{
		private Agents m_Agents = new();

		public AgentsIq()
		{
			base.Query = m_Agents;
			this.GenerateId();
		}

		public AgentsIq(IqType type) : this()
		{			
        this.Type = type;		
		}

		public AgentsIq(IqType type, Jid to) : this(type)
		{
			this.To = to;
		}

		public AgentsIq(IqType type, Jid to, Jid from) : this(type, to)
		{
			this.From = from;
		}

		public new Agents Query
		{
			get	{ return m_Agents; }            
		}
	}
