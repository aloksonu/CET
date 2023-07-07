using CET.AudioData;
using CET.Common.Audio;
using CET.Scripts;
using UnityEngine;
using Utilities;

namespace CET.CET_Installation.Scripts
{
    public class CETinstallationManager : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
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
            this.Invoke(BeginStartPanel, 0.03f);
            //this.Invoke(BeginAddWorkspace, 0.03f);
            //BeginStartPanel();
        }

        private void BeginStartPanel()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallStart, canvas ,0.2f);
            startPanel.BringIn(BeginPrerequisites);
        }
        private void BeginPrerequisites()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallPrerequisites, canvas, 0.2f);
            prerequisites.BringIn(BeginDownloadPanel,0.1f);
        }
        private void BeginDownloadPanel()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallDownloadPanel, canvas, 0.2f);
            downloadPanel.BringIn(BeginInstallerPanel,0.1f);
        }
        private void BeginInstallerPanel()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallInstallerPanel, canvas, 0.2f);
            installerPanel.BringIn(BeginCETAgreePanel);
        }
        private void BeginCETAgreePanel()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallAgree, canvas, 0.2f);
            cETAgreePanel.BringIn(BeginCETinstallAll);
        }
        private void BeginCETinstallAll()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallAll, canvas, 0.2f);
            cETinstallAll.BringIn(BeginWorkspace);
        }
        private void BeginWorkspace()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallWorkspace, canvas, 0.2f);
            workspace.BringIn(BeginAddWorkspace);
        }
        private void BeginAddWorkspace()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallAddRepository, canvas, 0.2f);
            addWrokspace.BringIn(BeginInstallationComplete);
        }

        private void BeginInstallationComplete()
        {
            CETAudioManager.Instance.PlayAudio(AudioName.InstallCongratulation, canvas, 0.2f);
            installationComplete.BringIn(()=> {LevelComplete.Instance.BringIn();});
        }
    }
}
