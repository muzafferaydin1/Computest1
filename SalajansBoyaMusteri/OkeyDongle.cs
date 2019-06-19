using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

class OkeyDongle
{
#if WIN64
        const string libraryname = "OkeyDongleLibraryX64.dll";
#else
    const string libraryname = "OkeyDongleLibrary.dll";
#endif

    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Login(string ModuleID, string DeviceParameter);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Logout(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_IsLogined();
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_StrToHex(string StringData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_HexToStr(string HexData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_StrToBase64(string StringData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Base64ToStr(string Base64Data);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_HexToBase64(string HexData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Base64ToHex(string Base64Data);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Enc(string SessionID, string PlainData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Dec(string SessionID, string CipherData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ShowError(string ErrorMode);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ChangeError(string ErrorID, string ErrorString);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_Info(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadSerial();
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadHash(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_CheckLicence(string SessionID, string LicenceKey);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_MD5File(string Path);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_MD5Text(string Text);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_SHA1File(string Path);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_SHA1Text(string Text);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DesEnc(string PlainData, string Key);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DesDec(string CipherData, string Key);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_3DesEnc(string PlainData, string Key);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_3DesDec(string CipherData, string Key);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_SignText(string SessionID, string Text);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_SignFile(string SessionID, string Path);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_VerifyText(string Text, string Signature, string Exponent, string Modulus);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_VerifyFile(string Path, string Signature, string Exponent, string Modulus);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_WriteMemory(string SessionID, string Address, string Data, string EWMode);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadMemory(string SessionID, string Address);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DeleteMemory(string SessionID, string Address);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_WriteProtectedMemory(string SessionID, string Address, string Data, string Pin, string Key, string EWMode);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadProtectedMemory(string SessionID, string Address, string Pin, string Key);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DeleteProtectedMemory(string SessionID, string Address, string Pin);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadMaxUser(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadCredit(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_ReadLogin(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataFillArray(string SessionID, string ArrayID, string Data);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataReadArray(string SessionID, string ArrayID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataFillFromMemory(string SessionID, string ArrayID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataWriteToMemory(string SessionID, string ArrayID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataAdd(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataSub(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataAnd(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataOr(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataXor(string SessionID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataInverse(string SessionID, string ArrayID);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataSum(string SessionID, string ArrayID, string ArrayIndex);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataExchange(string SessionID, string ArrayIndex1, string ArrayIndex2);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataEnc(string SessionID, string Mode);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DataDec(string SessionID, string Mode);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_EncWithMemoryKey(string SessionID, string PlainData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DecWithMemoryKey(string SessionID, string CipherData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_EncWithKey(string SessionID, string Key, string PlainData);
    [DllImport(libraryname, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern IntPtr OD_DecWithKey(string SessionID, string Key, string CipherData);

}
