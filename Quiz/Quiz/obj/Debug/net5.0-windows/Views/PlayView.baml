   M S B A M L   `   `   `  ����?  ;Quiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Quiz.ViewModelsQuiz.ViewModels  5          Quiz.Views.PlayView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      4
viewModelsclr-namespace:Quiz.ViewModels     5      .��5      �   � RowDefinitions  5   
   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��2��5      $��Center=�5      $	��Top=�5      .+�5      �� -   5         ��Name$ 
PlayButton��5      $	��400��5      $��70��5      
�����_�$��Start��5      $��30(�5      ��5      �� *StartCommand+5      �� 5       -   5         ��Name$ PickQuizComboBox��5!      $	��400��5"      $��40��5#      $��0,5,0,0q�5$      $	��Top=�5%       �� DisplayMemberPath$ Title��5&       �� SelectedIndex$ 0��5(      ��5'      �� *
AllQuizzes+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5)      �� *
QuizToPlay+$ PropertyChanged=� �� Mode$ OneWayToSource=��� 5*      -   5         ��Name$ CategoriesListBox��5+      $	��120��5,      $��0,5,0,0q�5-      	 �� SelectionMode$	 Multiple=�50      ��5.      �� *
Categories+
 �� NotifyOnSourceUpdated$

 True�� 5/      ��  �� Path$ CategoriesToPlay�$ PropertyChanged=���51      �� 52      .R�53      �� ��6$   �� *Name+54      ��56      �� 57       �� 
TargetType" ��6   .�58      ��  �� Property �@��
IsSelected �� Value 67   �� $ TwoWay=�$ 
IsSelected�59      5;      5<      �� 5=   
   $��0��5>      $	��200��5?      $	��200��5@      $
��Left=�5A      $	��Top=�5B       �� Orientation$ Vertical=�5C      .+�5D      �� -   5         ��Name$ QuizTitleTb��5E      $��30(�5F      
�����_�$y�	Collapsed=�5I      ��5H      �� *Title+$ PropertyChanged=�5I      �� 5J      $ 
Horizontal=�6   .+�5K      �� -   5        $ UserScoreTb��5L      $��30(�5M      
�����_�$y�	Collapsed=�5P      ��5O      �� *	UserScore+$ PropertyChanged=�5P      �� 5Q      -   5        $ SlashSignTb��5R      $��30(�5S      
�����_�$��/��5U      $y�	Collapsed=�5V      �� 5W      -   5        $ AmountOfQuestionsTb��5X      $��30(�5Y      
�����_�$y�	Collapsed=�5\      ��5[      �� *AmountOfQuestions+$ PropertyChanged=�5\      5]      5^      �� 5_   
   -   5         ��Name$ FirstStackPanel��5`      $��1��5a      $��Center=�5b      $��Bottom=�5c      $ 
Horizontal=�5d      $y�Hidden=�5e      .+�5f      �� -	   5        $ StatementTextBlock��5g      $	��500��5h      $	��160��5i      $��5q�5j      
�����_�$��20(�5l       �� TextAlignment$ Center=�5o      {�5m      �� *
QuizActive+$ OneWay=�$ PropertyChanged=���5n      �� *	Statement+$ PropertyChanged=�5o      �� 5p      -
   5        $ Answer1Button��5q      $	��500��5r      $	��160��5s      $��5q�5t      $��Center=�5u      $��Center=�5v      
�����_�$��20(�5z      ��5x      �� *Answer1Command+��5y      �� *	Answer1+$ PropertyChanged=�{�5{      �� *
QuizActive+$ OneWay=�$ PropertyChanged=�5|      �� 5}   
   -   5        $ SecondStackPanel��5~      $��2��5      $��Center=�5�      $��Bottom=�5�      $ 
Horizontal=�5�      $y�Hidden=�5�      .+�5�      �� -   5        $ Answer2Button��5�      $	��500��5�      $	��160��5�      $��5q�5�      $��Center=�5�      $��Center=�5�      
�����_�$��20(�5�      ��5�      �� *Answer2Command+��5�      �� *	Answer2+$ PropertyChanged=�{�5�      �� *
QuizActive+$ OneWay=�$ PropertyChanged=��� 5�      -   5        $ Answer3Button��5�      $	��500��5�      $	��160��5�      $��5q�5�      $��Center=�5�      $��Center=�5�      
�����_�$��20(�5�      ��5�      �� *Answer3Command+��5�      �� *	Answer3+$ PropertyChanged=�{�5�      �� *
QuizActive+$ OneWay=�$ PropertyChanged=�5�      �� 5�   
   -   5         ��Name$ QuestionImage��5�      $��0��5�      $
��1000��5�      $y�Hidden=�5�      ��5�      �� *Image+$ PropertyChanged=�5�      5�      5�      