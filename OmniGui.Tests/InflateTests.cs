namespace OmniGui.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Xaml.Templates;
    using Xaml;
    using Xunit;

    public class InflateTests
    {
        [Fact]
        public void Inflate2()
        {
            var codeBaseUrl = new Uri(typeof(InflateTests).GetTypeInfo().Assembly.CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);
            var path= Path.Combine(dirPath, "Container.xaml");


            var layout = new Button {Text = "Hola t�o"};
            var omniGuiXamlLoader = GetLoader();
            var container = (Container)omniGuiXamlLoader.Load(File.ReadAllText(path)).Instance;

            TemplateInflator.Inflate(layout, container.ControlTemplates);
            layout.Text = "Pepito";
        }

        private static OmniGuiXamlLoader GetLoader()
        {
            var omniGuiXamlLoader = new OmniGuiXamlLoader(new List<Assembly>
            {
                Assembly.Load(new AssemblyName("OmniGui")),
                Assembly.Load(new AssemblyName("OmniGui.Xaml")),
                Assembly.Load(new AssemblyName("OmniGui.Tests"))
            });
            return omniGuiXamlLoader;
        }
    }
}