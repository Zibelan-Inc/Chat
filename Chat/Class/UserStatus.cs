using System.ComponentModel;

namespace Chat
{
    public enum UserStatus
    {
        [Description("Idle")]
        Idle = 0,
        [Description("Online")]
        Online = 1,
        [Description("Activo")]
        Activo = 2,
        [Description("Ocupado")]
        Ocupado = 3,
        [Description("Ausente")]
        Ausente = 4,
    }
    public class Status
    {
        public static string ToString(UserStatus state)
        {
            string status = "";

            switch (state)
            {
                case UserStatus.Online:
                    status = "Online";
                    break;
                case UserStatus.Activo:
                    status = "Activo";
                    break;
                case UserStatus.Ocupado:
                    status = "Ocupado";
                    break;
                case UserStatus.Ausente:
                    status = "Ausente";
                    break;
                case UserStatus.Idle:
                    status = "Inactivo";
                    break;
            }
            return status;
        }
        static UserStatus status;
        public static UserStatus ToStatus(string state)
        {
            //MessageBox.Show(state);

            switch (state.ToLower())
            {
                case "online":
                    status = UserStatus.Online;
                    break;
                case "activo":
                    status = UserStatus.Activo;
                    break;
                case "ocupado":
                    status = UserStatus.Ocupado;
                    break;
                case "ausente":
                    status = UserStatus.Ausente;
                    break;
                case "idle":
                    status = UserStatus.Idle;
                    break;
            }
            return status;
        }

    }

}
