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

namespace agsXMPP.protocol.extensions.si;

using featureneg;
using filetransfer;
using Xml.Dom;

/// <summary>
/// JEP-0095: Stream Initiation.
/// This JEP defines a protocol for initiating a stream (with meta information) between any two Jabber entities.
/// </summary>
public class SI : Element
	{
		public SI()
		{
			this.TagName	= "si";
			this.Namespace	= Namespaces.SI;
		}

		//id='a0'
		//mime-type='text/plain'

		/// <summary>
		/// The "id" attribute is an opaque identifier. 
		/// This attribute MUST be present on type='set', and MUST be a valid string. 
		/// This SHOULD NOT be sent back on type='result', since the &lt;iq/&gt; "id" attribute provides the only context needed.
		/// This value is generated by the Sender, and the same value MUST be used throughout a session when talking to the Receiver.
		/// </summary>
		public string Id
		{
			get { return GetAttribute("id"); }
			set { SetAttribute("id", value); }
		}

		/// <summary>
		/// The "mime-type" attribute identifies the MIME-type for the data across the stream.
		/// This attribute MUST be a valid MIME-type as registered with the Internet Assigned Numbers Authority (IANA) [3] 
		/// (specifically, as listed at "http://www.iana.org/assignments/media-types"). 
		/// During negotiation, this attribute SHOULD be present, and is otherwise not required. 
		/// If not included during negotiation, its value is assumed to be "binary/octect-stream".
		/// </summary>
		public string MimeType
		{
			get { return GetAttribute("mime-type"); }
			set { SetAttribute("mime-type", value); }
		}

		/// <summary>
		/// The "profile" attribute defines the SI profile in use. This value MUST be present during negotiation,
		/// and is the namespace of the profile to use.
		/// </summary>
		public string Profile
		{
			get { return GetAttribute("profile"); }
			set { SetAttribute("profile", value); }
		}


    /// <summary>
    /// the FeatureNeg Element 
    /// </summary>
    public FeatureNeg FeatureNeg
    {
        get
        {
            return SelectSingleElement(typeof(FeatureNeg)) as FeatureNeg;
        }
        set
        {
            if (HasTag(typeof(FeatureNeg)))
                RemoveTag(typeof(FeatureNeg));

            if (value != null)
                this.AddChild(value);
        }
    }

    /// <summary>
    /// the File Element
    /// </summary>
    public File File
    {
        get
        {
            return SelectSingleElement(typeof(File)) as File;
        }
        set
        {
            if (HasTag(typeof(File)))
                RemoveTag(typeof(File));

            if (value != null)
                this.AddChild(value);
        }
    }

	}
