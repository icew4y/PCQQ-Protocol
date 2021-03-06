﻿using QQ.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQ.Framework.Packets.Receive.Message
{
    /// <summary>
    /// 通用响应
    /// </summary>
    public class Receive_Currency : ReceivePacket
    {
        /// <summary>
        /// 通用响应
        /// </summary>
        public Receive_Currency(byte[] byteBuffer, QQUser User)
            : base(byteBuffer, User, User.QQ_SessionKey)
        {
        }

        protected override void ParseBody()
        {
            Decrypt(user.QQ_SessionKey);
        }
    }
}