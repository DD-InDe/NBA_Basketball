   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       NBA_Basketball=   7NBA_Basketball.AllPages.VisitorsPages.MatchupDetailPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44olen)http://schemas.xceed.com/wpf/xaml/toolkit  5      >wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5        N� Title$  Matchup Detail��5	      $	��450��6   $	��800��6.   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ TeamInfoStackPanel��5   !   $��10q�6    �� Orientation$ Vertical=�6=   $��0��6T   $��Center=�6a   $��Center=�5      .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Center=�6      DescriptionTextBlock#��[  67   ��6e   �� *TeamAwayNavigation.TeamName+�� 5      $��70��6   $��55��6#   $
��Fill=�6/   $��Center=�6>   ��6Y   �� *TeamAwayNavigation.LogoImage+�� 5      $��Center=�6   #��[  67   ��6e   �� *TeamAwayScore+&   System.Windows.Controls.DataGrid  5      -   5          Name$ PointsDataGrid��5        DefaultDataGrid#��[ 63   $
��auto��6\      AutoGenerateColumns$
 True��6j   �� 5      $��Center=�6   #��[  67   ��6e   �� *TeamHomeScore+�� 5      $��Center=�6   $��70��63   $��55��6>   $
��Fill=�6J   ��6Y   �� *TeamHomeNavigation.LogoImage+�� 5      $��Center=�6   #��[  67   ��6e   �� *TeamHomeNavigation.TeamName+5      �� 5      -   5         ��Name$ StatusTextBlock��5      $	��150��61   $��5q�6@   #��[  6K   
���������5   +   �� *
ColorBrush+��6M   �� *
StatusName+5      �� 5   
   $��1��6   .@�5!      �� $
