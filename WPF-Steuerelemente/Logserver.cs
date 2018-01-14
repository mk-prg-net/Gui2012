using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Steuerelemente
{
    public class Logserver
    {
        System.Windows.Controls.ListBox _lbx;

        public Logserver(ListBox lbx)
        {
            _lbx = lbx;
        }

        public void log(LogMsg msg) {
            if (_lbx.CheckAccess())
                _lbx.Items.Add(msg.MsgLbxItem);
            else
                _lbx.Dispatcher.Invoke(new Action<ListBoxItem>(it => _lbx.Items.Add(it)), new object[] { msg.MsgLbxItem});
        }

        public class LogMsg
        {
            public LogMsg(string msg)
            {
                _msg = msg;
            }
            string _msg;

            public ListBoxItem MsgLbxItem
            {
                get
                {
                    StackPanel sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;

                    Image img = GetMsgSymbol();
                    sp.Children.Add(img);

                    Label lbl = new Label();
                    lbl.Content = string.Format("{0:hh.mm.ss} {1}", DateTime.Now, _msg);
                    sp.Children.Add(lbl);

                    ListBoxItem item = new ListBoxItem();
                    item.Content = sp;
                    return item;
                }
            }

            protected virtual Image GetMsgSymbol()
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("pack://application:,,,/WPF-Steuerelemente;component/Flag_greenHS.png"));
                return img;
            }
        }

        public class ErrorMsg : LogMsg
        {
            public ErrorMsg(string msg) : base(msg) { }
            protected override Image GetMsgSymbol()
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("pack://application:,,,/WPF-Steuerelemente;component/Flag_redHS.png"));
                return img;
            }
        }

        public class StatusMsg : LogMsg
        {
            public StatusMsg(string msg) : base(msg) { }
            protected override Image GetMsgSymbol()
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("pack://application:,,,/WPF-Steuerelemente;component/Flag_blueHS.png"));
                return img;
            }
        }
    }
}
