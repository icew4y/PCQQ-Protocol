﻿using QQ.Framework.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQ.Framework.Packets.Receive.Data
{
    public class Receive_0x001D : ReceivePacket
    {
        /// <summary>
        /// 改变在线状态
        /// </summary>
        public Receive_0x001D(byte[] byteBuffer, QQUser User)
            : base(byteBuffer, User, User.QQ_SessionKey)
        {
        }

        protected override void ParseBody()
        {
            Decrypt(user.QQ_SessionKey);
            reader.ReadBytes(4);
            user.QQ_Skey = Encoding.UTF8.GetString(reader.ReadBytes(10));
            if (string.IsNullOrEmpty(user.QQ_Skey))
            {
                throw new Exception("skey获取失败");
            }

            user.QQ_Cookies = "uin=o" + user.QQ + ";skey=" + user.QQ_Skey + ";";
            user.QQ_Gtk = Util.GET_GTK(user.QQ_Skey);
        }
    }
}