   M S B A M L   `   `   `  ����  FootballManagerUI$    FootballManagerUI.ImageCreator   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ImageCreator��5   	   $	��300��6   $	��459��6+   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��324* �6   �� 5      $
��113* �6    � RowDefinitions 5
   
   �� 5      $
��242* �6   �� 5      $��19 �6   .+�5      �� -   5        $��	imageList��5      }�. $��0��6=   $��0��6M   � 5   
   -   5        $��buildProgress��5       � Minimum$ 0Q�6+   $��0��67   $��1��6G   $��2��6T   5      �� 5   
   -   5        $��progressText��5   1   $��0��6   $��1��6$   $��0%��6E   $��Center=�6O   $��2��6l   �� 5   
   -   5        $��stackPanel2��5   k   $��1��6   $��0��6%   $	��258��62   $
��Left=�6?   $��0,3,0,0q�6Z   $	��Top=�6~   $	��111��6�   .+�5      �� -   5        $��drawGraphsBtn��5   �   $��Draw Graphs��6    � ToolTip$� �This will enable drawing of the edges between the teams! Some graphs may be lost due to the data violating the voronoi constraints!��6-   $��16��6�   6�   �� 5      -   5        $��parallelsBtn��5   �   $��Multi-thread��6   $� �This will affect the computer's performance and is a bit unstable (will lose a few graphs)! You gain (a lot) of speed depending on the number of processors.��6.   $��16��6�   6�   �� 5      -   5        $��parsePossesionBtn��5   =   $��Parse Possesion��6   $��16��61   $P JMakes the procedure thick the player that is believed to possess the ball!��6V   	� 5      -   5        $��firstHalfRBtn��5   ;   $��
First Half��6   $��16��6/    d� 	IsChecked$
 TrueY�6P   $' !Builds images for the first half!��6a   
 � Tag$ 1��6�    	� 	GroupName$ periodSelection��6�   6�   	� 5      -	   5        $��secondHalfRBtn��5   <   $��Second Half��6   $��16��60   $ 2��6R   $ periodSelection��6Z   $( "Builds images for the second half!��6v   6�   �� 5      -
   5        $��	createBtn��5   �   $��Create Images��6   $L FPlease select the raw data file path and the destination folder first!��6-   $��23��6~   $	��110��6�   6�   5      5      5      