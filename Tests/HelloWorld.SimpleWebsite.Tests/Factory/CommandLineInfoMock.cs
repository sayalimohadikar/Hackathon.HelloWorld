using Atlas.CommandLine;
using System;
using System.Collections.Generic;

namespace HelloWorld.SimpleWebsite.Tests.Factory
{
    internal class CommandLineInfoMock : ICommandLineInfo
    {
        private readonly IDictionary<string, string> _options;

        public bool IsOptionSet(string optionName)
        {
            return _options.ContainsKey(optionName);
        }

        public string GetOptionValue(string optionName)
        {
            return _options[optionName];
        }

        public IEnumerable<string> GetOptionValues(string optionName)
        {
            return new[] { _options[optionName] };
        }

        public string[] SettingsOverride { get; }

        public CommandLineInfoMock() : this(new Dictionary<string, string>())
        {

        }

        public CommandLineInfoMock(IDictionary<string, string> options, string[] settingsOverride = null)
        {
            _options = options;
            SettingsOverride = settingsOverride ?? Array.Empty<string>();
        }
    }
}
