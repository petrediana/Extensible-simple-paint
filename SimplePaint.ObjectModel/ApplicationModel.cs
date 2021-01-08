using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;

namespace SimplePaint.ObjectModel
{
    public class ApplicationModel
    {
        private ApplicationModel()
        {
            _paintDocument = new PaintDocument();
            _commands = new CommandCollection();
        }
        static ApplicationModel()
        {
            _instace = new ApplicationModel();
        }

        public event EventHandler OnQuit;

        #region Private Attributes definition
        private static readonly ApplicationModel _instace;
        private PaintDocument _paintDocument;
        private CommandCollection _commands;
        #endregion

        #region Public Properties Definitions: Instace, PaintDocument, Commands
        public static ApplicationModel Instace
        {
            get => _instace;
        }

        public PaintDocument PaintDocument
        {
            get => _paintDocument;
        }

        public CommandCollection Commands
        {
            get => _commands;
        }
        #endregion

        public void Quit() => OnQuit?.Invoke(this, new EventArgs());

        #region Add plugins via DLL files
        List<Assembly> _pluginAssemblies = new List<Assembly>();
        public void LoadAvailablePlugins()
        {
            const string INTERFACE_NAME = "SimplePaint.ObjectModel.IPluginable";

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            AppDomain.CurrentDomain.TypeResolve += CurrentDomain_TypeResolve;

            // For now just put the ddls in bin/Debug
            string pluginPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            foreach (var assemblyFileName in Directory.GetFiles(pluginPath, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(assemblyFileName);
                    _pluginAssemblies.Add(assembly);

                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.GetInterface(INTERFACE_NAME) != null)
                        {
                            IPluginable plugin = Activator.CreateInstance(type) as IPluginable;
                            plugin.Initialize();

                            List<Command> pluginCommands = plugin.GetCommands();
                            if (pluginCommands != null)
                            {
                                foreach (var pluginCommand in pluginCommands)
                                {
                                    Commands.Add(pluginCommand);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while loading plugin assembly: {ex}");
                }
            }
        }

        private Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args)
        {
            foreach (var assembly in _pluginAssemblies)
            {
                if (assembly.GetType(args.Name) != null)
                {
                    return assembly;
                }
            }

            return null;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            foreach (var assembly in _pluginAssemblies)
            {
                if (assembly.GetName().FullName == args.Name || assembly.GetName().Name == args.Name)
                {
                    return assembly;
                }
            }

            return null;
        }
        #endregion
    }
}
