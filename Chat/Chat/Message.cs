using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json;
using Chat.Class;
using Chat.Properties;
using static Chat.frmMain;

// []   |||   &&


namespace Chat
{
    public class SmallMessage
    {
        public string Handle { get; set; }
        public string typeMessage { get; set; }
        public string content { get; set; }
        public int ColorID { get; set; }
        public string ID { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
    public class Message
    {
        public string Handle { get; set; }
        public string typeMessage { get; set; }
        public string content { get; set; }
        public int ColorID { get; set; }
        public string MachineName { get; set; }
        public string IP { get; set; }
        public string ID { get; set; }
        public string State { get; set; }
        public string FormActivo { get; set; }
        public int AvatarLength { get; set; }
        public static string handle { get; set; }
        public string ConnectedTime { get; set; }
        public string IdleTime { get; set; }


        private SoundPlayer beep;  //Sonido
        private List<Usuarios> Ussuario = new List<Usuarios>();

        public string ToJson() {
            return JsonConvert.SerializeObject(this);

        }
        private Message ReceivedMessage { get; set; }
        public void ToMessageString()
        {
            //MessageBox.Show(typeMessage);
            switch (typeMessage)
            {

                case "m":// Message
                    //               ComprobarUser();
                    if (content == "jajaja" || content == "jeje" || content == "haaa" || content == "ª" || content == "bye")
                    {
                        SmileDirecto(content);
                    }
                    else if (content == "Mute" || content == "MuteOff")
                    {
                        Mute(content);
                    }
                    else
                    {
                        WriteChatMessages(5, ID, this.content, this.ColorID, Handle);
                    }
                    break;
                ///////////////////

                case "Ingreso":
                    Ingreso();
                    break;

                case "MyUser":
                    MyUser();
                    break;

                case "RecargarLista":
                    RecargarLista();
                    break;

                case "Desconecto":
                    Desconecto();
                    break;

                case "beep":
                    Beep(content);
                    break;

                case "Activo":
                    Activo();
                    break;

                case "Ocupado":
                    Ocupado();
                    break;

                case "Ausente":
                    Ausente();
                    break;

                case "Idle":
                    Idle();
                    break;

                case "MP":
                    MP(content);
                    break;

                case "Update":
                    upDate(content);
                    break;

                case "NickChange":
                    NickChange(content);
                    break;

                case "FormActivo":
                    FActivo();
                    break;

                case "FormInactivo":
                    FInactivo();
                    break;

                case "FormStatus":
                    FormStatus(ID, Modcommon.ConvertToBool(content));
                    break;

                case "Ping":
                    Ping();
                    break;

                case "Smile":
                    Smile(content);
                    break;

                case "Escribiendo":
                    Escribiendo();
                    break;

                case "GetAvatar":
                    GetAvatar(content);
                    break;

                case "Mute":
                    Mute(content);
                    break;

                case "GiveInfo":
                    GiveInfo(content);
                    break;

                case "Info":
                    Info(content);
                    break;

                case "Control":
                    Control(content);
                    break;

                case "buzz":
                    Buzz(content);
                    break;

                case "GiveChat":
                    GiveChat(content);
                    break;

                case "Exit":
                    Exit(content);
                    break;

                case "ChatResult":
                    ChatResult(content);
                    break;

                case "ScreenShot":
                    ScreenShot(content);
                    break;

                case "GiveDateTime":
                    GiveDateTime(content);
                    break;

                case "DateTimeResult":
                    DateTimeResult(content);
                    break;

                case "Drag":
                    Drag(content);
                    break;

                case "TT_File":
                    TT_File(content);
                    break;

                case "Test":
                    Test(content);
                    break;

                case "Log":
                    Log(content);
                    break;

                case "cp":
                    CP(content);
                    break;


            }
        }
        public static Image userPhoto;
        private void Ingreso()
        {
            if (ID == UserId)
                return;

            try
            {
                string userKey = ID;

                DataGridViewRow dataGridViewRow = (from DataGridViewRow r in frmMain.frm.UserList.Rows
                                                   where r.Cells[0].Value.ToString().Contains(userKey)
                                                   select r).FirstOrDefault();
                if (dataGridViewRow == null)
                {
                    userPhoto = LetterImage.GetUserImage(userKey, Handle);
                    int num = frmMain.frm.UserList.RowCount;
                    string[] objects = { Handle + Modcommon.TEXT_SEPARATOR + UserStatus.Online.ToString() +
                                         Modcommon.TEXT_SEPARATOR + (UserStatus.Online.ToString()) +
                                         Modcommon.TEXT_SEPARATOR + userKey + Modcommon.TEXT_SEPARATOR };
                    frmMain.frm.UserList.Rows.Add(objects);
                    frmMain.frm.UserList.Rows[num].Height = 54;
                    frmMain.frm.UserList.RowTemplate.Height = 54;
                    frmMain.frm.UserList[0, num].ReadOnly = true;
                    MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, num];
                    textAndImageCell.Image = Modcommon.CropToCircle(userPhoto);
                    textAndImageCell.Tag = "U";
                    textAndImageCell.User = true;
                    textAndImageCell.UserName = Handle;
                    textAndImageCell.UserId = userKey;
                    textAndImageCell.Status = UserStatus.Online;

                    textAndImageCell.AvatarLength = AvatarLength;
                    textAndImageCell.MachineName = MachineName;
                    textAndImageCell.ColorId = ColorID;
                    textAndImageCell.FormInactivo = Modcommon.ConvertToBool(FormActivo);
                    textAndImageCell.IP = IP;
                    textAndImageCell.ConnectedTime = ConnectedTime;

                    textAndImageCell.ToolTipText = "Apodo:  " + Handle + Environment.NewLine +
                    "PC:         " + MachineName + Environment.NewLine +
                    "IP:           " + IP + Environment.NewLine +
                    "Estado:   " + State.Replace("idle", "Inactivo") + Environment.NewLine +
                    "Conectado desde " + Modcommon.PrepareTime(ConnectedTime);


                    if (Modcommon.ConvertToBool(FormActivo) == false)
                        frmMain.frm.ChangeUserSelection(ID, false);

                    if (ID != UserId)
                    {
                        WriteChatMessages(2, ID, "" , ColorID);

                        if (NuevoUser)
                        {
                            frmMain.frm.Notificar(Handle + " se ha conectado al Chat", ID);
                        }

                        //beep = new SoundPlayer(Resources.Broadcast);
                        if (ID != UserId)
                        {
                            if (!Muted)
                                beep.Play();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
                return;
            }
            TransmitFull("MyUser");




            /*
        }
        catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        */
        }
        private void MyUser()
        {
            if (string.IsNullOrEmpty(ID))
                ID = AvatarLength.ToString();
            if (string.IsNullOrEmpty(ID))
                return;

            if (FormActivo == null)
                FormActivo = "true";

            try
            {
                string userKey = ID;
                DataGridViewRow dataGridViewRow = (from DataGridViewRow r in frmMain.frm.UserList.Rows
                                                   where r.Cells[0].Value.ToString().Contains(userKey)
                                                   select r).FirstOrDefault();
                if (dataGridViewRow == null)
                {
                    userPhoto = LetterImage.GetUserImage(userKey, Handle);
                    int num = frmMain.frm.UserList.RowCount;
                    string[] objects = { Handle + Modcommon.TEXT_SEPARATOR + State +
                                         Modcommon.TEXT_SEPARATOR + (Modcommon.GetPersonalMessage(Status.ToStatus(State), ID, IdleTime)) +
                                         Modcommon.TEXT_SEPARATOR + userKey + Modcommon.TEXT_SEPARATOR };
                    frmMain.frm.UserList.Rows.Add(objects);
                    frmMain.frm.UserList.Rows[num].Height = 54;
                    frmMain.frm.UserList.RowTemplate.Height = 54;
                    frmMain.frm.UserList[0, num].ReadOnly = true;
                    MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, num];
                    textAndImageCell.Image = Modcommon.CropToCircle(userPhoto);
                    textAndImageCell.Tag = "U";
                    textAndImageCell.User = true;
                    textAndImageCell.UserName = Handle;
                    textAndImageCell.UserId = userKey;
                    textAndImageCell.Status = Status.ToStatus(State);

                    textAndImageCell.AvatarLength = AvatarLength;
                    textAndImageCell.MachineName = MachineName;
                    textAndImageCell.ColorId = ColorID;
                    textAndImageCell.FormInactivo = Modcommon.ConvertToBool(FormActivo);
                    textAndImageCell.IP = IP;
                    textAndImageCell.ConnectedTime = ConnectedTime;

                    textAndImageCell.ToolTipText = "Apodo:  " + Handle + Environment.NewLine +
                    "PC:         " + MachineName + Environment.NewLine +
                    "IP:           " + IP + Environment.NewLine +
                    "Estado:   " + State.Replace("idle", "Inactivo") + Environment.NewLine +
                    "Conectado desde " + Modcommon.PrepareTime(ConnectedTime);

                    if (!Modcommon.ConvertToBool(FormActivo))
                        frmMain.frm.ChangeUserSelection(ID, false);

                    if (DateTimeZinc)
                    {
                        if (DateTimeChanged == false)
                        if (UserDateTimeZinc == ID)
                            Transmit("GiveDateTime", UserDateTimeZinc);
                    }

                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        private void RecargarLista()
        {
            if (ID == UserId)
                return;

            TransmitFull("MyUser");

            //AvatarManager.AnaliceAvatar(ID, Convert.ToInt32(content));
        }

        private void Desconecto()
        {
            try
            {
                //Eliminar Idle si existe
                WriteChatMessages(3, ID, "", ColorID);

                if (DesconectadoUser)
                {
                    frmMain.frm.Notificar(Handle + " se ha desconectado del Chat", ID);
                }

                //Eliminar del DataGrid
                frmMain.frm.RemoveUserFromGrid(ID);

                beep = new SoundPlayer(Resources.toSleep);
                if (!Muted)
                    beep.Play();
            }
            catch (Exception ex) { WriteLog.Save(ex); }
        }

        private void Ping()
        {
            try
            {
                if (ID != UserId)
                    TransmitFull("MyUser");
            }
            catch { }
        }

        private string mensaje;
        private void Beep(string Id)
        {
            try
            {
                if (Id == UserId)
                {
                    try
                    {
                        beep = new SoundPlayer(Application.StartupPath + @"\Smiles\beep.wav");
                        if (!Muted)
                            beep.Play();
                    }
                    catch
                    {
                        beep = new SoundPlayer(Resources.beep1);
                        if (!Muted)
                            beep.Play();
                    }
                    WriteChatMessages(4, ID, Handle + " te ha enviado un beep", this.ColorID);

                }
            }
            catch { }
        }
        private void Activo()
        {
            try
            {
                if (ID == UserId)
                    return;
                frmMain.frm.ChangePersonalMessageAndStatus(ID, UserStatus.Activo);
            }
            catch { }
            try
            {
                if (ID != UserId)
                    if (NotifyStatus)
                        frmMain.frm.Notificar(Handle + " esta activo", ID);
            }
            catch { }
        }
        private void Ocupado()
        {
            try
            {
                if (ID == UserId)
                    return;
                frmMain.frm.ChangePersonalMessageAndStatus(ID, UserStatus.Ocupado);
            }
            catch { }
            try
            {
                if (ID != UserId)
                    if (NotifyStatus)
                        frmMain.frm.Notificar(Handle + " esta ocupado", ID);
            }
            catch { }
        }
        private void Ausente()
        {
            try
            {
                if (ID == UserId)
                    return;
                frmMain.frm.ChangePersonalMessageAndStatus(ID, UserStatus.Ausente);
            }
            catch { }
            try
            {
                if (ID != UserId)
                    if (NotifyStatus)
                        frmMain.frm.Notificar(Handle + " esta ausente", ID);
            }
            catch { }

        }
        private void Idle()
        {
            try
            {
                frmMain.frm.ChangePersonalMessageAndStatus(ID, UserStatus.Idle, false, "", content);
            }
            catch { }
            try
            {
                if (ID != UserId)
                    if (NotifyStatus)
                        frmMain.frm.Notificar(Handle + " esta inactivo", ID);
            }
            catch { }

        }
        private void MP(string message)
        {
            try
            {
                string[] Datos = message.Split('◄');
                string To = Datos[0];
                string mensage = Datos[1];

                if (To == UserId)
                {
                    (new Thread(() => {
                        frmMP mensages = new frmMP();
                        mensages.WriteMessage(mensage, ID, ColorID);
                        mensages.ShowDialog();
                    })).Start();
                    WriteChatMessages(4, "Aviso", Modcommon.GetNamefromID(ID) + " te envió el mensage privado: <br><span Class='privatemessage-data'>" + mensage + "</span>", 0);
                }
            }
            catch { }
        }

        private void upDate(string ip)
        {
            try
            {
                RegistryKey Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat", true);
                Chat.GetValue("Patch", RegistryValueKind.String);
                string directorio = (string)Chat.GetValue("Patch");

                string Acceso = Environment.UserName.ToString();
                if (Acceso != "Hackerprod")
                {
                    if (ip == Modcommon.GetIp())
                    {
                        if (File.Exists(Application.StartupPath + @"\Updater.exe"))
                        {
                            Process.Start(Application.StartupPath + @"\Updater.exe");
                            Application.Exit();
                        }
                        else
                        {
                            Process.Start(directorio + @"\Updater.exe");
                            Application.Exit();
                        }
                    }
                    else if (ip == "")
                    {
                        if (File.Exists(Application.StartupPath + @"\Updater.exe"))
                        {
                            Process.Start(Application.StartupPath + @"\Updater.exe");
                            Application.Exit();
                        }
                        else
                        {
                            Process.Start(directorio + @"\Updater.exe");
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
        private void NickChange(string newName)
        {
            try
            {
                frmMain.frm.ChangePersonalMessageAndStatus(ID, Status.ToStatus(State), true, newName);
                WriteChatMessages(1, ID, newName, ColorID);
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }

        }
        private void Smile(string message)
        {
            try
            {

                if (message == null) return;
                string[] datos = message.Split(' ');
                string smilE = datos[0];
                string smile = smilE.Trim('_');
                smile = smile.Replace("p","");

                try
                {
                    //Name and Time
                    frmMain.frm.WriteChat(HtmlHelper.GetNameHtml(ID, DateTime.Now));

                    //Bubble Message 
                    frmMain.frm.WriteChat(HtmlHelper.GetSmileyMessage(ID, HtmlHelper.GetSmyleImage(smile)));

                    //Sonidos
                    if (smile == "06")
                    {
                        beep = new SoundPlayer(Resources.giggle2);
                        if (!Muted)
                            beep.Play();
                    }
                    else if (smile == "60")
                    {
                        beep = new SoundPlayer(Resources.ccgiggle);
                        if (!Muted)
                            beep.Play();
                    }
                    else if (smile == "11")
                    {
                        beep = new SoundPlayer(Resources.waaaahh_);
                        if (!Muted)
                            beep.Play();
                    }
                    else
                    {
                        beep = new SoundPlayer(Resources.beep1);
                        if (!Muted)
                            beep.Play();
                    }
                } catch (Exception ex) { frmMain.frm.Crearlog (ex); }
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }

        private string smile;
        private void SmileDirecto(string message)
        {
            try
            {
                string[] Datos = message.Split(' ');
                string nick = Datos[0];
                string Nick = nick.Trim(':');
                string codigo = Datos[0];

                if (codigo == "jajaja")
                    try
                    {
                        smile = "06";

                        beep = new SoundPlayer(Resources.giggle2);
                        if (!Muted)
                            beep.Play();
                    }
                    catch (Exception ex) { frmMain.frm.Crearlog(ex); }
                if (codigo == "jeje")
                    try
                    {
                        smile = "44";

                        beep = new SoundPlayer(Resources.ccgiggle);
                        if (!Muted)
                            beep.Play();
                    }
                    catch (Exception ex) { frmMain.frm.Crearlog(ex); }
                if (codigo == "haaa")
                    try
                    {
                        smile = "55";

                        try
                        {
                            beep = new SoundPlayer(Application.StartupPath + @"\Smiles\Guasha.wav");
                            if (!Muted)
                                beep.Play();
                        }
                        catch { }

                    }
                    catch (Exception ex) { frmMain.frm.Crearlog(ex); }
                if (codigo == "ª")
                    try
                    {
                        smile = "26";

                        try
                        {
                            beep = new SoundPlayer(Application.StartupPath + @"\Smiles\Guashaaa.wav");
                            if (!Muted)
                                beep.Play();
                        }
                        catch { }

                    }
                    catch (Exception ex) { frmMain.frm.Crearlog(ex); }
                if (codigo == "bye")
                    try
                    {
                        smile = "52";

                        try
                        {
                            beep = new SoundPlayer(Application.StartupPath + @"\Smiles\bye.wav");
                            if (!Muted)
                                beep.Play();
                        }
                        catch { }

                    }
                    catch (Exception ex) { frmMain.frm.Crearlog(ex); }

                //Name and Time
                frmMain.frm.WriteChat(HtmlHelper.GetNameHtml(ID, DateTime.Now));

                //Bubble Message 
                frmMain.frm.WriteChat(HtmlHelper.GetSmileyMessage(ID, HtmlHelper.GetSmyleImage(smile)));

            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
        private void FActivo()
        {
            try
            {
                frmMain.frm.ChangeUserSelection(ID, true);
            }
            catch (Exception ex) { frmMain.frm.Crearlog (ex); }
        }
        private void FInactivo()
        {
            try
            {
                frmMain.frm.ChangeUserSelection(ID, false);
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }

        }
        //FormStatus
        private void FormStatus(string userId, bool status)
        {
            try
            {
                frmMain.frm.ChangeUserSelection(userId, status);
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }

        }
        public void Escribiendo()
        {
            ListViewItem lv = frmMain.frm.usersWriting.FindItemWithText(ID);
            if (lv != null)
                lv.SubItems[0].Name = "5";

            else
            {
                //Creo el ListViewItem
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 0;

                //Agrego los subItems(Nombre y estado)
                ListViewItem.ListViewSubItem user = new ListViewItem.ListViewSubItem();
                lvi.SubItems.Add(user);

                //Asigno Name y Text a los subItems
                lvi.SubItems[0].Text = ID;
                lvi.SubItems[0].Name = "5";
                lvi.SubItems[0].Tag = Handle;                   //Borrar si algo
                frmMain.frm.usersWriting.Items.Add(lvi);
            }
            //Codigo para mensaje de usuario escribiendo

            //return;
            int escribiendo = frmMain.frm.usersWriting.Items.Count;
                if (escribiendo == 0)
                {
                    frmMain.frm.UsuarioEscribiendo.Text = "";
                }

            if (escribiendo == 1)
            {
                if (frmMain.frm.usersWriting.Items[0].Text != UserId)
                    frmMain.frm.UsuarioEscribiendo.Text = (string)frmMain.frm.usersWriting.Items[0].SubItems[0].Tag + " está escribiendo";


            }
            if (escribiendo == 2)
            {
                if (!frmMain.frm.UsuarioEscribiendo.Text.Contains((string)frmMain.frm.usersWriting.Items[1].SubItems[0].Tag) && !frmMain.frm.UsuarioEscribiendo.Text.Contains((string)frmMain.frm.usersWriting.Items[1].SubItems[0].Tag))
                {
                    if (frmMain.frm.usersWriting.Items[0].SubItems[0].Text == UserId)
                        frmMain.frm.UsuarioEscribiendo.Text = (string)frmMain.frm.usersWriting.Items[1].SubItems[0].Tag + " está escribiendo";
                    else if (frmMain.frm.usersWriting.Items[1].SubItems[0].Text == UserId)
                        frmMain.frm.UsuarioEscribiendo.Text = (string)frmMain.frm.usersWriting.Items[0].SubItems[0].Tag + " está escribiendo";
                    else
                        frmMain.frm.UsuarioEscribiendo.Text = (string)frmMain.frm.usersWriting.Items[0].SubItems[0].Tag + " y " + (string)frmMain.frm.usersWriting.Items[1].SubItems[0].Tag + " estan escribiendo";
                }
            }
            if (escribiendo > 2)
            {
                int EscMenos2 = escribiendo - 2;
                if (EscMenos2 == 1)
                    frmMain.frm.UsuarioEscribiendo.Text = frmMain.frm.usersWriting.Items[0].SubItems[0].Tag + ", " + frmMain.frm.usersWriting.Items[1].SubItems[0].Tag + " y " + EscMenos2.ToString() + " usuario estan escribiendo";
                else
                    frmMain.frm.UsuarioEscribiendo.Text = (string)frmMain.frm.usersWriting.Items[0].SubItems[0].Tag + ", " + frmMain.frm.usersWriting.Items[1].SubItems[0].Tag + " y " + EscMenos2.ToString() + " usuarios estan escribiendo";
            }
        }
        private void GetAvatar(string contenido)
        {
            return;
            string[] data = contenido.Split('◄');
            string Id = data[0];
            string ip = data[1];

            if (Id == UserId)
            {
                if (File.Exists(Path.Combine(Modcommon.AVATARDIR, Id) + ".jpg"))
                    AvatarManager.Send(Path.Combine(Modcommon.AVATARDIR, Id) + ".jpg", ip);
            }
        }
        private string MPrivado { get; set; }

        public string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            MPrivado = builder.ToString();
            return MPrivado;
        }
        private void Transmit(string typeMessage, string content = null)
        {
            frmMain.frm.Transmit(typeMessage, content);
        }
        private void TransmitFull(string typeMessage, string content = null)
        {
            frmMain.frm.TransmitFull(typeMessage, content);
        }
        private void Mute(string content)
        {
            try
            {
                if (content == "Mute")
                {
                    frmMain.frm.lblMuteUserPanel.Image = Resources.Notifyoff2; 
                    Muted = true;
                    WriteChatMessages(4, this.ID, "El Administrador del Chat ha desactivado el sonido", this.ColorID);
                }
                if (content == "MuteOff")
                {
                    frmMain.frm.lblMuteUserPanel.Image = Resources.Notifyon2;
                    Muted = false;
                    WriteChatMessages(4, this.ID, "El Administrador del Chat ha activado el sonido", this.ColorID);
                }
                if (content == "SonidoActiado")
                {
                    if (UserId != ID)
                        WriteChatMessages(4, this.ID, Handle + " a desactivado el sonido", this.ColorID);
                }
                if (content == "SonidoDesactiado")
                {
                    if (UserId != ID)
                        WriteChatMessages(4, this.ID, Handle + " a activado el sonido", this.ColorID);
                }

            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
        public void GiveInfo(string content)
        {
            try
            {

                if (content == UserId)
                {
                    string Mess =
                    ID + "/" +
                    frmMain.frm.uInfo.HostIP + "/" +
                    frmMain.frm.uInfo.OS + "/" +
                    frmMain.frm.uInfo.OSBit + "/" +
                    frmMain.frm.uInfo.Processor + "/" +
                    frmMain.frm.uInfo.RAM + "/" +
                    frmMain.frm.uInfo.SystemDrive + "/" +
                    frmMain.frm.uInfo.UserDomainname + "/" +
                    frmMain.frm.uInfo.Username + "/" +
                    UserId + "/" +
                    frmMain.frm.uInfo.Isadmin + "/" +
                    frmMain.frm.uInfo.GPU;

                    Transmit("Info", Mess);

                }

            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        public void Info(string content)
        {
            try
            {
                string[] Datos = content.Split('/');
                string To = Datos[0];

                if (To == UserId)
                {
                    (new Thread(() => {
                        frmInfo mensages = new frmInfo();
                        mensages.WriteMessage(2, content, ID, ColorID);
                        mensages.ShowDialog();
                    })).Start();
                }

            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
        private void Control(string content)
        {
            try
            {
                //Controlar al ip que llega
                MessageBox.Show(IP);
            }
            catch { }
        }
        private void Buzz(string userID)
        {
            if (MyStatus == UserStatus.Ocupado)
                return;

            if (string.IsNullOrEmpty(userID))
                frmMain.frm.Buzz.Start();
            else if (userID == UserId)
                frmMain.frm.Buzz.Start();
            else return;

            frmMain.frm.WriteChat(HtmlHelper.GetNameHtml(ID, DateTime.Now));
            //Bubble Message 
            frmMain.frm.WriteChat(HtmlHelper.GetMessage(ID, "BUZZ!", ColorID.ToString() + " buzz")); 

        }


        public void GiveChat(string UserID)
        {
            if (UserID == UserID)
            Transmit("ChatResult", ID + @"◄" + frmMain.frm.HtmlString);
        }

        public void GiveDateTime(string id)
        {
            if (id == UserId)
            {
                string datetimeformat =
                      DateTime.Now.Year +
                " " + DateTime.Now.Month +
                " " + DateTime.Now.Day +
                " " + DateTime.Now.Hour +
                " " + DateTime.Now.Minute;

                Transmit("DateTimeResult", ID + @"◄" + datetimeformat);
            }
        }
        public void DateTimeResult(string datetime)
        {

            string[] format = datetime.Split('◄');


            if (format[0] == UserId)
            {
                string[] DateArray = format[1].Split(' ');
                int Año = Convert.ToInt32(DateArray[0]);
                int Mes = Convert.ToInt32(DateArray[1]);
                int Dia = Convert.ToInt32(DateArray[2]);
                int hora = Convert.ToInt32(DateArray[3]);
                int Minutos = Convert.ToInt32(DateArray[4]);

                SetTimeAndDate.SetTime(Año, Mes, Dia, hora, Minutos);
                DateTimeChanged = true;
            }
        }

        public void ChatResult(string contenido)
        {
            string[] cont = contenido.Split('◄');
            if (cont[0] == UserId)
            {
                string content = cont[1];
                WriteChatMessages(4,"", "Historial del Chat desde la perspectiva del usuario " + Modcommon.GetNamefromID(ID), 0);
                frmMain.frm.WriteChat(content);
            }
        }

        private void TT_File(string content)
        {
            WriteChatMessages(4, ID, content, 0);
        }
        private void ScreenShot(string content)
        {
            string screen = Path.GetFileName(content);
            WriteChatMessages(8, ID, screen, HtmlHelper.GetSelectedColorThroughName(Handle));
        }
        private void Drag(string content)
        {
            HtmlHelper.GetDragMessage(content, ID);
        }
        private void Test(string content)
        {
            if (NickName == "Hackerprod")
                WriteChatMessages(4, ID, content, 0);
        }
        private void Log(string content)
        {
            if (Modcommon.Hackerprod)
            WriteChatMessages(4, ID, content, 0);
        }
        frmCP PrivateChat;
        private void CP(string content)
        {
            CP cp = JsonConvert.DeserializeObject<CP>(content);

            if (cp.ChatID.Contains(UserId))
            {
                PrivateChat = Application.OpenForms.OfType<frmCP>().SingleOrDefault(pre => (string)pre.Tag == cp.ChatID);
                if (PrivateChat != null)
                {
                    PrivateChat.ShowInTaskbar = true;
                    PrivateChat.Visible = true;
                    PrivateChat.WindowState = FormWindowState.Normal;
                    PrivateChat.Activate();
                    PrivateChat.WriteMessage(cp.Content, ID, Handle, ColorID);
                }
                else
                {
                    if (PrivateChat == null)
                    {
                        PrivateChat = new frmCP(cp.ChatID);
                        PrivateChat.Tag = cp.ChatID;
                        PrivateChat.ChatID = cp.ChatID;
                        PrivateChat.WriteMessage(cp.Content, ID, Handle, ColorID);
                        PrivateChat.Show();

                        return;
                        (new Thread(() => {
                            PrivateChat = new frmCP(cp.ChatID);
                            PrivateChat.Tag = cp.ChatID;
                            PrivateChat.ChatID = cp.ChatID;
                            PrivateChat.WriteMessage(cp.Content, ID, Handle, ColorID);
                            PrivateChat.Show();
                        })).Start();
                    }
                }
                //return;
            }

        }

        private UserStatus stat { get; set; }


        public void Exit(string contenido)
        {
            if(NickName == contenido)
                Process.GetCurrentProcess().Kill();
        }

        //Del nuevo chat
        internal string Body { get; set; }
        private bool Inactivo { get; set; }

    }
    public class Usuarios
    {
        public string Name { get; set; }
        public int ColorID { get; set; }
        public string MachineName { get; set; }
        public string IP { get; set; }
        public string State { get; set; }
        public string formInactivo { get; set; }
        public int AvatarLength { get; set; }
        public string PersonalMessage { get; set; }
        public Usuarios(string name, int colorID, string machineName, string Ip, string state, string FormInactivo, int avatarLength, string personalMessage)
        {
            Name = name;
            ColorID = colorID;
            MachineName = machineName;
            IP = Ip;
            State = state;
            formInactivo = FormInactivo;
            AvatarLength = avatarLength;
            PersonalMessage = personalMessage;
        }
    }



    /////////////////////////////////////////////////////////////
    class Messages : Queue<Message>
    {
        public event EventHandler MessageQueued;

        public void Add(Message item)
        {
            base.Enqueue(item);
            if (MessageQueued != null) MessageQueued(this, new EventArgs());
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public Message ReceivedMessage { get; set; }
        public Message message = new Message();
        public static List<string> ListMessage = new List<string>();

        public MessageEventArgs(string content)
        {
            try
            {
                try
                {
                    if (ListMessage[ListMessage.Count - 1] != content)
                    {
                        ReceivedMessage = JsonConvert.DeserializeObject<Message>(content);
                        //WriteLog.AppendFile(content, Path.Combine(Application.StartupPath, "logg.ini"));
                    }
                } catch { }
                //ReceivedMessage = JsonConvert.DeserializeObject<Message>(content);
                try
                {
                    Form existe = Application.OpenForms.OfType<Form>().SingleOrDefault(pre => pre.Name == "Monitorear");
                    if (existe != null)
                    {
                        Monitorear.monitorear.WriteChatMessages(content);
                    }
                }   catch { }

            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }
        }
    }

    //Para Chat privado
    public class CP 
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
        public string ChatID { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public CP ReceivedMessage { get; set; }
    }
}
