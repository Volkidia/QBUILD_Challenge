   M S B A M L   `   `   `  ����K  GQBuild_Challenge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QBuild_ChallengeQBuild_Challenge  5   	   !    QBuild_Challenge.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QBuild_Challenge     5   	     � Title$  QBuild Challenge��5   	   $��767.825��6"   $	��800��63   .��5	      � .+�5
   
   �� -   5         ��Name$ btnPopulateTree��5
      $��Populate Data In Tree��6*   $
��Left=�6J   $��355,203,0,0q�6e   $	��Top=�6z   $	��220��6�   $��39��6�   6�   �� 5   
   -   5        $ 
exitAppBtn��5      $��Exit From Application��6%   $
��Left=�6E   $��355,283,0,0q�6`   $	��Top=�6u   $	��220��6�   $��39��6�   6�   �� 5   
   -   5         ��Name$ lblParentChild��5      $��Label��6(   $
��Left=�68   $��
369,80,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ lblCurrentPart��5      $��Label��6(   $
��Left=�68   $��369,136,0,0q�6S   $	��Top=�6h   R� 5   
   -   5         R�Name$ treeViewDependencies��5      $
��Left=�61   $	��260��6L   $��	20,62,0,0q�6Y   $	��Top=�6l   $	��301��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��10,352,32,10q�6%      
IsReadOnly .    AutoGenerateColumns .  ��6;   �� *DataGridItems+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ PARENT__NAME��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 120 6;   
   CanUserReorder
 .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
ParentName+6f     5      $ COMPONENT__NAME��6%   $		 120 6>    6J   �� *ComponentName+  5      $ PART__NUMBER��6%   $		 120 6;    6G   �� *
PartNumber+  5      $ TITLE��6%   $		 120 64    6@   �� *Title+  5      $ QUANTITY��6%   $		 120 67    6C   �� *
Quantity+  5      $
 TYPE��6%   $		 120 63    6?   �� *Type+  5      $
 ITEM��6%   $		 120 63    6?   �� *Item+  5      $ MATERIAL��6%   $		 120 67    6C   �� *
Material+5      5      5      