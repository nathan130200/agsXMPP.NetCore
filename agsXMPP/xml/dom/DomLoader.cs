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

using System.Text;

#endregion

namespace agsXMPP.Xml.Dom;

#region usings



#endregion

/// <summary>
/// internal class that loads a xml document from a string or stream
/// </summary>
public class DomLoader
{
    #region Members

    /// <summary>
    /// </summary>
    private readonly Document doc;

    /// <summary>
    /// </summary>
    private readonly StreamParser sp;

    #endregion

    #region Constructor

    /// <summary>
    /// </summary>
    /// <param name="xml">
    /// </param>
    /// <param name="d">
    /// </param>
    public DomLoader(string xml, Document d)
    {
        doc = d;
        sp = new StreamParser();

        sp.OnStreamStart += sp_OnStreamStart;
        sp.OnStreamElement += sp_OnStreamElement;
        sp.OnStreamEnd += sp_OnStreamEnd;

        byte[] b = Encoding.UTF8.GetBytes(xml);
        sp.Push(b, 0, b.Length);
    }

    /// <summary>
    /// </summary>
    /// <param name="sr">
    /// </param>
    /// <param name="d">
    /// </param>
    public DomLoader(StreamReader sr, Document d) : this(sr.ReadToEnd(), d)
    {
    }

    #endregion

    #region Utility methods

    /// <summary>
    /// </summary>
    /// <param name="sender">
    /// </param>
    /// <param name="e">
    /// </param>
    private void sp_OnStreamStart(object sender, Node e)
    {
        doc.ChildNodes.Add(e);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender">
    /// </param>
    /// <param name="e">
    /// </param>
    private void sp_OnStreamElement(object sender, Node e)
    {
        doc.RootElement.ChildNodes.Add(e);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender">
    /// </param>
    /// <param name="e">
    /// </param>
    private void sp_OnStreamEnd(object sender, Node e)
    {
    }

    #endregion

    // ya, the Streamparser is only usable for parsing xmpp stream.
    // it also does a very good job here
}