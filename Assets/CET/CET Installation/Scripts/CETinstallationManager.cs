using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CETinstallationManager : MonoBehaviour
{
    [SerializeField] private OkManager startPanel;
    [SerializeField] private OkManager prerequisites;
    [SerializeField] private OkManager downloadPanel;
    [SerializeField] private OkManager installerPanel;
    [SerializeField] private AgreePanel cETAgreePanel;
    [SerializeField] private OkManager cETinstallAll;
    [SerializeField] private OkManager workspace;
    [SerializeField] private AddWrokspace addWrokspace;
    [SerializeField] private InstallationComplete installationComplete;
    void Start()
    {
        //this.Invoke(BeginStartPanel, 0.03f);
        this.Invoke(BeginAddWorkspace, 0.03f);
        //BeginStartPanel();
    }

    private void BeginStartPanel()
    {
        startPanel.BringIn(BeginPrerequisites);
    }
    private void BeginPrerequisites()
    {
        prerequisites.BringIn(BeginDownloadPanel,0.1f);
    }
    private void BeginDownloadPanel()
    {
        downloadPanel.BringIn(BeginInstallerPanel,0.1f);
    }
    private void BeginInstallerPanel()
    {
        installerPanel.BringIn(BeginCETAgreePanel);
    }
    private void BeginCETAgreePanel()
    {
        cETAgreePanel.BringIn(BeginCETinstallAll);
    }
    private void BeginCETinstallAll()
    {
        cETinstallAll.BringIn(BeginWorkspace);
    }
    private void BeginWorkspace()
    {
        workspace.BringIn(BeginAddWorkspace);
    }
    private void BeginAddWorkspace()
    {
        addWrokspace.BringIn(BeginInstallationComplete);
    }

    private void BeginInstallationComplete()
    {
        installationComplete.BringIn();
    }
}
