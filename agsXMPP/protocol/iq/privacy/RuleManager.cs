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

namespace agsXMPP.protocol.iq.privacy;

using roster;

/// <summary>
/// Helper class for creating rules for communication blocking
/// </summary>
public class RuleManager
{
    public RuleManager()
    {

    }
    
    /// <summary>
    /// Block stanzas by Jid
    /// </summary>
    /// <param name="JidToBlock"></param>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item BlockByJid(Jid JidToBlock, int Order, Stanza stanza)
    {
        return new Item(Action.deny, Order, Type.jid, JidToBlock.ToString(), stanza);
    }
            

    /// <summary>
    /// Block stanzas for a given roster group
    /// </summary>
    /// <param name="group"></param>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item BlockByGroup(string group, int Order, Stanza stanza)
    {
        return new Item(Action.deny, Order, Type.group, group, stanza);
    }
            
    /// <summary>
    /// Block stanzas by subscription type
    /// </summary>
    /// <param name="subType"></param>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item BlockBySubscription(SubscriptionType subType, int Order, Stanza stanza)
    {
        return new Item(Action.deny, Order, Type.subscription, subType.ToString(), stanza);
    }

    /// <summary>
    /// Block globally (all users) the given stanzas
    /// </summary>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item BlockGlobal(int Order, Stanza stanza)
    {
        return new Item(Action.deny, Order, stanza);
    }

    /// <summary>
    /// Allow stanzas by Jid
    /// </summary>
    /// <param name="JidToBlock"></param>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item AllowByJid(Jid JidToBlock, int Order, Stanza stanza)
    {
        return new Item(Action.allow, Order, Type.jid, JidToBlock.ToString(), stanza);
    }

    /// <summary>
    /// Allow stanzas for a given roster group
    /// </summary>
    /// <param name="group"></param>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item AllowByGroup(string group, int Order, Stanza stanza)
    {
        return new Item(Action.allow, Order, Type.group, group, stanza);
    }

    /// <summary>
    /// Allow stanzas by subscription type
    /// </summary>
    /// <param name="subType"></param>
    /// <param name="Order"></param>
    /// <param name="stanza">stanzas you want to block</param>
    /// <returns></returns>
    public Item AllowBySubscription(SubscriptionType subType, int Order, Stanza stanza)
    {
        return new Item(Action.allow, Order, Type.subscription, subType.ToString(), stanza);
    }
    
}
