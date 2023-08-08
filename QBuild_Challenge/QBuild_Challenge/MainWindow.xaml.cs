using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace QBuild_Challenge
{
    
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ComponentDependencies dependencies;
        public Components components;
        private ViewModel viewModel; 

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
        }

        private void btnPopulateTree_Click(object sender, RoutedEventArgs e)
        {
            components = SQLDataLoader.GetComponents();
            if (components != null && components.components.Count > 0)
            {
                dependencies = components.GetDependencies();
            }
            btnPopulateTree.IsEnabled = false;
            treeViewDependencies.Items.Clear();
            treeViewDependencies.Items.Add(PopulateTreeView(dependencies));
        }

        private TreeViewItem PopulateTreeView(ComponentDependencies cmpntDependencies)
        {
            TreeViewItem _tViewItem = new TreeViewItem();
            _tViewItem.Header = cmpntDependencies.partName;
            foreach(ComponentDependencies _cd in cmpntDependencies.componentsNames)
            {
                _tViewItem.Items.Add(PopulateTreeView(_cd));
            }
            return _tViewItem;
        }

        private void treeViewDependencies_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = (TreeViewItem)treeViewDependencies.SelectedItem;
            Component c = components.GetComponent(item.Header.ToString());
            lblParentChild.Content = $"{c.parentName}\\{c.componentName}";
            lblCurrentPart.Content = $"{c.componentName}";
            dataGrid.ItemsSource = ComponentsToDatagridItems(components.GetComponentsOfParent(c.componentName));
        }

        private List<DataGridItem> ComponentsToDatagridItems(List<Component> listComponents)
        {
            List <DataGridItem> _rList = new List<DataGridItem>();
            foreach(Component c in listComponents)
            {
                _rList.Add(new DataGridItem(c));
            }
            return _rList;
        }

        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
