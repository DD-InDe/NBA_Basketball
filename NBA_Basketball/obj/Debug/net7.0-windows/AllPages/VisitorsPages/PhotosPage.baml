   M S B A M L   `   `   `  ����  NBA_Basketball6    0NBA_Basketball.AllPages.VisitorsPages.PhotosPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Photos��5      $
��auto��6   $
��auto��6$    � 	Resources 5	         ImageTemplate  	ImageLoad � ContextMenu m� Icon��%(  &	        7  �� 5
   
   .R�5      �� 8��  ��67   �� *Img+ 5      �� 5      .@�5      m� -   5        $��Download��5   #    5      �� 5   "   $��20��6(   $��20��63   $��/Resources/download.png��6?   $
��Fill=�6`   5      5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��   DescriptionTextBlock#��[ 6   $z��tWhen you like a photo, you can right-click a photo and choose the download menu item in the context menu to download��5       �� 5"   
   -   5         ��Name$ ImageListBox��5"   W   $��1��6   $��Center=�6   $��Center=�6<   #��[  6m   ��5#      �� 5$      .R�5%      A�  A� Columns$ 4��6"   5&      5(      � 5*   
   $��2��6   .+�5+      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   .+�5,      �� -   5         ��Name$ PageInfoTextBlock��5,      $��Center=�67     MainTextBlock#��[ 6R   5-      �� 5/      $ 
Horizontal=�6   $��Right=�62   .+�50      �� -   5        	 ��Name$	 FirstPageButton��50        AlphabetButton#��[ 6R     	BlueBrush#��[ 6z   $��I<��6�   �� 51      -   5        $	 PreviousPageButton��51      #��[ 6X   #��[ 6�   $��<��6�   �� 52      -   5        
 ��Name$
 CurrentPageTextBox��52      $
��auto��66     SearchTextBox#��[ 6C   $��Center=�53      54      �� 55      -   5        $	 NextPageButton��55      #��[ 6P   #��[ 6x   $��>��6�   �� 56      -   5        $	 LastPageButton��56      #��[ 6P   #��[ 6x   $��>I��6�   �� 57      -	   5        $	 DownloadAll��57        ControlButton#��[ 6J   $%��Download photos in current page��58      59      5:      5;      5<      