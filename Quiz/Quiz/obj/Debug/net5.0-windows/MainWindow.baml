   M S B A M L   `   `   `  ����?  ;Quiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizQuiz  5      1clr-namespace:Quiz.ViewModelsQuiz.ViewModels  5      'clr-namespace:Quiz.Views
Quiz.Views  5	          Quiz.MainWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Quiz     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      4
viewModelsclr-namespace:Quiz.ViewModels     5      *viewsclr-namespace:Quiz.Views     5	        � Title$  
MainWindow��5
      $
��1300��5      $	��800��5       � 
ResizeMode$ NoResize=�5      .��5      � ��5   
   �� 5       �� 
StartPoint$ 0.5,0&�6"    �� EndPoint$ 0.5,1&�65   .��5      �  � Color$ Black��6   � 5       � Offset$ 0.587Q�6   $ 	#FF191919��6.   5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   �� -   5         ��Name$ BackgroundImage��5      $��1��5      $
��1000��5      $	��500��5      $��Images/quizimg.jpg��5       �� 5!   
   $��0��5"      $��Center=�5#       �� Orientation$ 
Horizontal=�5$      .+�5%      �� -   5        $	��300��5&      $��40��5'      $��10q�5(      $
��Left=�5)      $	��Top=�5*      
�����_�$
��Play��5.      $
��Play��5/      ��5-      �� *PlayViewCommand+5/      �� 50      -   5        $	��300��51      $��40��52      $��10q�53      $
��Left=�54      $	��Top=�55      
�����_�$
��Edit��59      $��Edit/Create��5:      ��58      �� *EditViewCommand+5:      5;      �� 5<   
   $��1��6   ��6&   �� *CurrentView+5=      5>      