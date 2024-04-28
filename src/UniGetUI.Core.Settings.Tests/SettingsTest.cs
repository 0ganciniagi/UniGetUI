using UniGetUI.Core.SettingsEngine;

namespace UniGetUI.Core.SettingsEgine.Tests
{
    public class SettingsTest
    {
        [Theory]
        [InlineData("TestSetting1", true, false, false, true)]
        [InlineData("TestSetting2", true, false, false, false)]
        [InlineData("Test.Settings_with", true, false, true, true)]
        [InlineData("sdflgkjsdfgbavmdfghbdhgj", false, true, false, false)]
        [InlineData("ª", false, false, false, false)]
        [InlineData("nzsash8372395124n5", true, false, true, true)]
        public void TestBooleanSettings(string SettingName, bool st1, bool st2, bool st3, bool st4)
        {
            Settings.Set(SettingName, st1);
            Assert.Equal(st1, Settings.Get(SettingName));

            Settings.Set(SettingName, st2);
            Assert.Equal(st2, Settings.Get(SettingName));

            Settings.Set(SettingName, st3);
            Assert.Equal(st3, Settings.Get(SettingName));

            Settings.Set(SettingName, st4);
            Assert.Equal(st4, Settings.Get(SettingName));

            Settings.Set(SettingName, false); // Cleanup
            Assert.False(Settings.Get(SettingName));
        }

        [Theory]
        [InlineData("TestSetting1", "RandomFirstValue", "RandomSecondValue", "", "RandomThirdValue")]
        [InlineData("ktjgshdfsd", "", "", "", "RandomThirdValue")]
        [InlineData("ª", "RandomFirstValue", "    ", "\t", "RandomThirdValue")]
        [InlineData("fghfgjhrj", "RandomFirstValue", "", "", "")]
        [InlineData("VeryVeryLongTestSettingEntry", "\x00\x01\x02\u0003", "", "", "RandomThirdValue")]
        public void TestValueSettings(string SettingName, string st1, string st2, string st3, string st4)
        {
            Settings.SetValue(SettingName, st1);
            Assert.Equal(st1, Settings.GetValue(SettingName));

            Settings.SetValue(SettingName, st2);
            Assert.Equal(st2, Settings.GetValue(SettingName));

            Settings.SetValue(SettingName, st3);
            Assert.Equal(st3, Settings.GetValue(SettingName));

            Settings.SetValue(SettingName, st4);
            Assert.Equal(st4, Settings.GetValue(SettingName));

            Settings.Set(SettingName, false); // Cleanup
            Assert.False(Settings.Get(SettingName));
            Assert.Equal("", Settings.GetValue(SettingName));
        }


    }
}