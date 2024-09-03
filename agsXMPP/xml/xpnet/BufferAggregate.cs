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

#endregion

namespace agsXMPP.Xml.XpNet;

#region usings



#endregion

/// <summary>
/// Aggregate byte arrays together, so we can parse across IP packet boundaries
/// </summary>
public class BufferAggregate
{
    #region Members

    /// <summary>
    /// </summary>
    private readonly MemoryStream _stream = new();

    /// <summary>
    /// </summary>
    private BufNode? _head;

    /// <summary>
    /// </summary>
    private BufNode? _tail;

    #endregion

    #region Methods

    /// <summary>
    /// Write to the buffer.  Please make sure that you won't use this memory any more after you hand it in.  
    /// It will get mangled.
    /// </summary>
    /// <param name="buf">
    /// </param>
    public void Write(byte[] buf)
    {
        _stream.Write(buf, 0, buf.Length);

        if (_tail == null)
        {
            _head = _tail = new BufNode();
            _head.buf = buf;
        }
        else
        {
            var n = new BufNode
            {
                buf = buf
            };
            _tail.next = n;
            _tail = n;
        }
    }

    /// <summary>
    /// Get the current aggregate contents of the buffer.
    /// </summary>
    /// <returns>
    /// </returns>
    public byte[] GetBuffer()
    {
        return _stream.ToArray();
    }

    /// <summary>
    /// Clear the first "offset" bytes of the buffer, so they won't be parsed again.
    /// </summary>
    /// <param name="offset">
    /// </param>
    public void Clear(int offset)
    {
        int s = 0;
        int save = -1;

        BufNode bn = null;
        for (bn = _head; bn != null; bn = bn.next)
        {
            if (s + bn.buf.Length <= offset)
            {
                if (s + bn.buf.Length == offset)
                {
                    bn = bn.next;
                    break;
                }

                s += bn.buf.Length;
            }
            else
            {
                save = s + bn.buf.Length - offset;
                break;
            }
        }

        _head = bn;
        if (_head == null)
        {
            _tail = null;
        }

        if (save > 0)
        {
            var buf = new byte[save];
            Buffer.BlockCopy(_head.buf, _head.buf.Length - save, buf, 0, save);
            _head.buf = buf;
        }

        _stream.SetLength(0);
        for (bn = _head; bn != null; bn = bn.next)
        {
            _stream.Write(bn.buf, 0, bn.buf.Length);
        }
    }

    /// <summary>
    /// UTF8 encode the current contents of the buffer.  Just for prettiness in the debugger.
    /// </summary>
    /// <returns>
    /// </returns>
    public override string ToString()
    {
        byte[] b = GetBuffer();
        return System.Text.Encoding.UTF8.GetString(b, 0, b.Length);
    }

    #endregion

    // RingBuffer of the Nieblung

    #region Nested type: BufNode

    /// <summary>
    /// </summary>
    private class BufNode
    {
        #region Members

        /// <summary>
        /// </summary>
        public byte[] buf;

        /// <summary>
        /// </summary>
        public BufNode next;

        #endregion
    }

    #endregion
}