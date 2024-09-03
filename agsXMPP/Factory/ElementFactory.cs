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

using System.Collections;
using agsXMPP.protocol.Base;
using agsXMPP.protocol.component;
using agsXMPP.protocol.extensions.amp;
using agsXMPP.protocol.extensions.bookmarks;
using agsXMPP.protocol.extensions.bytestreams;
using agsXMPP.protocol.extensions.caps;
using agsXMPP.protocol.extensions.chatstates;
using agsXMPP.protocol.extensions.commands;
using agsXMPP.protocol.extensions.compression;
using agsXMPP.protocol.extensions.featureneg;
using agsXMPP.protocol.extensions.geoloc;
using agsXMPP.protocol.extensions.html;
using agsXMPP.protocol.extensions.ibb;
using agsXMPP.protocol.extensions.jivesoftware.phone;
using agsXMPP.protocol.extensions.msgreceipts;
using agsXMPP.protocol.extensions.multicast;
using agsXMPP.protocol.extensions.nickname;
using agsXMPP.protocol.extensions.ping;
using agsXMPP.protocol.extensions.primary;
using agsXMPP.protocol.extensions.pubsub;
using agsXMPP.protocol.extensions.pubsub.owner;
using agsXMPP.protocol.extensions.shim;
using agsXMPP.protocol.extensions.si;
using agsXMPP.protocol.iq.agent;
using agsXMPP.protocol.iq.bind;
using agsXMPP.protocol.iq.blocklist;
using agsXMPP.protocol.iq.browse;
using agsXMPP.protocol.iq.disco;
using agsXMPP.protocol.iq.jingle;
using agsXMPP.protocol.iq.last;
using agsXMPP.protocol.iq.oob;
using agsXMPP.protocol.iq.privacy;
using agsXMPP.protocol.iq.@private;
using agsXMPP.protocol.iq.register;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.rpc;
using agsXMPP.protocol.iq.search;
using agsXMPP.protocol.iq.session;
using agsXMPP.protocol.iq.time;
using agsXMPP.protocol.iq.vcard;
using agsXMPP.protocol.sasl;
using agsXMPP.protocol.stream.feature.compression;
using agsXMPP.protocol.tls;
using agsXMPP.protocol.x;
using agsXMPP.protocol.x.data;
using agsXMPP.protocol.x.muc;
using agsXMPP.protocol.x.muc.iq;
using agsXMPP.protocol.x.muc.iq.admin;
using agsXMPP.protocol.x.muc.iq.owner;
using agsXMPP.protocol.x.rosterx;
using agsXMPP.protocol.x.vcard_update;
using agsXMPP.Xml.Dom;
using Active = agsXMPP.protocol.iq.privacy.Active;
using Address = agsXMPP.protocol.extensions.multicast.Address;
using Affiliation = agsXMPP.protocol.extensions.pubsub.Affiliation;
using Auth = agsXMPP.protocol.iq.auth.Auth;
using Avatar = agsXMPP.protocol.iq.avatar.Avatar;
using Conference = agsXMPP.protocol.x.Conference;
using Configure = agsXMPP.protocol.extensions.pubsub.owner.Configure;
using Data = agsXMPP.protocol.x.data.Data;
using Error = agsXMPP.protocol.client.Error;
using Failure = agsXMPP.protocol.tls.Failure;
using History = agsXMPP.protocol.x.muc.History;
using IQ = agsXMPP.protocol.client.IQ;
using Item = agsXMPP.protocol.iq.privacy.Item;
using Message = agsXMPP.protocol.client.Message;
using Presence = agsXMPP.protocol.client.Presence;
using PubSub = agsXMPP.protocol.extensions.pubsub.owner.PubSub;
using RosterItem = agsXMPP.protocol.iq.roster.RosterItem;
using Status = agsXMPP.protocol.x.muc.Status;
using Type = System.Type;
using Version = agsXMPP.protocol.iq.version.Version;

#endregion

namespace agsXMPP.Factory;
#region using

#endregion

/// <summary>
/// Factory class that implements the factory pattern for builing our Elements.
/// </summary>
public class ElementFactory
{
    #region Members

