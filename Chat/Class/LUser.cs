using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace SkynetChat
{
    public class LUser : User
    {
        public delegate void OnReadInfoEventHandler(LUser user);

        public delegate void OnDeviceInfoEventHandler(LUser user, Message m);

        public delegate void OnStatusHistoryEventHandler(LUser user, string statusMessage);

        public delegate void OnLastStatusEventHandler(LUser user, string statusMessage);

        public delegate void OnActiveDeviceEventHandler(LUser user, string type);

        [CompilerGenerated]
        private OnReadInfoEventHandler OnReadInfoEvent;

        [CompilerGenerated]
        private OnDeviceInfoEventHandler OnDeviceInfoEvent;

        [CompilerGenerated]
        private OnStatusHistoryEventHandler OnStatusHistoryEvent;

        [CompilerGenerated]
        private OnLastStatusEventHandler OnLastStatusEvent;

        [CompilerGenerated]
        private OnActiveDeviceEventHandler OnActiveDeviceEvent;

        [CompilerGenerated]
        private string _Gender;

        [CompilerGenerated]
        private string _PhotoKey;

        [CompilerGenerated]
        private string _PhotoLetterKey;

        [CompilerGenerated]
        private string _Email;

        [CompilerGenerated]
        private string _Phone;

        [CompilerGenerated]
        private string _SystemUserName;

        [CompilerGenerated]
        private string _HostName;

        [CompilerGenerated]
        private string _HostIP;

        [CompilerGenerated]
        private string _HostIP4;

        [CompilerGenerated]
        private bool _IsReadInfo;

        [CompilerGenerated]
        private string _ChatFormat;

        [CompilerGenerated]
        private bool _IsPeerOnline;

        private string _activeDevice;

        public string Gender
        {
            get;
            set;
        }

        public string PhotoKey
        {
            get;
            set;
        }

        public string PhotoLetterKey
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string MachineName
        {
            get;
            set;
        }
        public int ColorId
        {
            get;
            set;
        }
        public bool FormInactivo
        {
            get;
            set;
        }
        public int AvatarLength
        {
            get;
            set;
        }

        public string SystemUserName
        {
            get;
            set;
        }

        public string HostName
        {
            get;
            set;
        }

        public string HostIP
        {
            get;
            set;
        }

        public string HostIP4
        {
            get;
            set;
        }

        public bool IsReadInfo
        {
            get;
            set;
        }

        public string ChatFormat
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public bool IsPeerOnline
        {
            get;
            set;
        }

        public string ActiveDevice
        {
            get
            {
                return _activeDevice;
            }
            set
            {
                _activeDevice = value;
            }
        }

        public event OnReadInfoEventHandler OnReadInfo
        {
            [CompilerGenerated]
            add
            {
                OnReadInfoEventHandler onReadInfoEventHandler = OnReadInfoEvent;
                OnReadInfoEventHandler onReadInfoEventHandler2;
                do
                {
                    onReadInfoEventHandler2 = onReadInfoEventHandler;
                    OnReadInfoEventHandler value2 = (OnReadInfoEventHandler)Delegate.Combine(onReadInfoEventHandler2, value);
                    onReadInfoEventHandler = Interlocked.CompareExchange(ref OnReadInfoEvent, value2, onReadInfoEventHandler2);
                }
                while ((object)onReadInfoEventHandler != onReadInfoEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnReadInfoEventHandler onReadInfoEventHandler = OnReadInfoEvent;
                OnReadInfoEventHandler onReadInfoEventHandler2;
                do
                {
                    onReadInfoEventHandler2 = onReadInfoEventHandler;
                    OnReadInfoEventHandler value2 = (OnReadInfoEventHandler)Delegate.Remove(onReadInfoEventHandler2, value);
                    onReadInfoEventHandler = Interlocked.CompareExchange(ref OnReadInfoEvent, value2, onReadInfoEventHandler2);
                }
                while ((object)onReadInfoEventHandler != onReadInfoEventHandler2);
            }
        }

        public event OnDeviceInfoEventHandler OnDeviceInfo
        {
            [CompilerGenerated]
            add
            {
                OnDeviceInfoEventHandler onDeviceInfoEventHandler = OnDeviceInfoEvent;
                OnDeviceInfoEventHandler onDeviceInfoEventHandler2;
                do
                {
                    onDeviceInfoEventHandler2 = onDeviceInfoEventHandler;
                    OnDeviceInfoEventHandler value2 = (OnDeviceInfoEventHandler)Delegate.Combine(onDeviceInfoEventHandler2, value);
                    onDeviceInfoEventHandler = Interlocked.CompareExchange(ref OnDeviceInfoEvent, value2, onDeviceInfoEventHandler2);
                }
                while ((object)onDeviceInfoEventHandler != onDeviceInfoEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnDeviceInfoEventHandler onDeviceInfoEventHandler = OnDeviceInfoEvent;
                OnDeviceInfoEventHandler onDeviceInfoEventHandler2;
                do
                {
                    onDeviceInfoEventHandler2 = onDeviceInfoEventHandler;
                    OnDeviceInfoEventHandler value2 = (OnDeviceInfoEventHandler)Delegate.Remove(onDeviceInfoEventHandler2, value);
                    onDeviceInfoEventHandler = Interlocked.CompareExchange(ref OnDeviceInfoEvent, value2, onDeviceInfoEventHandler2);
                }
                while ((object)onDeviceInfoEventHandler != onDeviceInfoEventHandler2);
            }
        }

        public event OnStatusHistoryEventHandler OnStatusHistory
        {
            [CompilerGenerated]
            add
            {
                OnStatusHistoryEventHandler onStatusHistoryEventHandler = OnStatusHistoryEvent;
                OnStatusHistoryEventHandler onStatusHistoryEventHandler2;
                do
                {
                    onStatusHistoryEventHandler2 = onStatusHistoryEventHandler;
                    OnStatusHistoryEventHandler value2 = (OnStatusHistoryEventHandler)Delegate.Combine(onStatusHistoryEventHandler2, value);
                    onStatusHistoryEventHandler = Interlocked.CompareExchange(ref OnStatusHistoryEvent, value2, onStatusHistoryEventHandler2);
                }
                while ((object)onStatusHistoryEventHandler != onStatusHistoryEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnStatusHistoryEventHandler onStatusHistoryEventHandler = OnStatusHistoryEvent;
                OnStatusHistoryEventHandler onStatusHistoryEventHandler2;
                do
                {
                    onStatusHistoryEventHandler2 = onStatusHistoryEventHandler;
                    OnStatusHistoryEventHandler value2 = (OnStatusHistoryEventHandler)Delegate.Remove(onStatusHistoryEventHandler2, value);
                    onStatusHistoryEventHandler = Interlocked.CompareExchange(ref OnStatusHistoryEvent, value2, onStatusHistoryEventHandler2);
                }
                while ((object)onStatusHistoryEventHandler != onStatusHistoryEventHandler2);
            }
        }

        public event OnLastStatusEventHandler OnLastStatus
        {
            [CompilerGenerated]
            add
            {
                OnLastStatusEventHandler onLastStatusEventHandler = OnLastStatusEvent;
                OnLastStatusEventHandler onLastStatusEventHandler2;
                do
                {
                    onLastStatusEventHandler2 = onLastStatusEventHandler;
                    OnLastStatusEventHandler value2 = (OnLastStatusEventHandler)Delegate.Combine(onLastStatusEventHandler2, value);
                    onLastStatusEventHandler = Interlocked.CompareExchange(ref OnLastStatusEvent, value2, onLastStatusEventHandler2);
                }
                while ((object)onLastStatusEventHandler != onLastStatusEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnLastStatusEventHandler onLastStatusEventHandler = OnLastStatusEvent;
                OnLastStatusEventHandler onLastStatusEventHandler2;
                do
                {
                    onLastStatusEventHandler2 = onLastStatusEventHandler;
                    OnLastStatusEventHandler value2 = (OnLastStatusEventHandler)Delegate.Remove(onLastStatusEventHandler2, value);
                    onLastStatusEventHandler = Interlocked.CompareExchange(ref OnLastStatusEvent, value2, onLastStatusEventHandler2);
                }
                while ((object)onLastStatusEventHandler != onLastStatusEventHandler2);
            }
        }

        public event OnActiveDeviceEventHandler OnActiveDevice
        {
            [CompilerGenerated]
            add
            {
                OnActiveDeviceEventHandler onActiveDeviceEventHandler = OnActiveDeviceEvent;
                OnActiveDeviceEventHandler onActiveDeviceEventHandler2;
                do
                {
                    onActiveDeviceEventHandler2 = onActiveDeviceEventHandler;
                    OnActiveDeviceEventHandler value2 = (OnActiveDeviceEventHandler)Delegate.Combine(onActiveDeviceEventHandler2, value);
                    onActiveDeviceEventHandler = Interlocked.CompareExchange(ref OnActiveDeviceEvent, value2, onActiveDeviceEventHandler2);
                }
                while ((object)onActiveDeviceEventHandler != onActiveDeviceEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnActiveDeviceEventHandler onActiveDeviceEventHandler = OnActiveDeviceEvent;
                OnActiveDeviceEventHandler onActiveDeviceEventHandler2;
                do
                {
                    onActiveDeviceEventHandler2 = onActiveDeviceEventHandler;
                    OnActiveDeviceEventHandler value2 = (OnActiveDeviceEventHandler)Delegate.Remove(onActiveDeviceEventHandler2, value);
                    onActiveDeviceEventHandler = Interlocked.CompareExchange(ref OnActiveDeviceEvent, value2, onActiveDeviceEventHandler2);
                }
                while ((object)onActiveDeviceEventHandler != onActiveDeviceEventHandler2);
            }
        }

        public LUser()
        {
            ChatFormat = string.Empty;
        }

        public void RaiseEvent_OnReadInfo()
        {
            OnReadInfoEvent?.Invoke(this);
        }

        public void RaiseEvent_OnDeviceInfo(Message m)
        {
            OnDeviceInfoEvent?.Invoke(this, m);
        }

        public void RaiseEvent_OnStatusHistory(string message)
        {
            OnStatusHistoryEvent?.Invoke(this, message);
        }

        public void RaiseEvent_OnLastStatus(string message)
        {
            OnLastStatusEvent?.Invoke(this, message);
        }
    }
    public class User : UserInfo
    {
    }
    public class UserInfo
    {

        private string _status;

        private UserStatus _userStatus;

        [CompilerGenerated]
        private string _Name;

        [CompilerGenerated]
        private string _Groupname;

        [CompilerGenerated]
        private long _UserId;

        [CompilerGenerated]
        private string _Key;

        [CompilerGenerated]
        private string _PersonalMessage;

        [CompilerGenerated]
        private DateTime _StatusTime;

        [CompilerGenerated]
        private bool _IsStatusRequested;

        [CompilerGenerated]
        private bool _IsFilterUser;

        private short _networkID;

        public string Name
        {
            get;
            set;
        }

        public string Groupname
        {
            get;
            set;
        }

        public long UserId
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public string PersonalMessage
        {
            get;
            set;
        }
        private string _pm;
        public string GetPersonalMessage()
        {
            if (UserStatus == UserStatus.Online)
                _pm = "Online";
            if (UserStatus == UserStatus.Activo)
                _pm = "Activo";
            if (UserStatus == UserStatus.Ocupado)
                _pm = "Ocupado";
            if (UserStatus == UserStatus.Ausente)
                _pm = "Ausente";
            if (string.IsNullOrEmpty(_pm))
                _pm = "Desconocido";
            if (UserStatus == UserStatus.Idle)
                _pm = "Inactivo desde " + GetTimeIdle();


            return _pm;
        }
        private string GetTimeIdle()
        {
            string message;

            string time = DateTime.Now.ToShortTimeString();
            if (time.StartsWith("1:"))
                message = "la " + time;
            else
                message = "las " + time;

            return message;
        }
        public DateTime StatusTime
        {
            get;
            set;
        }

        public bool IsStatusRequested
        {
            get;
            set;
        }

        public bool IsFilterUser
        {
            get;
            set;
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                StatusToUserStatus(Status);
            }
        }

        public UserStatus UserStatus
        {
            get
            {
                return _userStatus;
            }
            set
            {
                _userStatus = value;
                UserStatusToStatus(value);

                    if (UserStatus == UserStatus.Activo)
                    PersonalMessage = "Activo";
                    if (UserStatus == UserStatus.Ocupado)
                    PersonalMessage = "Ocupado";
                    if (UserStatus == UserStatus.Ausente)
                    PersonalMessage = "Ausente";
            }
        }

        public short NetworkID
        {
            get
            {
                return _networkID;
            }
            set
            {
                bool num = _networkID != value;
                _networkID = value;
                if (num)
                {
                    //UserServices.RaiseEvent_OnNetworkIDChange(this);
                }
            }
        }

        private long result;
        private long GetUserID(string data)
        {
            long.TryParse(data.Split('@')[0], out result);
            return result;
        }
        private void StatusToUserStatus(string status)
        {
            switch (status)
            {
                case "Activo":
                    _userStatus = UserStatus.Activo;
                    break;
                case "Ocupado":
                    _userStatus = UserStatus.Ocupado;
                    break;
                case "Ausente":
                    _userStatus = UserStatus.Ausente;
                    break;
            }
        }

        private void UserStatusToStatus(UserStatus userStatus)
        {
            switch (userStatus)
            {
                case UserStatus.Activo:
                    _status = "Activo";
                    break;
                case UserStatus.Ocupado:
                    _status = "Ocupado";
                    break;
                case UserStatus.Ausente:
                    _status = "Ausente";
                    break;
                case UserStatus.Busy:
                    _status = "dnd";
                    break;
                case UserStatus.Idle:
                    _status = "away";
                    break;
                case UserStatus.Lunch:
                    _status = "lunch";
                    break;
                case UserStatus.Meeting:
                    _status = "meet";
                    break;
                case UserStatus.SteppedOut:
                    _status = "xa";
                    break;
                case UserStatus.Offline:
                    _status = "F";
                    break;
                case UserStatus.Mobile:
                    _status = "mobile";
                    break;
                case UserStatus.Online:
                    _status = string.Empty;
                    break;
                default:
                    _status = string.Empty;
                    break;
            }
        }

    }

}