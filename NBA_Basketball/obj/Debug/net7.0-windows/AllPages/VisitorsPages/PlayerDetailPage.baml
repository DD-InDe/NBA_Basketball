   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       NBA_Basketball<   6NBA_Basketball.AllPages.VisitorsPages.PlayerDetailPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dwpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      -   5          N� Title$  Player Detail��5	      $
��auto��6   $	��900��6+   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      $	��200 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��5,30,0,0q�6)    �� Orientation$ 
Horizontal=�6;   $
��Left=�6T   .+�5      �� $	��110��6   $	��100��6$   ��61   �� *Player.PhotoImage+�� 5      $ Vertical=�6   .+�5      �� $��5q�6    $
��Left=�6+      HeaderTextBlock#��[  6F   ��5       �� *Player.Name+�� 5      	 �� X1$ 0��6   	 �� Y1$ 0��6"   	 �� X2$	 350��6)   	 �� Y2$ 0��62   $��1��69   ���#3838386M   �� 5      $
��Left=�6      DescriptionTextBlock#��[ 6;   ��5      `� 5       �� StringFormat$ {0}  |  {1}  |  {2}��6+   .1�5    "   �� 	 �� Path$	 ShirtNumberText�6*   �� 5!   "   $	 Player.Height�6*   �� 5"   "   $	 Team.TeamName�6*   5#      5%      �� 5&      $ 
Horizontal=�6!   .+�5'      �� $ Vertical=�6%   .+�5(      �� #��[ 6(   $
��Left=�6V   $
��Born��5)   (   �� 5*      #��[ 6(   $
��Left=�6V   $��College��5+   (   5,      �� 5-      $ Vertical=�6%   $��	10,0,10,0q�6<   .+�5.      �� #��[ 6(   $
��Left=�6V   $
��Bold"�5/   (   ��6:   �� *Player.ShortDateOfBirth+�� 50      #��[ 6(   $
��Left=�6V   $
��Bold"�51   (   ��6:   �� *Player.College+52      �� 53      $ Vertical=�6%   .+�54      �� #��[ 6(   $
��Left=�6V   $��
Experience��55   (   �� 56      #��[ 6(   $
��Left=�6V   $��Salary��57   (   58      �� 59      $ Vertical=�6%   $��	10,0,10,0q�6<   .+�5:      �� #��[ 6(   $
��Left=�6V   $
��Bold"�5;   (   ��6:   �� *Player.ExperienceText+�� 5<      #��[ 6(   $
��Left=�6V   $
��Bold"�5=   (   ��6:   �� *
SalaryText+5>      5?      5@      5A      � 5B      $��1��6   .+�5C      �� $��20,0,0,0q�6   $ Vertical=�6/   $��Center=�6F   $��Center=�5D      .+�5E      �� -   5        
 ��Name$
 SeasonTextBlock��5E       #��[ 69   $
��Left=�5F       $
��Bold"�6;   &   System.Windows.Controls.DataGrid  5G      -   5          Name$ SeasonResultDataGrid��5G        DefaultDataGrid#��[ 6=   $
��auto��6f      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5H      $
��auto��5I         Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K        DataGridElement1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 61     DataGridHeaderOther,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 5L   1      Header$	 PPG��6d      Binding 5M   1   �� *PPG+  5N      # [ 61   # [ 5O   1   $	 APG��6d    5P   1   �� *APG+  5Q      # [ 61   # [ 5R   1   $	 RPG��6d    5S   1   �� *RPG+5U      �� 5V      #��[ 6    $
��Left=�6N   $
��Bold"�5W       $��Career��5X         5Y      -   5        $ CareerResultDataGrid��5Y      #��[ 6=   $
��auto��6f   $ 70 5Z      $
��auto��5[       5\        5]      # [ 61   # [ 5^   1   $	 PPG��6d    5_   1   �� *PPG+  5`      # [ 61   # [ 5a   1   $	 APG��6d    5b   1   �� *APG+  5c      # [ 61   # [ 5d   1   $	 RPG��6d    5e   1   �� *RPG+5g      5h      5i      5j      � 5k   
   $��1��6   .+�5l      �� $	��0.1q�6   
���   �._�5n      �� $ Vertical=�6   $��Center=�64   .+�5o      �� -   5         ��Name$ GraphButtonStackPanel��5o   !   $ 
Horizontal=�6@   $��Center=�6Y   .+�5p      �� -   5         ��Name$ PointsButton��5p   !     PlayerDetailButton#��[ 5q   !   $��POINTS��6M   �� 5r      -   5        $ ReboundsButton��5r   !   #��[ 5s   !   $��REBOUNDS��6M   �� 5t      -   5        $ AssistsButton��5t   !   #��[ 5u   !   $��ASSISTS��6M   �� 5v      -	   5        $ StealsButton��5v   !   #��[ 5w   !   $��STEALS��6M   �� 5x      -
   5        $ BlocksButton��5x   !   #��[ 5y   !   $��BLOCKS��6M   5z      �� 5{      -   5        $
 AverageTextBlock��5{       #��[ 6:   5|      5}      5~      �� 5   
   -   5        $
 DataTextBlock��5      $��2��6+   
�������$��50(�6O   $��Center=�6]   $��Center=�5�      $��No data��61   $��Arial)�6@   $y�Hidden=�6S   #   LiveCharts.Wpf.CartesianChart  5�   
   -   5        $��CartesianChart��5�   *   $��2��6   &    LiveCharts.Wpf.Charts.Base.Chart   AxisY 5�         LiveCharts.Wpf.Axis     MinValue$ 0Q�6   5�      5�      5�      