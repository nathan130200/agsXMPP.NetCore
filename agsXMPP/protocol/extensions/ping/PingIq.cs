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

namespace agsXMPP.protocol.extensions.ping;

using client;

/// <summary>
/// 
/// </summary>
public class PingIq : IQ
	{
		private Ping m_Ping = new();

    #region << Constructors >>
    public PingIq()
		{		
			base.Query = m_Ping;
			this.GenerateId();
		}

    public PingIq(Jid to) : this()
    {
        To = to;
    }

    public PingIq(Jid to, Jid from) : this()
    {
        To      = to;
        From    = from;
    }
    #endregion


    public new Ping Query
    {
        get { return m_Ping; }
    }
	}
