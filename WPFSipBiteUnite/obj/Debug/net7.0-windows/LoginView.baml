   M S B A M L   `   `   `  ����J  FWPFSipBiteUnite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPFSipBiteUnite.ViewModelWPFSipBiteUnite.ViewModel  5   	   O,clr-namespace:WPFSipBiteUnite.CustomControlsWPFSipBiteUnite.CustomControls  5   	       WPFSipBiteUnite.LoginView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =	viewModel'clr-namespace:WPFSipBiteUnite.ViewModel     5   	   GcustomControls,clr-namespace:WPFSipBiteUnite.CustomControls     5   	   -   5          � Title$  	LoginView��5	   	   $	��540��6   $	��804��6(    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      .   (WPFSipBiteUnite.ViewModel.LoginViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5      �� 
 �� CornerRadius$
 14��6   $��2q�5      ��5   
   �� 5        �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5!      �   Primary � Color# [ 6    � Offset$ 0Q�6@   � 5"        PrimaryHover# [ 6   $
 0.75Q�6E   5#      ��5&   
   �� 5'      $	 0,1&�6"   $	 1,0&�63   .��5(      �   
Neutral800# [ 6   $ 0Q�6C   � 5)        
Neutral900# [ 6   $ 1Q�6C   5*      ._�5.   
   �  � RowDefinitions 5/      �� 50      $��56 �6    �� 51      .+�53      � $��0��6   $	��Top=�54      $��	0, 8, 0,0q�55       � ColumnDefinitions 56      �� 57      �� 58      $��25 �6'   �� 59      $��25 �6'   �� 5:      $��8 �6'   .+�5<      �� $��Вхід��6     Neutral700Brush#��[ 5=      $��10(�5>      $��
Montserrat)�5?      $��Medium"�5@      $��0��5A      $��Center=�5B      $��12,0,0,0q�5C      �� 5E      -   5         ��Name$ btnClose��5E      $��0q�5F      $��X��5G        NeutralWhiteBrush#��[ 5H      $��12(�5I      $��
Montserrat)�5J       � Cursor$
 Hand��5K      $��2��5L      ��5N      �� 5O       �� 
TargetType" ��6    .�5P      ��  �� Property � �� �� Value# [ 6;    �� Triggers 5Q      P� 5R   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5S   &   ��  � ��  Neutral800Brush# [ 6C   5T   #   5V      ��5X      �� 5Y       �� 
TargetType" ��6*   .R�5Z      �� $��20��6%   $��20��60   $
 10��5[   %   #��z��5\   %   ._�5]   "   �� $��Center=�63   $��Center=�5^   3   5_      5`      5b      5c      �� 5d      $	��380��6   $��1��5e       �� Orientation$ Vertical=�5f      $��0,12,0,0q�5g      .+�5h      �� $��Вхід��6   #��[ 5i      $��28(�5j      $
��Bold"�5k      $��
Montserrat)�5l      $
��Left=�5m      �� 5n      $[��UПоринь у світ пива, оцінивши власні вподобання��6     Neutral400Brush#��[ 5o      $��14(�5p      $��
Montserrat)�5q      $
��Wrap=�5r      $��0,4,0,0q�5s      �� 5t      $%��Електронна пошта��6   $��14(�5u      $��
Montserrat)�5v      $��0,28,0,0q�5w      $��Medium"�6.   ��5x      �� 5y       	 
Neutral400 �� Color# � 	 6*   5{      �� 5|      -   5         ��Name$ txtUser��5|      $��14(�5~      $��Medium"�5      $��
Montserrat)�5�      #��[ 5�      
������  �� 
CaretBrush# [ 5�      $��0,0,0,2q�5�      $��28��5�      $��Center=�5�      $��0,8,0,0q�5�      $��0,0,0,0q�5�      ��5}      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.��5�   N   ��5�      �� 5�      # � 	 6*   .��5�   +   5�      �� 5�      $��Пароль��6   $��14(�5�      $��
Montserrat)�5�      $��0,32,0,0q�5�      $��Medium"�6.   ��5�      �� 5�      # � 	 6*   5�      8   2WPFSipBiteUnite.CustomControls.BindablePasswordBox  5�      $��28��5�      $��0,8,0,0q�5�         Password 5�      �� *
Password+$ TwoWay=�$ PropertyChanged=�5�      �� 5�       
 FunctionalRedBrush#��[
 6:   ��6   �� *ErrorMessage+6m   �� 5�      -   5        $ btnLogin��5�      $��Увійти��5�      $��0,48,0,0q�5�      $
 Hand��5�      $��44��5�      $��
Montserrat)�5�      $��16(�5�      $��Medium"�5�      #��[ 5�      ��5�      �� *LoginCommand+��5�      �� 5�      " ��6    .�5�      ��  � ��  PrimaryBrush# [ 6;    5�      P� 5�   "    �@J�IsMouseOver$
 True��6A   . �5�   &   ��  � ��  PrimaryHoverBrush# [ 6C   5�   #   5�      ��5�      �� 5�      " ��6*   .R�5�      �� $
 6��6%   #��z��5�   %   ._�5�   "   �� $��Center=�63   $��Center=�5�   3   5�      5�      5�      �� 5�      $��0,32,0,0q�6   $ 
Horizontal=�6/   $	��380��6H   $��44��6T   $��Center=�5�      $	��Top=�6:   .+�5�      �� $*��$Ще не маєте профілю?��6    #��[ 5�       $��14(�5�       $��
Montserrat)�5�       $
��Wrap=�5�       $��Center=�64   �� 5�      -   5        $ btnRegister��5�      $$��Зареєструватися��5�      $��32,0,0,0q�5�      $
 Hand��5�      $	��200��5�      $��44��5�      $��
Montserrat)�5�      $��16(�5�      $��Medium"�5�      #��[ 5�      #��[ 5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��  Neutral900Brush# [ 6?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � ��# [ 6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $
 6��6)   $��2q�5�   )   #��z��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      5�      5�      5�      5�      