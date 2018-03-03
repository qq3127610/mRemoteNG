﻿using mRemoteNG.App;
using mRemoteNG.Config.Settings;
using mRemoteNG.Connection;
using mRemoteNG.Tools;
using mRemoteNG.UI.Forms;
using NSubstitute;
using NUnit.Framework;

namespace mRemoteNGTests.UI.Forms
{
	public class OptionsFormSetupAndTeardown
    {
        protected frmOptions _optionsForm;

        [OneTimeSetUp]
        public void OnetimeSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
	        var connectionInitiator = Substitute.For<IConnectionInitiator>();
            var shutdown = new Shutdown(new SettingsSaver(new ExternalToolsService()));
            _optionsForm = new frmOptions(connectionInitiator, type => {}, () => new NotificationAreaIcon(FrmMain.Default, connectionInitiator, shutdown));
            _optionsForm.Show();
        }

        [TearDown]
        public void Teardown()
        {
            _optionsForm.Dispose();
            while (_optionsForm.Disposing) ;
            _optionsForm = null;
        }
    }
}