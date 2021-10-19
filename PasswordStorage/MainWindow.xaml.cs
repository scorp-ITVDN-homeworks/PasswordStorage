using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PasswordStorage.ViewModel;
using SeemObject;

namespace PasswordStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ApplicationLevel
        // всё, что внутри области должно происходить где-то на уровне 
        // Application, но я не очень понимаю как это там расположить

        /* значение этих двух переменных должно быть 
         * прописано где-то в манифесте приложения
         * Как это сделать?
         * Как записать в манифест и потом получить в коде эти значения?
         */
        private string modelAssemblyName = "XmlStorage"; // имя сборки модели
        private string modelInterfaceName = nameof(IXmlStorage); //имя интерфейса модели

        /* метод для получения типа модели из сборки
         */
        private Type AssemblyTypeByInterface(Assembly assembly, string interfaceName)
        {
            return assembly.GetTypes().Where(t => TypeHasInterface(t,interfaceName)).FirstOrDefault();
        }

        /* проверка наследуется ли тип от интефейса с заданным названием
         */
        private bool TypeHasInterface(Type type, string IName)
        {
            return type.GetInterfaces().Where(t => t.Name == IName).Count() > 0 ? true : false;
        }

        #endregion

        private Assembly modelDll;
        private Type modelType;
        private StorageVM viewModel;

        public MainWindow()
        {
            InitializeComponent();
            modelDll = Assembly.Load(modelAssemblyName);
            modelType = AssemblyTypeByInterface(modelDll, modelInterfaceName);
            viewModel = new StorageVM(Activator.CreateInstance(modelType) as IXmlStorage);
            DataContext = viewModel;
            KeyDown += spaceKeyDown;
        }

        private void spaceKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                MessageBox.Show(viewModel.ToString());
            }

        }      
        
    }
}
