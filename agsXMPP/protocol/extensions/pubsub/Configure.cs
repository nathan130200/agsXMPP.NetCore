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

using agsXMPP.protocol.x.data;

#endregion

namespace agsXMPP.protocol.extensions.pubsub;

public class Configure : PubSubAction
{
    #region << Constructors >>

    public Configure() : base()
    {
        TagName = "configure";
    }

    public Configure(string node) : this()
    {
        Node = node;
    }

    public Configure(Type type) : this()
    {
        Type = type;
    }

    public Configure(string node, Type type) : this(node)
    {
        Type = type;
    }

    #endregion

    public Access Access
    {
        get { return (Access) GetAttributeEnum("access", typeof (Access)); }
        set
        {
            if (value == Access.NONE)
                RemoveAttribute("access");
            else
                SetAttribute("access", value.ToString());
        }
    }

    /// <summary>
    /// The x-Data Element
    /// </summary>
    public Data Data
    {
        get { return SelectSingleElement(typeof (Data)) as Data; }
        set
        {
            if (HasTag(typeof (Data)))
                RemoveTag(typeof (Data));

            if (value != null)
                AddChild(value);
        }
    }
}