    /// <summary>
    /// This Hashtable stores Mapping of protocol (tag/namespace) to the agsXMPP objects
    /// </summary>
    private static readonly Hashtable m_table = new();

    #endregion

    #region Constructor

    /// <summary>
    /// </summary>
    static ElementFactory()
    {
        AddElementType("iq", Namespaces.CLIENT, typeof(IQ));
        AddElementType("message", Namespaces.CLIENT, typeof(Message));
        AddElementType("presence", Namespaces.CLIENT, typeof(Presence));
        AddElementType("error", Namespaces.CLIENT, typeof(Error));

        AddElementType("agent", Namespaces.IQ_AGENTS, typeof(Agent));

        AddElementType("item", Namespaces.IQ_ROSTER, typeof(RosterItem));
        AddElementType("group", Namespaces.IQ_ROSTER, typeof(Group));
        AddElementType("group", Namespaces.X_ROSTERX, typeof(Group));

        AddElementType("item", Namespaces.IQ_SEARCH, typeof(SearchItem));

        // Stream stuff
        AddElementType("stream", Namespaces.STREAM, typeof(agsXMPP.protocol.Base.StreamStream));
        AddElementType("error", Namespaces.STREAM, typeof(protocol.Error));

        AddElementType("server", Namespaces.IQ_GOOGLE_JINGLE, typeof(Server));
        AddElementType("stun", Namespaces.IQ_GOOGLE_JINGLE, typeof(Stun));
        AddElementType("query", Namespaces.IQ_GOOGLE_JINGLE, typeof(GoogleJingle));

        AddElementType("query", Namespaces.IQ_AUTH, typeof(Auth));
        AddElementType("query", Namespaces.IQ_AGENTS, typeof(Agents));
        AddElementType("query", Namespaces.IQ_ROSTER, typeof(Roster));
        AddElementType("query", Namespaces.IQ_LAST, typeof(Last));
        AddElementType("query", Namespaces.IQ_VERSION, typeof(Version));
        AddElementType("query", Namespaces.IQ_TIME, typeof(Time));
        AddElementType("query", Namespaces.IQ_OOB, typeof(Oob));
        AddElementType("query", Namespaces.IQ_SEARCH, typeof(Search));
        AddElementType("query", Namespaces.IQ_BROWSE, typeof(Browse));
        AddElementType("query", Namespaces.IQ_AVATAR, typeof(Avatar));
        AddElementType("query", Namespaces.IQ_REGISTER, typeof(Register));
        AddElementType("query", Namespaces.IQ_PRIVATE, typeof(Private));

        AddElementType("blocklist", Namespaces.IQ_BLOCKLIST, typeof(Blocklist));
        AddElementType("block", Namespaces.IQ_BLOCKLIST, typeof(Block));
        AddElementType("unblock", Namespaces.IQ_BLOCKLIST, typeof(Unblock));

        // Privacy Lists
        AddElementType("query", Namespaces.IQ_PRIVACY, typeof(Privacy));
        AddElementType("item", Namespaces.IQ_PRIVACY, typeof(Item));
        AddElementType("list", Namespaces.IQ_PRIVACY, typeof(List));
        AddElementType("active", Namespaces.IQ_PRIVACY, typeof(Active));
        AddElementType("default", Namespaces.IQ_PRIVACY, typeof(Default));

        // Browse
        AddElementType("service", Namespaces.IQ_BROWSE, typeof(Service));
        AddElementType("item", Namespaces.IQ_BROWSE, typeof(BrowseItem));

        // Service Discovery			
        AddElementType("query", Namespaces.DISCO_ITEMS, typeof(DiscoItems));
        AddElementType("query", Namespaces.DISCO_INFO, typeof(DiscoInfo));
        AddElementType("feature", Namespaces.DISCO_INFO, typeof(DiscoFeature));
        AddElementType("identity", Namespaces.DISCO_INFO, typeof(DiscoIdentity));
        AddElementType("item", Namespaces.DISCO_ITEMS, typeof(DiscoItem));

        AddElementType("x", Namespaces.X_DELAY, typeof(Delay));
        AddElementType("x", Namespaces.X_AVATAR, typeof(protocol.x.Avatar));
        AddElementType("x", Namespaces.X_CONFERENCE, typeof(Conference));
        AddElementType("x", Namespaces.X_EVENT, typeof(Event));

        // AddElementType("x",					Uri.STORAGE_AVATAR,	typeof(agsXMPP.protocol.storage.Avatar));
        AddElementType("query", Namespaces.STORAGE_AVATAR, typeof(protocol.storage.Avatar));

        // XData Stuff
        AddElementType("x", Namespaces.X_DATA, typeof(Data));
        AddElementType("field", Namespaces.X_DATA, typeof(Field));
        AddElementType("option", Namespaces.X_DATA, typeof(Option));
        AddElementType("value", Namespaces.X_DATA, typeof(Value));
        AddElementType("reported", Namespaces.X_DATA, typeof(Reported));
        AddElementType("item", Namespaces.X_DATA, typeof(protocol.x.data.Item));

        AddElementType("features", Namespaces.STREAM, typeof(Features));

        AddElementType("register", Namespaces.FEATURE_IQ_REGISTER, typeof(protocol.stream.feature.Register));
        AddElementType("compression", Namespaces.FEATURE_COMPRESS, typeof(Compression));
        AddElementType("method", Namespaces.FEATURE_COMPRESS, typeof(Method));

        AddElementType("jingle", Namespaces.IQ_JINGLE1, typeof(Jingle));
        AddElementType("jingle", Namespaces.IQ_JINGLE0, typeof(Jingle));
        AddElementType("bind", Namespaces.BIND, typeof(Bind));
        AddElementType("unbind", Namespaces.BIND, typeof(Bind));
        AddElementType("session", Namespaces.SESSION, typeof(Session));

        // TLS stuff
        AddElementType("failure", Namespaces.TLS, typeof(Failure));
        AddElementType("proceed", Namespaces.TLS, typeof(Proceed));
        AddElementType("starttls", Namespaces.TLS, typeof(StartTls));

        // SASL stuff
        AddElementType("mechanisms", Namespaces.SASL, typeof(Mechanisms));
        AddElementType("mechanism", Namespaces.SASL, typeof(Mechanism));
        AddElementType("auth", Namespaces.SASL, typeof(protocol.sasl.Auth));
        AddElementType("x-tmtoken", Namespaces.SASL, typeof(TMToken)); //TeamLab token
        AddElementType("response", Namespaces.SASL, typeof(Response));
        AddElementType("challenge", Namespaces.SASL, typeof(Challenge));

        // TODO, this is a dirty hacks for the buggy BOSH Proxy
        // BEGIN
        AddElementType("challenge", Namespaces.CLIENT, typeof(Challenge));
        AddElementType("success", Namespaces.CLIENT, typeof(Success));

        // END
        AddElementType("failure", Namespaces.SASL, typeof(protocol.sasl.Failure));
        AddElementType("abort", Namespaces.SASL, typeof(Abort));
        AddElementType("success", Namespaces.SASL, typeof(Success));

        // Vcard stuff
        AddElementType("vCard", Namespaces.VCARD, typeof(Vcard));
        AddElementType("TEL", Namespaces.VCARD, typeof(Telephone));
        AddElementType("ORG", Namespaces.VCARD, typeof(Organization));
        AddElementType("N", Namespaces.VCARD, typeof(Name));
        AddElementType("EMAIL", Namespaces.VCARD, typeof(Email));
        AddElementType("ADR", Namespaces.VCARD, typeof(Address));
#if !CF
        AddElementType("PHOTO", Namespaces.VCARD, typeof(Photo));
#endif

        // Server stuff
        // AddElementType("stream",            Uri.SERVER,                 typeof(agsXMPP.protocol.server.Stream));
        // AddElementType("message",           Uri.SERVER,                 typeof(agsXMPP.protocol.server.Message));

        // Component stuff
        AddElementType("handshake", Namespaces.ACCEPT, typeof(Handshake));
        AddElementType("log", Namespaces.ACCEPT, typeof(Log));
        AddElementType("route", Namespaces.ACCEPT, typeof(Route));
        AddElementType("iq", Namespaces.ACCEPT, typeof(protocol.component.IQ));
        AddElementType("message", Namespaces.ACCEPT, typeof(protocol.component.Message));
        AddElementType("presence", Namespaces.ACCEPT, typeof(protocol.component.Presence));
        AddElementType("error", Namespaces.ACCEPT, typeof(protocol.component.Error));

        // Extensions (JEPS)
        AddElementType("headers", Namespaces.SHIM, typeof(Header));
        AddElementType("header", Namespaces.SHIM, typeof(Headers));
        AddElementType("roster", Namespaces.ROSTER_DELIMITER, typeof(Delimiter));
        AddElementType("p", Namespaces.PRIMARY, typeof(Primary));
        AddElementType("nick", Namespaces.NICK, typeof(Nickname));

        AddElementType("item", Namespaces.X_ROSTERX, typeof(protocol.x.rosterx.RosterItem));
        AddElementType("x", Namespaces.X_ROSTERX, typeof(RosterX));

        // Filetransfer stuff
        AddElementType("file", Namespaces.SI_FILE_TRANSFER, typeof(protocol.extensions.filetransfer.File));
        AddElementType("range", Namespaces.SI_FILE_TRANSFER, typeof(protocol.extensions.filetransfer.Range));

        // FeatureNeg
        AddElementType("feature", Namespaces.FEATURE_NEG, typeof(FeatureNeg));

        // Bytestreams
        AddElementType("query", Namespaces.BYTESTREAMS, typeof(ByteStream));
        AddElementType("streamhost", Namespaces.BYTESTREAMS, typeof(StreamHost));
        AddElementType("streamhost-used", Namespaces.BYTESTREAMS, typeof(StreamHostUsed));
        AddElementType("activate", Namespaces.BYTESTREAMS, typeof(Activate));
        AddElementType("udpsuccess", Namespaces.BYTESTREAMS, typeof(UdpSuccess));

        AddElementType("si", Namespaces.SI, typeof(SI));

        AddElementType("html", Namespaces.XHTML_IM, typeof(Html));
        AddElementType("body", Namespaces.XHTML, typeof(Body));

        AddElementType("compressed", Namespaces.COMPRESS, typeof(Compressed));
        AddElementType("compress", Namespaces.COMPRESS, typeof(Compress));
        AddElementType("failure", Namespaces.COMPRESS, typeof(protocol.extensions.compression.Failure));

        // MUC (JEP-0045 Multi User Chat)
        AddElementType("x", Namespaces.MUC, typeof(Muc));
        AddElementType("x", Namespaces.MUC_USER, typeof(User));
        AddElementType("item", Namespaces.MUC_USER, typeof(protocol.x.muc.Item));
        AddElementType("status", Namespaces.MUC_USER, typeof(Status));
        AddElementType("invite", Namespaces.MUC_USER, typeof(Invite));
        AddElementType("decline", Namespaces.MUC_USER, typeof(Decline));
        AddElementType("actor", Namespaces.MUC_USER, typeof(Actor));
        AddElementType("history", Namespaces.MUC, typeof(History));
        AddElementType("query", Namespaces.MUC_ADMIN, typeof(Admin));
        AddElementType("item", Namespaces.MUC_ADMIN, typeof(protocol.x.muc.iq.admin.Item));
        AddElementType("query", Namespaces.MUC_OWNER, typeof(Owner));
        AddElementType("destroy", Namespaces.MUC_OWNER, typeof(Destroy));
        AddElementType("unique", Namespaces.MUC_UNIQUE, typeof(Unique));

        //Jabber xep-003 Addressing
        AddElementType("addresses", Namespaces.ADDRESS, typeof(Addresses));
        AddElementType("address", Namespaces.ADDRESS, typeof(Address));


        // Jabber RPC JEP 0009            
        AddElementType("query", Namespaces.IQ_RPC, typeof(Rpc));
        AddElementType("methodCall", Namespaces.IQ_RPC, typeof(MethodCall));
        AddElementType("methodResponse", Namespaces.IQ_RPC, typeof(MethodResponse));

        // Chatstates Jep-0085
        AddElementType("active", Namespaces.CHATSTATES, typeof(protocol.extensions.chatstates.Active));
        AddElementType("inactive", Namespaces.CHATSTATES, typeof(Inactive));
        AddElementType("composing", Namespaces.CHATSTATES, typeof(Composing));
        AddElementType("paused", Namespaces.CHATSTATES, typeof(Paused));
        AddElementType("gone", Namespaces.CHATSTATES, typeof(Gone));

        // Jivesoftware Extenstions
        AddElementType("phone-event", Namespaces.JIVESOFTWARE_PHONE, typeof(PhoneEvent));
        AddElementType("phone-action", Namespaces.JIVESOFTWARE_PHONE, typeof(PhoneAction));
        AddElementType("phone-status", Namespaces.JIVESOFTWARE_PHONE, typeof(PhoneStatus));

        // Jingle stuff is in heavy development, we commit this once the most changes on the Jeps are done            
        // AddElementType("jingle",            Uri.JINGLE,                 typeof(agsXMPP.protocol.extensions.jingle.Jingle));
        // AddElementType("candidate",         Uri.JINGLE,                 typeof(agsXMPP.protocol.extensions.jingle.Candidate));
        AddElementType("c", Namespaces.CAPS, typeof(Capabilities));

        AddElementType("geoloc", Namespaces.GEOLOC, typeof(GeoLoc));

        // Xmpp Ping
        AddElementType("ping", Namespaces.PING, typeof(Ping));

        // Ad-Hock Commands
        AddElementType("command", Namespaces.COMMANDS, typeof(Command));
        AddElementType("actions", Namespaces.COMMANDS, typeof(Actions));
        AddElementType("note", Namespaces.COMMANDS, typeof(Note));

        // **********
        // * PubSub *
        // **********
        // Owner namespace
        AddElementType("affiliate", Namespaces.PUBSUB_OWNER, typeof(Affiliate));
        AddElementType("affiliates", Namespaces.PUBSUB_OWNER, typeof(Affiliates));
        AddElementType("configure", Namespaces.PUBSUB_OWNER, typeof(Configure));
        AddElementType("delete", Namespaces.PUBSUB_OWNER, typeof(Delete));
        AddElementType("pending", Namespaces.PUBSUB_OWNER, typeof(Pending));
        AddElementType("pubsub", Namespaces.PUBSUB_OWNER, typeof(PubSub));
        AddElementType("purge", Namespaces.PUBSUB_OWNER, typeof(Purge));
        AddElementType("subscriber", Namespaces.PUBSUB_OWNER, typeof(Subscriber));
        AddElementType("subscribers", Namespaces.PUBSUB_OWNER, typeof(Subscribers));

        // Event namespace
        AddElementType("delete", Namespaces.PUBSUB_EVENT, typeof(protocol.extensions.pubsub.@event.Delete));
        AddElementType("event", Namespaces.PUBSUB_EVENT, typeof(protocol.extensions.pubsub.@event.Event));
        AddElementType("item", Namespaces.PUBSUB_EVENT, typeof(protocol.extensions.pubsub.@event.Item));
        AddElementType("items", Namespaces.PUBSUB_EVENT, typeof(protocol.extensions.pubsub.@event.Items));
        AddElementType("purge", Namespaces.PUBSUB_EVENT, typeof(protocol.extensions.pubsub.@event.Purge));

        // Main Pubsub namespace
        AddElementType("affiliation", Namespaces.PUBSUB, typeof(Affiliation));
        AddElementType("affiliations", Namespaces.PUBSUB, typeof(Affiliations));
        AddElementType("configure", Namespaces.PUBSUB, typeof(protocol.extensions.pubsub.Configure));
        AddElementType("create", Namespaces.PUBSUB, typeof(Create));
        AddElementType("configure", Namespaces.PUBSUB, typeof(protocol.extensions.pubsub.Configure));
        AddElementType("item", Namespaces.PUBSUB, typeof(protocol.extensions.pubsub.Item));
        AddElementType("items", Namespaces.PUBSUB, typeof(protocol.extensions.pubsub.Items));
        AddElementType("options", Namespaces.PUBSUB, typeof(Options));
        AddElementType("publish", Namespaces.PUBSUB, typeof(Publish));
        AddElementType("pubsub", Namespaces.PUBSUB, typeof(protocol.extensions.pubsub.PubSub));
        AddElementType("retract", Namespaces.PUBSUB, typeof(Retract));
        AddElementType("subscribe", Namespaces.PUBSUB, typeof(Subscribe));
        AddElementType("subscribe-options", Namespaces.PUBSUB, typeof(SubscribeOptions));
        AddElementType("subscription", Namespaces.PUBSUB, typeof(Subscription));
        AddElementType("subscriptions", Namespaces.PUBSUB, typeof(Subscriptions));
        AddElementType("unsubscribe", Namespaces.PUBSUB, typeof(Unsubscribe));

        // HTTP Binding XEP-0124
        AddElementType("body", Namespaces.HTTP_BIND, typeof(protocol.extensions.bosh.Body));

        // Message receipts XEP-0184
        AddElementType("received", Namespaces.MSG_RECEIPT, typeof(Received));
        AddElementType("request", Namespaces.MSG_RECEIPT, typeof(Request));

        // Bookmark storage XEP-0048         
        AddElementType("storage", Namespaces.STORAGE_BOOKMARKS, typeof(Storage));
        AddElementType("url", Namespaces.STORAGE_BOOKMARKS, typeof(Url));
        AddElementType("conference",
                       Namespaces.STORAGE_BOOKMARKS,
                       typeof(protocol.extensions.bookmarks.Conference));

        // XEP-0047: In-Band Bytestreams (IBB)
        AddElementType("open", Namespaces.IBB, typeof(Open));
        AddElementType("data", Namespaces.IBB, typeof(protocol.extensions.ibb.Data));
        AddElementType("close", Namespaces.IBB, typeof(Close));

        // XEP-0153: vCard-Based Avatars
        AddElementType("x", Namespaces.VCARD_UPDATE, typeof(VcardUpdate));

        // AMP
        AddElementType("amp", Namespaces.AMP, typeof(Amp));
        AddElementType("rule", Namespaces.AMP, typeof(Rule));

        // XEP-0202: Entity Time
        AddElementType("time", Namespaces.ENTITY_TIME, typeof(EntityTime));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds new Element Types to the Hashtable
    /// Use this function also to register your own created Elements.
    /// If a element is already registered it gets overwritten. This behaviour is also useful if you you want to overwrite
    /// classes and add your own derived classes to the factory.
    /// </summary>
    /// <param name="tag">
    /// FQN
    /// </param>
    /// <param name="ns">
    /// </param>
    /// <param name="t">
    /// </param>
    public static void AddElementType(string tag, string ns, Type t)
    {
        var et = new ElementType(tag, ns);
        string key = et.ToString();

        // added thread safety on a user request
        lock (m_table)
        {
            if (m_table.ContainsKey(key))
            {
                m_table[key] = t;
            }
            else
            {
                m_table.Add(et.ToString(), t);
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="prefix">
    /// </param>
    /// <param name="tag">
    /// </param>
    /// <param name="ns">
    /// </param>
    /// <returns>
    /// </returns>
    public static Element GetElement(string prefix, string tag, string ns)
    {
        if (ns == null)
        {
            ns = string.Empty;
        }

        var et = new ElementType(tag, ns);
        var t = (Type)m_table[et.ToString()];

        Element ret;
        if (t != null)
        {
            ret = (Element)Activator.CreateInstance(t);
        }
        else
        {
            ret = new Element(tag);
        }

        ret.Prefix = prefix;

        if (ns != string.Empty)
        {
            ret.Namespace = ns;
        }

        return ret;
    }

    public static string GetElementNamespace(Type type)
    {
        foreach (DictionaryEntry entry in m_table)
        {
            if ((Type)entry.Value == type)
            {
                var name = (string)entry.Key;

                return name.Contains(':') 
                    ? name.Substring(0, name.LastIndexOf(':')) 
                    : null;
            }
        }
        return null;
    }

    #endregion
}