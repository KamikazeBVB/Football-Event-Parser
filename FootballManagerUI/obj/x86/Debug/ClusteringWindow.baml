   M S B A M L   `   `   `  ����  FootballManagerUI(    "FootballManagerUI.ClusteringWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ClusteringWindow��5   	   $	��300��6"   $	��681��6/   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��111* �6   �� 5      $	��167 �6    � RowDefinitions 5
   
   �� 5      �� 5      $��20 �6   .+�5   
   �� -   5        $��statusListBox��5      $��0��6'   $��0��67   �� 5   
   -   5        $��optionsPanel��5   1   $
��Left=�6   $	��Top=�6E   $��1��6^   $��0��6n   $	��167��6{   .+�5      �� -   5        $��nrOfClustersLabel��5      $��Number of clusters:��6-   �� 5      -   5        $��nrOfClustersBox��5       � ToolTip$< 6Sets the number of clusters the algorithm will output.��6-   �� 5      -   5        $��isKernel��5   >   $��Is Kernel Matrix��6   $��16��62   6>   � 5       5      �� 5      �� 5      5      � 5       5      �� 5      �� 5      5      �� 5      -   5        $��
computeBtn��5   �   $��Compute��6   $G AComputes the desired clustering matrix according to the settings!��6@   $��23��6�   $
��Left=�6�   {�. $	��Top=�6�   $	��111��6�   5       � 5!   
   -   5        $��buildProgress��5!      $��20��6+   $��1��67   $��0��6D   $��2��6T    � Minimum$ 0Q�6h   �� 5"   
   -   5        $��progressText��5"      $��0��6(   $��2��68   $��1��6L   $��0%��6Y   $��Center=�6c   5#      5$      