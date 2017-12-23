using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Infrastructure
{
    public class ReturnObject
    {
        #region Enums

        /// <summary>
        /// Enum für den Rückgabewert des ReturnObjects, der über die Property "ReturnValue" 
        /// abgefragt werden kann.
        /// </summary>
        [DataContract(Namespace = "http://schemas.bofrost.de/bo2.Core")]
        public enum Result
        {
            /// <summary>Erfolg</summary>
            [EnumMember]
            Success,
            /// <summary>Es ist ein Datenbankfehler aufgetreten</summary>
            [EnumMember]
            DBError,
            /// <summary>Es ist ein benutzerdefinierter Fehler aufgetreten</summary>
            [EnumMember]
            CustomError,
            /// <summary>Es ist eine Exception aufgetreten</summary>
            [EnumMember]
            SystemError
        }

        /// <summary>
        /// Enum mit möglichen Ausprägungen des Datenbank-Fehlers, der über die Property 
        /// "ErrorType" ausgelesen werden kann, wenn der "ReturnValue" den Wert "DBError" hat.
        /// </summary>
        [DataContract(Namespace = "http://schemas.bofrost.de/bo2.Core")]
        public enum DBErrorType
        {
            /// <summary>Primary-Key- oder Unique-Index-Verletzung (ORA-00001)</summary>
            [EnumMember]
            PrimaryKeyViolation,
            /// <summary>Field not nullable-Verletzung (ORA-01400)</summary>
            [EnumMember]
            NotNullViolation,
            /// <summary>Foreign-Key-Verletzung (ORA-02291 oder ORA-02292)</summary>
            [EnumMember]
            ForeignKeyViolation,
            /// <summary>Satz mit entsprechender BOF_ID konnte nicht gefunden werden</summary>
            [EnumMember]
            BofIDNotFound,
            /// <summary>Fehler beim Connect an die Datenbank</summary>
            [EnumMember]
            ConnectFailure,
            /// <summary>Fehler beim Eröffnen einer Datenbank-Transaktion</summary>
            [EnumMember]
            TransactionStartFailure,
            /// <summary>Fehler beim Commit einer Datenbank-Transaktion</summary>
            [EnumMember]
            TransactionCommitFailure,
            /// <summary>Fehler beim Rollback einer Datenbank-Transaktion</summary>
            [EnumMember]
            TransactionRollbackFailure,
            /// <summary>Anderer Datenbank-Fehler</summary>
            [EnumMember]
            Miscellaneous
        }

        #endregion

        #region Variables

        /// <summary>Vordefiniertes ReturnObject mit dem Rückgabewert "Success"</summary>
        private static ReturnObject c_retSuccess;

        /// <summary>Rückgabewert (Success, DBError, CustomError oder SystemError)</summary>
        [DataMember(Order = 1, Name = "m_nReturnValue")]
        private Result m_nReturnValue;

        /// <summary>Fehlertyp (Enum zur genaueren Identifizierung des aufgetreten Fehlers)</summary>
        [DataMember(Order = 2, Name = "m_oErrorType")]
        private Enum m_oErrorType = null;

        /// <summary>Fehlerbeschreibung in deutsch</summary>
        [DataMember(Order = 3, Name = "m_sDescriptionDE")]
        private string m_sDescriptionDE;
        /// <summary>Fehlerbeschreibung in der Sprache des Anwenders</summary>
        [DataMember(Order = 4, Name = "m_sDescriptionML")]
        private string m_sDescriptionML;

        /// <summary>Inneres ReturnObject</summary>
        [DataMember(Order = 5, Name = "m_oInnerObject")]
        private ReturnObject m_oInnerObject;

        /// <summary>UserSessionInfo-Objekt darf ausgegeben werden</summary>
        [DataMember(Order = 7, Name = "m_bIsLogged")]
        private bool m_bIsLogged = false;

        #endregion

        #region Properties
        public bool IsError
        {
            get { return (m_nReturnValue != Result.Success); }
        }

        public bool IsSuccess
        {
            get { return (m_nReturnValue == Result.Success); }
        }

        public Result ReturnValue
        {
            get
            {
                return m_nReturnValue;
            }
        }

        public string DescriptionDE
        {
            get
            {
                return m_sDescriptionDE;
            }
        }

        public Enum ErrorType
        {
            get
            {
                return m_oErrorType;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Privater Standard-Konstruktor der Klasse, damit dieser nicht von aussen genutzt wird.
        /// </summary>
        private ReturnObject(
            Result nReturnValue,
            Enum oErrorType,
            string sDescriptionDE,
            string sDescriptionML,
            ReturnObject oInnerObject)
        {
            m_nReturnValue = nReturnValue;
            m_oErrorType = oErrorType;
            m_sDescriptionDE = sDescriptionDE;
            m_sDescriptionML = sDescriptionML;
            m_oInnerObject = oInnerObject;
        }

        #endregion

        #region Public

        /// <summary>
        /// Gibt ein ReturnObject mit Rückgabewert "Success" zurück.
        /// </summary>
        /// <returns>ReturnObject mit Rückgabewert "Success"</returns>
        public static ReturnObject GetInstanceSuccess()
        {
            // Vordefiniertes ReturnObject mit "Success" zurückgeben
            c_retSuccess = new ReturnObject(Result.Success, null, string.Empty, string.Empty, null);
            return c_retSuccess;
        }

        /// <summary>
        /// Gibt ein ReturnObject mit Rückgabewert "CustomError" zurück. 
        /// </summary>
        /// <param name="oCustomErrorCode">Enum-Ausprägung zur genaueren Identifizierung des aufgetreten Fehlers bzw. "null"</param>
        /// <param name="sDescriptionDE">Fehlerbeschreibung in deutsch</param>
        /// <param name="sDescriptionML">Fehlerbeschreibung in der Sprache des Anwenders</param>
        /// <param name="bWriteLog">ReturnObject in Error-Logdatei schreiben J/N</param>
        /// <param name="oUserSessionInfo">UserSessionInfo-Objekt</param>
        /// <returns>ReturnObject mit Rückgabewert "SystemError"</returns>
        /// <author>MSP</author>
        public static ReturnObject GetInstanceCustomError(
            Enum oCustomErrorCode,
            string sDescriptionDE,
            string sDescriptionML,
            bool bWriteLog)
        {
            return GetInstanceCustomError(oCustomErrorCode, sDescriptionDE, sDescriptionML, bWriteLog, null);
        }

        public static ReturnObject GetInstanceCustomError(
            Enum oCustomErrorCode,
            string sDescriptionDE,
            string sDescriptionML,
            bool bWriteLog,
            ReturnObject oInnerObject)
        {
            ReturnObject ret;

            ret = new ReturnObject(Result.CustomError, oCustomErrorCode, sDescriptionDE, sDescriptionML, oInnerObject);
            if (bWriteLog)
            {
                //TODO Implementieren log system....
            }

            return ret;
        }

        #endregion

    }
}
