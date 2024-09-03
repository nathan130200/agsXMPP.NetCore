#region Using directives

#endregion

namespace agsXMPP.protocol.component;

using client;

/// <summary>
/// Summary description for Iq.
/// </summary>
public class IQ : client.IQ
{
    #region << Constructors >>
    public IQ() : base()
    {
        this.Namespace = Namespaces.ACCEPT;
    }

    public IQ(IqType type) : base(type)
    {
        this.Namespace = Namespaces.ACCEPT;
    }

    public IQ(Jid from, Jid to) : base(from, to)
    {
        this.Namespace = Namespaces.ACCEPT;
    }

    public IQ(IqType type, Jid from, Jid to) : base(type, from, to)
    {
        this.Namespace = Namespaces.ACCEPT;
    }
    #endregion

    /// <summary>
    /// Error Child Element
    /// </summary>
    public new Error Error
    {
        get
        {
            return SelectSingleElement(typeof(Error)) as Error;

        }
        set
        {
            if (HasTag(typeof(Error)))
                RemoveTag(typeof(Error));

            if (value != null)
                this.AddChild(value);
        }
    }
}
