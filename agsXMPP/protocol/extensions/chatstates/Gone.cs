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

namespace agsXMPP.protocol.extensions.chatstates;

using Xml.Dom;

/// <summary>
/// User has effectively ended their participation in the chat session.
/// User has not interacted with the chat interface, system, or device for a relatively long period of time 
/// (e.g., 2 minutes), or has terminated the chat interface (e.g., by closing the chat window).
/// </summary>
public class Gone : Element
{
    /// <summary>
    ///        
    /// </summary>
    public Gone()
    {
        this.TagName    = Chatstate.gone.ToString(); ;
        this.Namespace  = Namespaces.CHATSTATES;
    }
}
