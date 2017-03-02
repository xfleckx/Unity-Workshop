using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandLine;

public static class AppStartUp {

    public static Options options;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void GetCommandLineArguments()
    {
        var args = Environment.GetCommandLineArgs();

        options = new Options();

        Parser.Default.ParseArguments(args, options);
    }

}

public class Options
{
    [Option('m', "message", DefaultValue = "noMessage", HelpText = "A Message displayed by the app")]
    public string aMessage { get; set; }
}