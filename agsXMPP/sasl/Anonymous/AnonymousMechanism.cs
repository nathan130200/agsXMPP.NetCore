// /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
//  * Copyright (c) 2003-2008 by AG-Software 											 *
//  * All Rights Reserved.																 *
//  * Contact information for AG-Software is available at http://www.ag-software.de	 *
//  *																					 *
//  * Licence:																			 *
//  * The agsXMPP SDK is released under a dual licence									 *
//  * agsXMPP can be used under either of two licences									 *
//  * 																					 *
//  * A commercial licence which is probably the most appropriate for commercial 		 *
//  * corporate use and closed source projects. 										 *
//  *																					 *
//  * The GNU Public License (GPL) is probably most appropriate for inclusion in		 *
//  * other open source projects.														 *
//  *																					 *
//  * See README.html for details.														 *
//  *																					 *
//  * For general enquiries visit our website at:										 *
//  * http://www.ag-software.de														 *
//  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#region using

using agsXMPP.Xml.Dom;

#endregion

namespace agsXMPP.Sasl.Anonymous;

#region usings



#endregion

/// <summary>
/// SALS ANONYMOUS Mechanism, this allows anonymous logins to a xmpp server.
/// </summary>
public class AnonymousMechanism : Mechanism
{
    #region Methods

    /// <summary>
    /// </summary>
    /// <param name="con">
    /// </param>
    public override void Init()
    {
        //con.Send(new Auth(MechanismType.ANONYMOUS));
    }

    /// <summary>
    /// </summary>
    /// <param name="e">
    /// </param>
    public override void Parse(Node e)
    {
        // *No Challenges* in SASL ANONYMOUS
    }

    #endregion

    /*
        S: <stream:features>
                <mechanisms xmlns='urn:ietf:params:xml:ns:xmpp-sasl'>
                    <mechanism>DIGEST-MD5<mechanism>
                    <mechanism>ANONYMOUS<mechanism>
                </mechanisms>
           </stream:features>
        
        * So, the proper exchange for this ANONYMOUS mechanism would be:

        C: <auth xmlns='urn:ietf:params:xml:ns:xmpp-sasl' mechanism='ANONYMOUS'/>
        S: <success xmlns='urn:ietf:params:xml:ns:xmpp-sasl'/>

        or, in case of the optional trace information:

        C: <auth xmlns='urn:ietf:params:xml:ns:xmpp-sasl' mechanism='ANONYMOUS'>
                c2lyaGM=
           </auth>
        S: <success xmlns='urn:ietf:params:xml:ns:xmpp-sasl'/>

    */
}