   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  Save The Humans��5   	   $	��450��6!   $	��800��6.    � 	Resources 5	         EnemyTemplate �� 
TargetType J� RenderTransformOrigin �� AngleX��%�  &	        �� 5
   
   " ��60   .R�5      � .+�5      A� 
�������
���   �$	��100��65   $��75��6B   A� 5      
���   �
���   �$��35��66   $��25��6C   $	��Top=�5      $��Center=�62   $��
40,20,70,0q�5      $ 0.5,0.5&�6.   z�5      V� 5      .~�5      �� �� 5      $ 10Q�6,   �� 5      T� 5      5      5      A� 5      
���   �
���   �$��35��66   $��25��6C   $	��Top=�5      $��Center=�62   $��
70,20,40,0q�5      $ 0.5,0.5&�6.   z�5      V� 5      .~�5      �� �� 5      $	 -10Q�6,   �� 5       T� 5!      5"      5$      5%      5&      5'      .��5)      � -   5         �Name$
 grid��5)      
���   � � ColumnDefinitions 5*   
   �� 5+      $	��140 �6   �� 5,      �� 5-      $	��160 �6    � RowDefinitions 5/   
   �� 50      �� 51      $	��150 �6   .+�54   
   �� -   5         ��Name$ startButton��54      $��Start!��55      $��1��56      $��Center=�57      $��Center=�58      6,   � 59   
   -   5        	 �Name$	 progressBar��59      $��1��6+   $��1��6;   $��20��6H   �� 5;   
   -   5        
 ��Name$
 playArea��5;      $��3��6#   ��5<      �� 5=       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5>      �  � Color$ 	#FFA640EE��6#    � Offset$ 0Q�65   � 5?      $ 	#FF87EE40��6#   $ 1Q�65   5@      .+�5B      �� -   5         ��Name$ human��5B       �� Orientation$ Vertical=�6(   .+�5C      A� 
�������$��10��6'   
���   �$��0,0,0.021,0q�6B   $��10��6W   �� 5D      
�������$��25��6)   
���   �$��0,0,0.021,0q�6D   $��10��6Y   5E      �� 5F      -   5         ��Name$ gameOverText��5F       �� Left$ 71��6.   $
��Wrap=�6?   $��	Game Over��6S   
 �� Top$ 80��6d   $��Arial)�6t   $	��100(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5G      -   5         ��Name$ target��5G      $��50��6(   $	 725��64   
���   �$	 255��6U   $��50��6f   $ 0.5,0.5&�6q   z�5H      V� 5I      .~�5J      �� �� 5K      �� 5L       �� Angle$ 45Q�6*   T� 5M      5N      ��5P      �� 5Q      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5R      � $ Black��6'   $ 0Q�65   � 5S      $ White��6'   $ 1Q�65   5T      5V      �� 5W      -   5        $ WinText��5W      $	 250��6)   $
��Wrap=�6;   $
��Win!��6O   $ 80��6[   $��Arial)�6k   $	��100(�6~   $
��Bold"�6�   $��Italic$�6�   5X      �� 5Y   
   $��2��6   $ Vertical=�6%   $��1��6<   $��Center=�6I   $��Center=�6d   .+�5Z      �� $
��Wrap=�5[      $��Avoid These��5\      $��18(�6   $��Center=�6,   $��Center=�6I   
�������6d   �� 5]      $��ContentControl��6   #���   66   5^      5_      5`      