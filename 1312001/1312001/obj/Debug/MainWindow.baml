   M S B A M L   `   `   `  ����B  >1312001, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:_1312001_1312001  5   	   #clr-namespace:_1312001_1312001  5   	       _1312001.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )Columnclr-namespace:_1312001     5   	   (Boardclr-namespace:_1312001     5   	   -   5        $��window��5   >     � Title$  1312001_Gomoku��6	   $��578.681��6    $
��1000��61   .��5      � -   5        $��Grid_Background��5      
���������5      ��  �� ElementName$ window�� �� Path$ ActualHeight� �� Mode$ OneWay=���5	      �� $ window��$ ActualWidth�$ OneWay=� � ColumnDefinitions 5
   
   �� 5      -   5         �Name$ C0��5      $
��650* �6)   �� 5      -   5        $ C1��5      $	��10* �6)   �� 5      -   5        $ C2��5      $
��309* �6)   �� 5      -   5        $ C3��5      $	��20* �6)   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $	��20* �6    �� 5      $
��506* �6    �� 5      $	��53* �6    .+�5      � $��1��6    5      �� 5      -   5        $ C0_C0��5   '   $��20 �64   �� 5      -   5        $ C0_C1��5   '   $��* �64   �� 5      -	   5        $ C0_C2��5   '   $��* �64   �� 5      -
   5        $ C0_C3��5   '   $��* �64   �� 5      -   5        $ C0_C4��5   '   $��* �64   �� 5      -   5        $ C0_C5��5   '   $��* �64   �� 5      -   5        $ C0_C6��5   '   $��* �64   �� 5       -   5        $ C0_C7��5    '   $��* �64   �� 5!      -   5        $ C0_C8��5!   '   $��* �64   �� 5"      -   5        $ C0_C9��5"   '   $��* �64   �� 5#      -   5        $ C0_C10��5#   '   $��* �65   �� 5$      -   5        $ C0_C11��5$   '   $��* �65   �� 5%      -   5        $ C0_C12��5%   '   $��* �65   �� 5&      -   5        $ C0_C13��5&   '   $��* �65   .+�5(         _1312001.Cot  -   5          Name$ column_0��5(         x$ 0��6/   $��1��65   $��1��6�   	   
StartColor$	 	black.png��6�   
   EndColor$
 	white.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_0��$ Height�$ OneWay=�6�     5)      -   5        $ column_1��5)      $ 1��6/   $��1��65   $��2��6�   $	 	white.png��6�   $
 	black.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_1��$ Height�$ OneWay=�6�     5*      -   5        $ column_2��5*      $ 2��6/   $��1��65   $��3��6�   $	 	black.png��6�   $
 	white.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_2��$ Height�$ OneWay=�6�     5+      -   5        $ column_3��5+      $ 3��6/   $��1��65   $��4��6�   $	 	white.png��6�   $
 	black.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_3��$ Height�$ OneWay=�6�     5,      -   5        $ column_4��5,      $ 4��6/   $��1��65   $��5��6�   $	 	black.png��6�   $
 	white.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_4��$ Height�$ OneWay=�6�     5-      -   5        $ column_5��5-      $ 5��6/   $��1��65   $��6��6�   $	 	white.png��6�   $
 	black.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_5��$ Height�$ OneWay=�6�     5.      -   5        $ column_6��5.      $ 6��6/   $��1��65   $��7��6�   $	 	black.png��6�   $
 	white.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_6��$ Height�$ OneWay=�6�     5/      -   5        $ column_7��5/      $ 7��6/   $��1��65   $��8��6�   $	 	white.png��6�   $
 	black.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_7��$ Height�$ OneWay=�6�     50      -   5        $ column_8��50      $ 8��6/   $��1��65   $��9��6�   $	 	black.png��6�   $
 	white.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_8��$ Height�$ OneWay=�6�     51      -   5        $ column_9��51      $ 9��6/   $��1��65   $��10��6�   $	 	white.png��6�   $
 	black.png��6�   ��6B   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ column_9��$ Height�$ OneWay=�6�     52      -   5        $ 	column_10��52      $ 10��60   $��1��67   $��11��6�   $	 	black.png��6�   $
 	white.png��6�   ��6D   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ 	column_10��$ Height�$ OneWay=�6�     53      -    5        $ 	column_11��53      $ 11��60   $��1��67   $��12��6�   $	 	white.png��6�   $
 	black.png��6�   ��6D   �� $ C0_C1��$ ActualHeight�$ OneWay=���6�   �� $ 	column_11��$ Height�$ OneWay=�6�   54      55      � 56   
   $��2��6   $��
0,10,0,-10q�6     57      �� 59      -!   5        $ C2_R0��59       $	��32* �6-   �� 5:      -"   5        $ C2_R1��5:       $	��25* �6-   �� 5;      $	��23* �6    �� 5<      -#   5        $ C2_R2��5<       $��0* �6-   �� 5=      -$   5        $ C2_R3��5=       $	��29* �6-   �� 5>      -%   5        $ C2_R4��5>       $
��258* �6-   �� 5?      $
��115* �6    �� 5@      -&   5        $ C2_R5��5@       $	��64* �6-   �� 5A      -'   5        $ C2_R7��5A       $	��33* �6-   .+�5C      �� $��1��6   $��
Your name:��6!   $
��Left=�66   $��Center=�6Q   $��14(�6�   $
��Bold"�6�   $
��0,10q�6�   $��2��6�   ��6l   �� $ C2_R1��$ Height�$ OneWay=�6�   �� 5D      -(   5        $��YourName��5D      $��1��6&   $��Center=�63   $��24��6P    �� TextWrapping$
 Wrap=�6]   $��Guest��6q   $��Center=�6~   $	��150��6�   $��14(�6�   $��82,14,81,10q�6�   $��2��6�   �� 5E      -)   5        $��1��5E      $��Change!��6"   $��Right=�65   $��Center=�6Q   $��71��6l   $��24��6w   $��14(�6�   $
��Bold"�6�   
���   �$��
0,14,10,10q�6�   $��2��6�   �� 5G      $��3��6   
����ح�$��2��6�   ��67   �� $ C2_R3��$ Width�$ OneWay=���6t   �� $ C2_R3��$ Height�$ OneWay=�6�   �� 5H      $��3��6   $
��Left=�6!   $��Images/Chat.png��6<    J� RenderTransformOrigin$ 0.283,0.523&�6U   $��2��6y   �� 5I      $��3��6   $��30��6R   $
��Left=�6^   $��       Chat/History��6y   $��16(�6�   $��Segoe UI Black)�6�   $��	0,0,0,257q�6�   $��3��6�   ��6"   �� $ C2_R3��$ Width�6�   �� 5J      -*   5        $��chatBox��5J   c   $��5��6    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6�   $��2��6�   ��6#   �� $ C2_R4��$ Height�$ OneWay=���6s   �� $ C2��$ Width�$ OneWay=�6�   �� 5K      -+   5        $��
input_chat��5K      $��7��6(   $
��Left=�65   $��40��6P   $
 Wrap=�6\   $��Center=�6p   $	��230��6�   $��16(�6�   $
 Auto=�6�   $	��0,7q�6�   �� 5L      -,   5        $��7��5L      $
��Send��6"   
��� ���$��Right=�6E   $��Center=�6a   $��73��6|   $��40��6�   $��14(�6�   $
��Bold"�6�   
���   �$��0,7,10,7q�6�   	� 5M      --   5         	�Name$ rbt_2Player��5M      $��2 Player��60   $
��Left=�6C   $��10,8,0,0q�6^    d� 	IsChecked$
 TrueY�6p   $	��Top=�6�   6�   	� 5N      -.   5        $ rbt_Machine��5N      $��Play with machine��6/   $
��Left=�6K   $��80,8,0,0q�6f   $	��Top=�6x   6�   	� 5O      -/   5        $��online��5O      $��Online��6(   $
��Left=�69   $	��Top=�6T   $��	10,23,0,0q�6�   $��2��6�   	� 5P      -0   5        $��onlineMachine��5P      $��Machine Online��6/   $
��Left=�6H   $	��Top=�6c   $��	80,23,0,0q�6�   $��2��6�   $	��114��6�   �� 5Q      -1   5         ��Name$ btn_Newgame��5Q      $��New game��6*   $
��Left=�6=   $��
219,12,0,0q�6X   $	��Top=�6l   $��75��6�   
�������6�   �� 5R      -2   5        $��	container��5R      $y�Hidden=�6�   ��6'   �� $ window��$ 	MyMessage� �� UpdateSourceTrigger$ PropertyChanged=�6�   5S      5T      5U      