using EdmLib;
using System;
using System.Runtime.InteropServices;



[Guid("34E49CFE-78BF-49B8-B6C4-E25AB2ECC625"), ComVisible(true)]


public class Class1 : IEdmAddIn5
{
    public static IEdmVault5 Vault;

    public void GetAddInInfo(ref EdmAddInInfo poInfo, IEdmVault5 poVault, IEdmCmdMgr5 poCmdMgr)
    {

        poInfo.mbsAddInName = "C# Add-in";
        poInfo.mbsCompany = "Artrans S.A";
        poInfo.mbsDescription = "Menu add-in that shows a message box.";
        poInfo.mlAddInVersion = 1;

        poInfo.mlRequiredVersionMajor = 6;
        poInfo.mlRequiredVersionMinor = 4;

        Vault = poVault;

        //Añado el hook para las validaciones en los cambios de estado.
        poCmdMgr.AddHook(EdmCmdType.EdmCmd_PreState);


        poCmdMgr.AddCmd(1, "C# Add-in", (int)EdmMenuFlags.EdmMenu_Nothing);
        //Register hooks
        /*
        //Notify the add-in when a file has been added
        poCmdMgr.AddHook(EdmCmdType.EdmCmd_PostAdd);

        //Notify the add-in when a file has been checked out
        poCmdMgr.AddHook(EdmCmdType.EdmCmd_PostLock);

        //Notify the add-in when a file is about to be checked in
        poCmdMgr.AddHook(EdmCmdType.EdmCmd_PreUnlock);

        //Notify the add-in when a file has been checked in
        poCmdMgr.AddHook(EdmCmdType.EdmCmd_PostUnlock);
        */
    }



    public void OnCmd(ref EdmCmd poCmd, ref System.Array ppoData)
    {
        //Handle the hook
        string name = null;
        switch (poCmd.meCmdType)
        {
            case EdmCmdType.EdmCmd_PreState:
                name = "PreState";
                break;
            case EdmCmdType.EdmCmd_PostAdd:
                name = "PostAdd";
                break;
            case EdmCmdType.EdmCmd_PostLock:
                name = "PostLock";
                break;
            case EdmCmdType.EdmCmd_PreUnlock:
                name = "PreUnlock";
                break;
            case EdmCmdType.EdmCmd_PostUnlock:
                name = "PostUnlock";
                break;
            default:
                name = "?";
                break;
        }



        string message = null;
        message = "sasasa";
        int index = 0;
        // index = Information.LBound(ppoData);
        index = ppoData.GetLowerBound(0);
        int last = 0;
        //last = Information.UBound(ppoData);
        last = ppoData.GetUpperBound(0);

        //Append the paths of all files to a message string
        while (index <= last)
        {
            message = message + ((EdmCmdData)(ppoData.GetValue(index))).mbsStrData1 + Environment.NewLine;//Constants.vbLf;
            index = index + 1;
        }

        //Display a message to the user
        message = "The following files were affected by a " + name + " hook:" + Environment.NewLine/*Constants.vbLf */+ message;

        EdmVault5 vault = default(EdmVault5);
        vault = (EdmVault5)poCmd.mpoVault;
        vault.MsgBox(poCmd.mlParentWnd, message);



        if (poCmd.meCmdType == EdmCmdType.EdmCmd_Menu)
        {
            if (poCmd.mlCmdID == 1)
            {
                System.Windows.Forms.MessageBox.Show("C# Add-in");
            }
        }




    }

}