��auto��6   ��5"      �� 5#      #��[  6    $��Team Status��6N   ��5%      �� 5'      $ 
Horizontal=�6!   .+�5(      �� 
���iii�$	��0.5q�67   $��10q�6M   ._�5)      �� $ Vertical=�6)   $��Center=�6@   $
��Left=�6[   .+�5*   "   � -   5         �Name$ 
ImagesGrid��5*   '    � ColumnDefinitions 5+   &   �� 5,   *   $	��300 �6;   �� 5-   *   $	��100 �6;   �� 5.   *   $	��100 �6;   .+�50   &   �� $��1��6,   $��80��6<   $
��Fill=�6G   $��65��6V   $��5q�6b   $��Center=�6m   ��51   ,   �� *TeamAwayNavigation.LogoImage+�� 52   &   $��2��6,   $��80��6<   $
��Fill=�6G   $��65��6V   $��5q�6b   $��Center=�6m   ��53   ,   �� *TeamHomeNavigation.LogoImage+54   #     55   "   -   5        $ TeamStatusDataGrid��55   +   #��[ 6G   $	��500��6p   $
��auto��6|   	   HeadersVisibility$
	 None=�56   +   
   GridLinesVisibility$
 
Horizontal=�6D      Columns 57   &   0  *System.Windows.Controls.DataGridTextColumn  58   *   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *CurrentActionName+   ElementStyle 59   .   �� 5:   2    �� 
TargetType" ��68     DataGridElement �� BasedOn# [ 6O   .�5;   6   ��  �� Property � �� �� Value$
 Left=�6\   5<   3   5>   +     5?   *   # [ 6=   $	 100 6m    5@   =   �� *TeamAwayScore+  5A   *   # [ 6=   $	 100 6m    5B   =   �� *TeamHomeScore+5D   #   5E      5F      �� 5G      $ Vertical=�6%   .+�5I      �� 
���iii�$	��0.5q�6;   $��10q�6Q   ._�5J   "   �� $ Vertical=�6-   .+�5K   &   ��   MainTextBlock#��[ 60   $��Field Goal %��6W   �� 5M   &   $ 
Horizontal=�61   .+�5N   *   �� -   5        $ FgTeamAwayAbbr��5N   4   #��[  6L   $��50��6z   � 5O   *   -   5         �Name$ FgTeamAwayBar��5O   6     DefaultProgressBar#��[ 6M   �� 5P   *   -   5        $ FgTeamAwayTextBlock��5P   4   #��[  6Q   $��50��6   5Q   '   �� 5S   &   $ 
Horizontal=�61   .+�5T   *   �� -	   5        $ FgTeamHomeAbbr��5T   4   $��50��6L   #��[  6W   � 5U   *   -
   5        $ FgTeamHomeBar��5U   6   #��[ 6M   �� 5V   *   -   5        $ FgTeamHomeTextBlock��5V   4   $��50��6Q   #��[  6\   5W   '   5X   #   5Y      �� 5[      
���iii�$	��0.5q�6;   $��10q�6Q   ._�5\   "   �� $ Vertical=�6-   .+�5]   &   �� #��[ 60   $��Three Point %��6W   �� 5_   &   $ 
Horizontal=�61   .+�5`   *   �� -   5        $ FpTeamAwayAbbr��5`   4   $��50��6L   #��[  6W   � 5a   *   -   5        $ FpTeamAwayBar��5a   6   #��[ 6M   �� 5b   *   -   5        $ FpTeamAwayTextBlock��5b   4   $��50��6Q   #��[  6\   5c   '   �� 5e   &   $ 
Horizontal=�61   .+�5f   *   �� -   5        $ FpTeamHomeAbbr��5f   4   $��50��6L   #��[  5g   4   � 5h   *   -   5        $ FpTeamHomeBar��5h   6   #��[ 5i   6   �� 5j   *   -   5        $ FpTeamHomeTextBlock��5j   4   $��50��6Q   #��[  5k   4   5l   '   5m   #   5n      5o      5p      5r      �� 5t      $
��auto��6   ��5u      �� 5v      #��[  6    $��Short Chart��6N   ��5x      � 5y      -   5        $ ShortChartGrid��5y      $	��900��63   $	��350��6?    5z      �� 5{      $��* �6/   �� 5|      $��* �6/   �� 5}      $��* �6/   .+�5      �� $��3��6    $	��900��64   $	��350��6@   $
��Fill=�6M   $��../../Resources/court.png��5�       �� 5�      $��0��5�   %   $ Vertical=�65   $��Center=�6L   $��Center=�5�   %    � DataContext 5�   %   ��  �� ElementName$ ShortChartGrid�� �� Path$ DataContext�.+�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��35��6(   $��30��63   $
��Fill=�5�   (   ��5�   ?   �� *TeamAwayNavigation.LogoImage+5�   (   �� 5�   "   #��[ 6,   ��5�   ,   �� *TeamAwayNavigation.TeamName+5�      �� 5�      -   5         ��Name$ TeamAwayListView��5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� $��20��64   $��25��6?   $
��Fill=�6K   ��5�   4   �� *Player.PhotoImage+�� 5�   .   #��[ 68   ��5�   8   �� *PlayerNumber+5�   +   5�   '   5�      5�      �� 5�      $��1��6    $	��100��60   $��80��6<   $
��Fill=�6H   $��Center=�6W   $��Center=�6r   ��5�       �� *TeamHomeNavigation.LogoImage+�� 5�      $��2��6j   $ Vertical=�6z   $��Center=�5�   %   $��Center=�6@    5�   %   �� $ ShortChartGrid��$ DataContext�.+�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��35��6(   $��30��63   $
��Fill=�5�   (   ��5�   ?   �� *TeamHomeNavigation.LogoImage+5�   (   �� 5�   "   #��[ 6,   ��5�   ,   �� *TeamHomeNavigation.TeamName+5�      �� 5�      -   5        $ TeamHomeListView��5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� $��20��64   $��25��6?   $
��Fill=�6K   ��6Z   �� *Player.PhotoImage+�� 5�   .   #��[ 68   ��6_   �� *PlayerNumber+5�   +   5�   '   5�      5�      5�      5�      �� 5�      $
��auto��6   ��5�      �� 5�      #��[  6    $	��Log��6N   ��5�      � 5�      .+�5�      �� -   5        $ LogsStackPanel��5�   <   $ Vertical=�6%   .+�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� #��[ 6,   $��Quarter:��6S   �� 5�   "   -   5         ��Name$ QuarterComboBox��5�   +     DefaultComboBox#��[ 5�   +   5�        5�      -   5        $ LogDataGrid��5�   '   #��[ 6<    5�   "     5�   &     DataGridHeader   HeaderStyle# [ 69      Header$ 
Occur Time��6g   # [ 5�   9    6i   �� *	OccurTime+  5�   &   # [ 69   $
 Team��6g   # [ 5�   9    6i   �� *	Team.Abbr+  5�   &   # [ 69   $
 0.3* 6g   $ Player��6t   # [ 5�   9    6i   �� *PlayerNumber+  5�   &   # [ 69   $
 0.5* 6g   $ Action Type��6t   # [ 5�   9    6i   �� *ActionType.Name+  5�   &   # [ 69   $
 0.5* 6g   $ Remark��6t   # [ 5�   9    6i   �� *Remark+5�      5�      �� 5�      -   5        $ DataTextBlock��5�   $   
�������$��50(�6R   $��Center=�6`   $��Center=�6{   $��No data��6�   $��Arial)�6�   $y�Hidden=�6�   5�      5�      5�      5�      5�      