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

//<stream:stream xmlns:stream='http://etherx.jabber.org/streams/'
//xmlns='jabber:client'
//from='somedomain'
//version='1.0'>
//<stream:features>
//...
//<register xmlns='http://jabber.org/features/iq-register'/>
//...

namespace agsXMPP.protocol.stream.feature;

using Xml.Dom;

/// <summary>
/// 
/// </summary>
public class Register : Element
	{
		public Register()
		{
			this.TagName	= "register";
			this.Namespace	= Namespaces.FEATURE_IQ_REGISTER;
		}
	}
